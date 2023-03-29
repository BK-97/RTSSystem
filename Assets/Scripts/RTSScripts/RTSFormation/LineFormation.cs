using UnityEngine;
public class LineFormation : FormationBase
{
    public override void CalculateFormation(Vector3 mousePos)
    {
        int numRows = Mathf.CeilToInt((float)RTSManager.Instance.SelectedCharacters.Count / 6);
        int numPerRow = Mathf.CeilToInt((float)RTSManager.Instance.SelectedCharacters.Count / numRows);

        for (int i = 0; i < RTSManager.Instance.SelectedCharacters.Count; i++)
        {
            int row = i / numPerRow;
            int col = i % numPerRow;
            Vector3 newPos = mousePos + new Vector3(col * FormationManager.Instance._unitXOffset, 0, row * FormationManager.Instance._unitZOffset);
            RTSManager.Instance.SelectedCharacters[i].GetComponent<RTSControl>().targetPos = newPos;
        }
    }
}
