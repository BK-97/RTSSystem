using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class RTSControl : MonoBehaviour,ISelectable
{
    #region Params
    public Image image;
    public Camera myCam;
    private NavMeshAgent navmeshAgent;
    public NavMeshAgent NavMeshAgent { get { return (navmeshAgent == null) ? navmeshAgent = GetComponent<NavMeshAgent>() : navmeshAgent; } }
    [SerializeField]
    bool isSelected;
    public Vector3 targetPos;
    #endregion
    #region MonoBehaviourFunctions
    private void Awake()
    {
        if (myCam == null)
            myCam = Camera.main;

        AddRTSManager();
    }
    public void Move()
    {
        Debug.Log("mOVE");
        NavMeshAgent.SetDestination(targetPos);
    }
    public void Selected()
    {
        image.enabled = true;
        isSelected = true;
    }

    public void Deselected()
    {
        image.enabled = false;
        isSelected = false;

    }
    public void AddRTSManager()
    {
        RTSManager.Instance.AddSelectable(gameObject);
    }
    #endregion
}
