using UnityEngine;
using UnityEngine.AI;
public class RTSControl : MonoBehaviour,ISelectable
{
    #region Params
    public GameObject selectCircle;
    private NavMeshAgent navmeshAgent;
    public NavMeshAgent NavMeshAgent { get { return (navmeshAgent == null) ? navmeshAgent = GetComponent<NavMeshAgent>() : navmeshAgent; } }
    [SerializeField]
    bool isSelected;
    public Vector3 targetPos;
    #endregion
    #region MonoBehaviourFunctions
    private void Awake()
    {
        AddRTSManager();
    }
    public void Move()
    {
        NavMeshAgent.SetDestination(targetPos);
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
