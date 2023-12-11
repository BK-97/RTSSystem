using System.Collections.Generic;
using UnityEngine;
public class RTSManager : Singleton<RTSManager>
{
    #region Params
    [SerializeField]
    private LayerMask rtsCharacterLayer;
    [SerializeField]
    private LayerMask GroundLayer;
    [SerializeField]
    private bool UseFormation;

    [HideInInspector]
    public List<GameObject> SelectedCharacters;
    [HideInInspector]
    public List<GameObject> AllSelectableCharacters;
    [HideInInspector]
    public bool multiSelect;
    #endregion
    #region MyMethods
    public void AddSelectable(GameObject selectable)
    {
        AllSelectableCharacters.Add(selectable);
    }
    public void RemoveSelectable(GameObject selectable)
    {
        for (int i = 0; i < SelectedCharacters.Count; i++)
        {
            if (SelectedCharacters[i] == selectable)
                SelectedCharacters.RemoveAt(i);
        }
        AllSelectableCharacters.Remove(selectable);
    }
    public void CheckLeftClick(Vector3 clickPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(clickPos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100,rtsCharacterLayer))
        {
            if (hit.transform.GetComponent<ISelectable>() == null)
                return;

            if (multiSelect)
            {
                ShiftSelect(hit.transform.gameObject);
                return;
            }
            Select(hit.transform.gameObject);
        }
        else
        {
            ClearSelectedList();
        }
    }

    public void CheckRightClick(Vector3 clickPos)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(clickPos);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, GroundLayer))
        {
            MoveAllRTSUnits(hit.point);
        }
    }

    private void ClearSelectedList()
    {
        for (int i = 0; i < SelectedCharacters.Count; i++)
        {
            SelectedCharacters[i].GetComponent<ISelectable>().Deselected();
        }
        SelectedCharacters.Clear();
    }
    private void Select(GameObject selectedObject)
    {
        ClearSelectedList();
        SelectedCharacters.Add(selectedObject);
        selectedObject.GetComponent<ISelectable>().Selected();
    }
    public void ShiftSelect(GameObject selectedObject)
    {
        if (!SelectedCharacters.Contains(selectedObject))
        {
            SelectedCharacters.Add(selectedObject);
            selectedObject.GetComponent<ISelectable>().Selected();
        }
        else
        {
            SelectedCharacters.Remove(selectedObject);
            selectedObject.GetComponent<ISelectable>().Deselected();
        }
    }
    private Vector3 lastMousePos;
    public void ChangeFormation()
    {
        MoveAllRTSUnits(lastMousePos);
    }
    private void MoveAllRTSUnits(Vector3 mousePos)
    {
        if (SelectedCharacters.Count == 0)
            return;

        lastMousePos = mousePos;

        if (UseFormation && SelectedCharacters.Count > 1)
        {
            FormationManager.Instance.CalculateFormationPos(mousePos);
            foreach (var selectedCharacter in SelectedCharacters)
            {
                selectedCharacter.GetComponent<RTSControl>().Move();
            }
        }
        else
        {
            foreach (var selectedCharacter in SelectedCharacters)
            {
                selectedCharacter.GetComponent<RTSControl>().targetPos = mousePos;
                selectedCharacter.GetComponent<RTSControl>().Move();
            }
        }
    }
    #endregion
}