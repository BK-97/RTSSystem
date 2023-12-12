using UnityEngine;
public class MoveState : BaseState
{
    public override void EnterState(CharacterStateMachine stateController)
    {
        stateController.moveController.MoveTarget(stateController.clickedTargetPos);
    }

    public override void ExitState(CharacterStateMachine stateController, BaseState nextState)
    {
        stateController.SwitchState(nextState);
    }

    public override void UpdateState(CharacterStateMachine stateController)
    {
        if (stateController.moveController.IsDestinationReached())
            ExitState(stateController, stateController.idleState);
        stateController.moveController.MoveTarget(stateController.clickedTargetPos);
    }
}
