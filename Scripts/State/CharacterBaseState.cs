namespace State.Character
{
    public abstract class CharacterBaseState
    {

        /* ------------------------------------------ */

        public bool IsRunning;

        public abstract Type Type { get; }

        /* ------------------------------------------ */

        public abstract void EnterState(CharacterStateManager manager, Argument argument);

        public abstract void UpdateState();

        public abstract void FinishState(Type nextState, Argument argument);

        /* ------------------------------------------ */

    }
}