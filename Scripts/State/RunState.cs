using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State.Character;

public class RunState : CharacterBaseState
{
    /* ------------------------------------------ */

    public override Type Type { get => Type.Run; }

    /* ------------------------------------------ */

    CharacterStateManager _manager;

    Run _run;

    bool _packItUp, _init;

    /* ------------------------------------------ */

    public override void EnterState(CharacterStateManager manager, Argument argument)
    {
        _manager = manager;

        _run = manager.Character.gameObject.GetComponent<Run>();
        _run.ChangeAnimation();

        _run.ChangeSpeed();
        _init = true;

        _packItUp = false;
    }

    public override void UpdateState()
    {
        if (_init)
        {
            IsRunning = true;

            _run.Process();
        }

        if (_packItUp && !_run.IsRunning)
            IsRunning = false;
    }


    public override void FinishState(Type nextState, Argument argument)
    {
        //Debug.Log("FinishState : " + nextState.ToString());

        //if (nextState == Type.None)
        //    nextState = Type.Idle;

        _run.EndAnimation();

        _packItUp = true;

        if (nextState != Type.None)
            _manager.SwitchState(nextState,argument);
    }

    /* ------------------------------------------ */
}
