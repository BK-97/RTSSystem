using UnityEngine;
public class TriangleFormation : FormationBase
{
    public override void CalculateFormation(Vector3 mousePos)
    {
        int totalCalculated = 0;
        int rowCount = CalculateM(RTSManager.Instance.SelectedCharacters.Count);
        float halfDistance = FormationManager.Instance._unitXOffset / 2f;

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

                float xPos = mousePos.x + (i - (rowSize - 1) / 2f) * FormationManager.Instance._unitXOffset;
                float zPos = mousePos.z + (row * FormationManager.Instance._unitZOffset) - halfDistance;
                RTSManager.Instance.SelectedCharacters[index].GetComponent<RTSControl>().targetPos = new Vector3(xPos, mousePos.y, zPos);
                index++;
            }
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
}
