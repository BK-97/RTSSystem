using System.Collections.Generic;
using UnityEngine;
public class RTSManager : Singleton<RTSManager>
{
    #region Params

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
    
    public void ClearSelectedList()
    {
        for (int i = 0; i < SelectedCharacters.Count; i++)
        {
            SelectedCharacters[i].GetComponent<ISelectable>().Deselected();
        }
        SelectedCharacters.Clear();
    }
  
    private Vector3 lastMousePos;
    public void ChangeFormation()
    {
        MoveAllRTSUnits(lastMousePos);
    }
    public void MoveAllRTSUnits(Vector3 mousePos)
    {
        if (SelectedCharacters.Count == 0)
            return;

        lastMousePos = mousePos;

        if (UseFormation && SelectedCharacters.Count > 1)
        {
            FormationManager.Instance.CalculateFormationPos(mousePos);
            foreach (var selectedCharacter in SelectedCharacters)
            {
                selectedCharacter.GetComponent<RTSUnit>().HandleCommand(RTSActions.Move);
            }
        }
        else
        {
            foreach (var selectedCharacter in SelectedCharacters)
            {
                selectedCharacter.GetComponent<RTSUnit>().targetPos = mousePos;
                selectedCharacter.GetComponent<RTSUnit>().HandleCommand(RTSActions.Move);
            }
        }
    }
    public void AttackAllRTSUnits(GameObject damagable)
    {
        if (SelectedCharacters.Count == 0)
            return;

        if (UseFormation && SelectedCharacters.Count > 1)
        {
            foreach (var selectedCharacter in SelectedCharacters)
            {
                selectedCharacter.GetComponent<RTSUnit>().targetEnemy = damagable;
                selectedCharacter.GetComponent<RTSUnit>().HandleCommand(RTSActions.Attack);
            }
        }
    }
    #endregion
}