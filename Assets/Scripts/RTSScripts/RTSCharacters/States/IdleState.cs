public class IdleState : BaseState
{
    public override void EnterState(CharacterStateMachine stateController)
    {

    }

    public override void ExitState(CharacterStateMachine stateController, BaseState nextState)
    {
        stateController.SwitchState(nextState);
    }

    public override void UpdateState(CharacterStateMachine stateController)
    {

    }
}
