using UnityEngine;
using UnityEngine.AI;
public class RTSUnit : MonoBehaviour, ISelectable
{
    private RTSActions currentCommand;
    #region Params
    public GameObject selectCircle;
    private CharacterStateMachine stateController;
    [SerializeField]
    bool isSelected;
    public Vector3 targetPos;
    public GameObject targetEnemy;
    #endregion
    #region Methods
    private void Awake()
    {
        stateController = GetComponent<CharacterStateMachine>();
        Initialize();
    }
    public void Initialize()
    {
        RTSManager.Instance.AddSelectable(gameObject);
    }
    public void HandleCommand(RTSActions newCommand)
    {
        switch (newCommand)
        {
            case RTSActions.Move:
                stateController.moveController.targetPoint = targetPos;
                stateController.SwitchState(stateController.moveState);
                break;
            case RTSActions.Attack:
                stateController.attackController.enemyTarget = targetEnemy;
                stateController.SwitchState(stateController.attackState);
                break;
            case RTSActions.Gather:
                break;
            default:
                break;
        }
    }
    public void Selected()
    {
        selectCircle.SetActive(true);
        isSelected = true;
    }

    public void Deselected()
    {
        selectCircle.SetActive(false);
        isSelected = false;
    }
    #endregion
}
