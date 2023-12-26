public abstract class BaseState
{
    public abstract void EnterState(CharacterStateMachine stateController);
    public abstract void UpdateState(CharacterStateMachine stateController);
    public abstract void ExitState(CharacterStateMachine stateController, BaseState nextState);

}