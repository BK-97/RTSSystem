using UnityEngine;
public class MoveState : BaseState
{
    public override void EnterState(CharacterStateMachine stateController)
    {
        stateController.moveController.MoveTarget();
    }

    public override void ExitState(CharacterStateMachine stateController, BaseState nextState)
    {
        stateController.SwitchState(nextState);
    }

    public override void UpdateState(CharacterStateMachine stateController)
    {
        if (stateController.moveController.IsDestinationReached())
            ExitState(stateController, stateController.idleState);
        if (stateController.attackController.IsEnemyTargetInRange())
            ExitState(stateController, stateController.attackState);

        stateController.moveController.MoveTarget();
    }
}
