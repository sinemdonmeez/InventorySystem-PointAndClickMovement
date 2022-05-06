using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State.Character;

public class MoveState : CharacterBaseState
{


    /* ------------------------------------------ */

    public override Type Type { get => Type.Move; }

    /* ------------------------------------------ */

    CharacterStateManager _manager;

    Move _move;

    bool _packItUp, _init;

    /* ------------------------------------------ */

    public override void EnterState(CharacterStateManager manager, Argument argument)
    {
        _manager = manager;

        _move = manager.Character.gameObject.GetComponent<Move>();
        _move.ChangeAnimation();

        _move.ChangeSpeed();

        _init = true;

        _packItUp = false;
    }

    public override void UpdateState()
    {
        if (_init)
        {
            IsRunning = true;

            _move.Process();     
        }

        if (_packItUp && !_move.IsRunning)
            IsRunning = false;
    }


    public override void FinishState(Type nextState, Argument argument)
    {
        //Debug.Log("FinishState : " + nextState.ToString());

        //if (nextState == Type.None)
        //    nextState = Type.Idle;

        _move.EndAnimation();

        _packItUp = true;

        if (nextState != Type.None)
            _manager.SwitchState(nextState,argument);
    }

    /* ------------------------------------------ */


}
