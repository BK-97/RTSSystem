using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMachine : MonoBehaviour
{
    [SerializeField]
    private CharacterData CharacterData;
    [SerializeField]
    private CharacterHealthController healthController;
    #region StateParams
    public BaseState currentState = null;
    public IdleState idleState = new IdleState();
    public MoveState moveState = new MoveState();
    public AttackState attackState = new AttackState();
    public GatherState skillState = new GatherState();
    #endregion
    private void Start()
    {
        Initalize();
    }
    void Initalize()
    {
        healthController.SetHealth(CharacterData.Health);
    }
}
