using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                OrganizeCharactersInSquare(mousePoint);
                break;
            case FormationTypes.Circle:
                OrganizeCharactersInCircle(mousePoint);
                break;
            case FormationTypes.Line:
                OrganizeCharactersInRows(mousePoint);
                break;
            case FormationTypes.Triangle:
                ArrangeCharactersInTriangleFormation(mousePoint);
                break;
            default:
                break;
        }
    }
    #region CalculateFormations
    public void ArrangeCharactersInTriangleFormation(Vector3 mousePoint)
    {
        int totalCalculated = 0;
        int rowCount = CalculateM(RTSManager.Instance.SelectedCharacters.Count);
        float halfDistance = _unitXOffset / 2f;

        RTSManager.Instance.SelectedCharacters.Sort((x, y) => x.transform.position.x.CompareTo(y.transform.position.x));

        int index = 0;
        for (int row = 0; row < rowCount; row++)
        {
            int rowSize = rowCount - row;

            for (int i = 0; i < rowSize; i++)
            {
                totalCalculated++;
                if (totalCalculated > RTSManager.Instance.SelectedCharacters.Count)
                    return;

                float xPos = mousePoint.x + (i - (rowSize - 1) / 2f) * _unitXOffset;
                float zPos = mousePoint.z + (row * _unitZOffset) - halfDistance;
                Debug.Log(index);
                RTSManager.Instance.SelectedCharacters[index].GetComponent<RTSControl>().targetPos = new Vector3(xPos, mousePoint.y, zPos);
                index++;
            }
        }
    }
    public void OrganizeCharactersInRows(Vector3 mousePoint)
    {
        int numRows = Mathf.CeilToInt((float)RTSManager.Instance.SelectedCharacters.Count / 5); //row say�s�n� belirler
        int numPerRow = Mathf.CeilToInt((float)RTSManager.Instance.SelectedCharacters.Count / numRows); //row ba��na karakter say�s�n� belirler

        for (int i = 0; i < RTSManager.Instance.SelectedCharacters.Count; i++)
        {
            int row = i / numPerRow;
            int col = i % numPerRow;
            Vector3 newPos = mousePoint + new Vector3(col * _unitXOffset, 0, row * _unitZOffset);
            RTSManager.Instance.SelectedCharacters[i].GetComponent<RTSControl>().targetPos = newPos;
        }
    }
    public void OrganizeCharactersInSquare(Vector3 mousePoint)
    {
        int numRows = Mathf.CeilToInt(Mathf.Sqrt(RTSManager.Instance.SelectedCharacters.Count)); //kare boyutunu belirler

        for (int i = 0; i < RTSManager.Instance.SelectedCharacters.Count; i++)
        {
            int row = i / numRows;
            int col = i % numRows;
            Vector3 newPos = mousePoint + new Vector3(col * _unitXOffset, 0, row * _unitZOffset);
            newPos.y = 0;
            Debug.Log(i);
            RTSManager.Instance.SelectedCharacters[i].GetComponent<RTSControl>().targetPos = newPos;
        }
    }
    public void OrganizeCharactersInCircle(Vector3 mousePoint)
    {
        int numCharacters = RTSManager.Instance.SelectedCharacters.Count;
        float angleBetweenCharacters = 360f / numCharacters;

        for (int i = 0; i < numCharacters; i++)
        {
            float angle = i * angleBetweenCharacters * Mathf.Deg2Rad;
            float x = Mathf.Cos(angle) * _unitXOffset;
            float y = Mathf.Sin(angle) * _unitZOffset;
            Vector3 newPos = mousePoint + new Vector3(x, 0, y);
            RTSManager.Instance.SelectedCharacters[i].GetComponent<RTSControl>().targetPos = newPos;
        }
    }
    public static int CalculateM(int total)
    {
        int m = 1;
        while (m * (m + 1) / 2 < total)
        {
            m++;
        }
        return m;
    }
    #endregion
    #endregion
}

