using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSSelector : Singleton<RTSSelector>
{
    public bool isMultiSelecting;
    [SerializeField]
    private LayerMask rtsCharacterLayer;
    [SerializeField]
    private LayerMask GroundLayer;

    public void CheckSelectInput(Vector3 clickPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(clickPos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, rtsCharacterLayer))
        {
            if (hit.transform.GetComponent<ISelectable>() == null)
                return;

            if (isMultiSelecting)
            {
                ShiftSelect(hit.transform.gameObject);
                return;
            }
           Select(hit.transform.gameObject);
        }
        else
        {
            RTSManager.Instance.ClearSelectedList();
        }
    }
    public void CheckActionInput(Vector3 clickPos)
    {
        if (CheckForDamagable(clickPos) != null)
        {
            RTSManager.Instance.AttackAllRTSUnits(CheckForDamagable(clickPos));
        }
        else
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(clickPos);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, GroundLayer))
            {
                RTSManager.Instance.MoveAllRTSUnits(hit.point);
            }
        }
    }
    public void Select(GameObject selectedObject)
    {
        RTSManager.Instance.ClearSelectedList();
        RTSManager.Instance.SelectedCharacters.Add(selectedObject);
        selectedObject.GetComponent<ISelectable>().Selected();
    }
    public void ShiftSelect(GameObject selectedObject)
    {
        if (!RTSManager.Instance.SelectedCharacters.Contains(selectedObject))
        {
            RTSManager.Instance.SelectedCharacters.Add(selectedObject);
            selectedObject.GetComponent<ISelectable>().Selected();
        }
        else
        {
            RTSManager.Instance.SelectedCharacters.Remove(selectedObject);
            selectedObject.GetComponent<ISelectable>().Deselected();
        }
    }
    private GameObject CheckForDamagable(Vector3 clickPos)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(clickPos);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            IDamagable damagable = hit.collider.gameObject.GetComponent<IDamagable>();
            if (damagable != null)
                return hit.collider.gameObject;
            else
                return null;
        }
        else
            return null;
    }
}
