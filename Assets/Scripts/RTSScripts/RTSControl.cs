using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class RTSControl : MonoBehaviour,ISelectable
{
    #region Params
    public Image image;
    bool isSelected;
    public Camera myCam;
    public LayerMask GroundLayer;
    private NavMeshAgent navmeshAgent;
    public NavMeshAgent NavMeshAgent { get { return (navmeshAgent == null) ? navmeshAgent = GetComponent<NavMeshAgent>() : navmeshAgent; } }
    #endregion
    #region MonoBehaviourFunctions
    private void Awake()
    {
        if (myCam == null)
            myCam = Camera.main;

        AddRTSManager();
    }
    void Update()
    {
        if (!isSelected)
        {
            return;
        }
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, GroundLayer))
            {
                NavMeshAgent.SetDestination(hit.point);
            }
        }
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
