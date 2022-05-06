using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : Identity
{
    public RuntimeAnimatorController Controller;

    public float Speed;

    public bool IsRunning;
    /* ------------------------------------------ */

    NavMeshAgent _navMeshAgent;
    Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
        ComponentManager.instance.Move.Add(character, this);

        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnDestroy()
    {
        try
        {
            if (ComponentManager.instance.Move.ContainsKey(identity))
                ComponentManager.instance.Move.Remove(identity);
        }
        catch
        { }
    }

    /* ------------------------------------------ */

    

    /* ------------------------------------------ */

    public void ChangeAnimation()
    {
        identity.Animator.runtimeAnimatorController = Controller;
        
    }

    public void ChangeSpeed() 
    {
        _navMeshAgent.speed = Speed;
    }

    public void PlayAnimation()
    {
        IsRunning = true;
    }

    public void EndAnimation()
    {
        IsRunning = false;
    }

    /* ------------------------------------------ */
    public override void Process()
    {
        Movement();
    }
    void Movement()
    {
        Debug.Log("yürüyorum");
        _navMeshAgent.SetDestination(CharacterStateManager.TargetPoint);
    }

    /* ------------------------------------------ */
}
