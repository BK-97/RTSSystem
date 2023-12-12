using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMachine : MonoBehaviour
{
    [SerializeField]
    private CharacterData CharacterData;
    [HideInInspector]
    public CharacterHealthController healthController;
    [HideInInspector]
    public CharacterMoveController moveController;
    public bool canStateWork;
    public Vector3 clickedTargetPos;
    #region StateParams
    public BaseState currentState = null;
    public IdleState idleState = new IdleState();
    public MoveState moveState = new MoveState();
    public AttackState attackState = new AttackState();
    public GatherState skillState = new GatherState();
    #endregion
    private void Start()
    {
        healthController = GetComponent<CharacterHealthController>();
        moveController = GetComponent<CharacterMoveController>();
        Initalize();
    }
    void Initalize()
    {
        healthController.SetHealth(CharacterData.Health);
        moveController.Initalize(CharacterData.MoveSpeed);
        currentState = idleState;
        currentState.EnterState(this);
        canStateWork = true;
    }
    private void Update()
    {
        if (!canStateWork)
            return;
        currentState.UpdateState(this);
    }
    public void SwitchState(BaseState nextState)
    {
        canStateWork = false;
        currentState = nextState;
        currentState.EnterState(this);
        canStateWork = true;
    }
}
