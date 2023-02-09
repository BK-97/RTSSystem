using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FormationManager : Singleton<FormationManager>
{
    #region params
    public FormationTypes CurrentFormationType;
    [SerializeField] private int _unitXOffset = 5;
    [SerializeField] private int _unitZOffset = 5;
    #endregion

    #region MyMethods

    public void CalculateFormationPos(Vector3 mousePoint)
    {
        switch (CurrentFormationType)
        {
            case FormationTypes.Box:
                BoxFormation(mousePoint);
                break;
            case FormationTypes.Circle:
                CircleFormation(mousePoint);
                break;
            case FormationTypes.Line:
                LineFormation(mousePoint);
                break;
            case FormationTypes.V:
                VFormation(mousePoint);
                break;
            default:
                break;
        }

    }
    private float starterXPos;
    private float starterZPos;
    private void BoxFormation(Vector3 mousePoint)
    {
        //Debug.Log("mousePoint  " + mousePoint);
        int rowCount = Mathf.CeilToInt(Mathf.Sqrt(RTSManager.Instance.SelectedCharacters.Count));
        float offMultiplier = (rowCount / 2) - 0.5f;
        int currentIndex = 0;

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < rowCount; j++)
            {
                if (i + j == 0)
                {
                    RTSManager.Instance.SelectedCharacters[0].GetComponent<RTSControl>().targetPos =
                        new Vector3(mousePoint.x - (_unitXOffset * offMultiplier), 0, mousePoint.z + (_unitZOffset * offMultiplier));
                    starterXPos = RTSManager.Instance.SelectedCharacters[0].GetComponent<RTSControl>().targetPos.x;
                    starterZPos = RTSManager.Instance.SelectedCharacters[0].GetComponent<RTSControl>().targetPos.z;
                    //Debug.Log(currentIndex + "  " + RTSManager.Instance.SelectedCharacters[currentIndex].GetComponent<RTSControl>().targetPos);

                }
                else
                {
                    if (RTSManager.Instance.SelectedCharacters.Count <= currentIndex)
                        return;
                    //Debug.Log(currentIndex+"  "+ RTSManager.Instance.SelectedCharacters[0].GetComponent<RTSControl>().targetPos.x + "  " + RTSManager.Instance.SelectedCharacters[0].GetComponent<RTSControl>().targetPos.z + "  " + i + 1);
                    SetRow(currentIndex, i + 1,j);
                }
                currentIndex++;
            }
        }

    }
    private void SetRow(int currentIndex,int currentRow,int curretnIndexInRow)
    {
        RTSManager.Instance.SelectedCharacters[currentIndex].GetComponent<RTSControl>().targetPos =
                new Vector3(starterXPos + (curretnIndexInRow * _unitXOffset), 0, starterZPos - ((currentRow-1)*_unitZOffset));

        //Debug.Log(currentIndex + "  " + RTSManager.Instance.SelectedCharacters[currentIndex].GetComponent<RTSControl>().targetPos);

    }
    private void CircleFormation(Vector3 mousePoint)
    {

    }
    private void LineFormation(Vector3 mousePoint)
    {
    }
    private void VFormation(Vector3 mousePoint)
    {
    }
    #endregion

}
