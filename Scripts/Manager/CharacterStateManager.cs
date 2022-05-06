using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State.Character;
using UnityEngine.AI;

public class CharacterStateManager : MonoBehaviour
{
    /* ------------------------------------------ */

    public NavMeshAgent Agent;

    public LayerMask GroundLayer;

    public LayerMask UILayer;

    public CharacterBaseState CurrentState;

    public Character Character;

    public static Vector3 TargetPoint
    {
        get { return _targetPoint; }
    }
    private static Vector3 _targetPoint;

    /* ------------------------------------------ */

    AttackState _attackState = new AttackState();
    RunState _runState = new RunState();
    IdleState _idleState = new IdleState();
    MoveState _moveState = new MoveState();
    DeathState _deathState = new DeathState();

    WaitForSeconds _delay;

    Stats _stats;

    Type Type;

    float _lastClickTime;

    const float _doubleClickTime = 0.5f;

    RaycastHit hit;
    RaycastHit _hit;

    /* ------------------------------------------ */

    private void Awake()
    {
        Character = GetComponent<Character>();
        ComponentManager.instance.CharacterStateManager.Add(Character, this);
    }

    private void Start()
    {
        _delay = new WaitForSeconds(.25f);

        _stats = GetComponent<Stats>();

        StateManager.instance.CharacterStateManagers.Add(this);

        CurrentState = _idleState;
        CurrentState.EnterState(this, new Argument());

    }

    /* ------------------------------------------ */

    private void Update()
    {
        CheckInputs();

        if (CurrentState != null)
            CurrentState.UpdateState();
    }

    /* ------------------------------------------ */

    void OnDestroy()
    {
        try
        {
            if (ComponentManager.instance.CharacterStateManager.ContainsKey(Character))
                ComponentManager.instance.CharacterStateManager.Remove(Character);

            if (StateManager.instance.CharacterStateManagers.Contains(this))
                StateManager.instance.CharacterStateManagers.Remove(this);
        }
        catch { }
    }

    /* ------------------------------------------ */
    void CheckInputs()
    {

        if (Input.GetMouseButtonDown(0))
        {
            CurrentState = _moveState;

            float timeSinceLastClick = Time.time - _lastClickTime;

            if (timeSinceLastClick <= _doubleClickTime)
            {
                CurrentState = _runState;
            }

            _lastClickTime = Time.time;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10000,UILayer))
            {
                Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                return;
            }
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100000, GroundLayer))
            {

                Vector3 _targetPos = hit.point;

                if (Physics.Raycast(_targetPos, -Vector3.up, out _hit))
                    _targetPos.y = _hit.point.y;


                NavMeshPath path = new NavMeshPath();
                Agent.CalculatePath(_targetPos, path);

                if (path.status == NavMeshPathStatus.PathComplete)
                {
                    CurrentState.EnterState(this, new Argument { TargetPosition = TargetPoint });
                    _targetPoint = _targetPos;
                }
            }


                
        }

        if (Mathf.Abs(transform.position.x - _targetPoint.x) <= 0.5 && Mathf.Abs(transform.position.z - _targetPoint.z) <= 0.5)
        {
            CurrentState = _idleState;
            CurrentState.EnterState(this, new Argument());
        }
        
    }
    IEnumerator IESwitchState(Type type, Argument argument)
    {
        //Check the character can run the state
        if (CheckIsItValidState(type))
        {
            Debug.Log("IESwitchState : " + type.ToString());

            if (CurrentState != null && type != Type.Death)
            {
                //If it's running, tell it to finish it
                //if (CurrentState.IsRunning)

                CurrentState.FinishState(Type.None, new Argument());

                //Lock the method here, till the current state finish.
                while (CurrentState.IsRunning)
                    yield return _delay;
            }

            //Make sure the character hasn't died
            if (_stats.Health > 0)
            {
                //Run the next state
                switch (type)
                {
                    case Type.Attack:
                        CurrentState = _attackState;
                        break;

                    case Type.Idle:
                        CurrentState = _idleState;
                        break;

                    case Type.Move:
                        _moveState.EnterState(this, argument);
                        CurrentState = _moveState;
                        break;

                    case Type.Run:
                        CurrentState = _runState;
                        break;
                }
            }
            else
            {
                CurrentState = _deathState;
            }
            CurrentState.EnterState(this, argument);

            yield return null;
        }
    }

    /* ------------------------------------------ */

    bool CheckIsItValidState(Type type)
    {
        switch (type)
        {
            case Type.Attack:

                if (!GetComponent<Attack>())
                    return false;
                break;

            case Type.Idle:

                if (!GetComponent<Idle>())
                    return false;
                break;

            case Type.Move:

                if (!GetComponent<Move>())
                    return false;

                break;

            case Type.Run:

                if (!GetComponent<Run>())
                    return false;

                break;

            case Type.Death:

                if (!GetComponent<Death>())
                    return false;
                break;
        }

        return true;
    }

    /* ------------------------------------------ */



    public void SwitchState(Type type, Argument argument)
    {
        if (!gameObject.activeInHierarchy)
            return;

        StartCoroutine(IESwitchState(type, argument));
    }

    /* ------------------------------------------ */

}

namespace State.Character
{
    /* ------------------------------------------ */
    public enum Type
    {
        None = 0,
        Idle = 1,
        Move = 2,
        Attack = 3,
        Run = 4,
        Death = 5
    }

    public struct Argument
    {
        public Vector3 TargetPosition;
    }

    /* ------------------------------------------ */
}