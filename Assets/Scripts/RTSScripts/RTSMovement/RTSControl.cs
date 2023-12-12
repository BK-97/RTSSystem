using UnityEngine;
using UnityEngine.AI;
public class RTSControl : MonoBehaviour,ISelectable
{
    public enum RTSActions { Move,Attack,Gather}
    private RTSActions currentCommand;
    #region Params
    public GameObject selectCircle;
    private CharacterStateMachine stateController;
    [SerializeField]
    bool isSelected;
    public Vector3 targetPos;
    #endregion
    #region MonoBehaviourFunctions
    private void Awake()
    {
        AddRTSManager();
        stateController = GetComponent<CharacterStateMachine>();
    }
    public void HandleCommand(RTSActions newCommand)
    {
        switch (newCommand)
        {
            case RTSActions.Move:
                stateController.clickedTargetPos= targetPos;
                stateController.SwitchState(stateController.moveState);
                break;
            case RTSActions.Attack:
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
    public void AddRTSManager()
    {
        RTSManager.Instance.AddSelectable(gameObject);
    }
    #endregion
}
