using UnityEngine;
public class BoxFormation : FormationBase
{
    public override void CalculateFormation(Vector3 mousePos)
    {
        int numRows = Mathf.CeilToInt(Mathf.Sqrt(RTSManager.Instance.SelectedCharacters.Count)); //kare boyutunu belirler

        for (int i = 0; i < RTSManager.Instance.SelectedCharacters.Count; i++)
        {
            int row = i / numRows;
            int col = i % numRows;
            Vector3 newPos = mousePos + new Vector3(col * FormationManager.Instance._unitXOffset, 0, row * FormationManager.Instance._unitZOffset);
            newPos.y = 0;
            RTSManager.Instance.SelectedCharacters[i].GetComponent<RTSUnit>().targetPos = newPos;
        }
    }
}