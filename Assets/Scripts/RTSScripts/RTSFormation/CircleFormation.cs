using UnityEngine;
public class CircleFormation : FormationBase
{
    public override void CalculateFormation(Vector3 mousePos)
    {
        int numCharacters = RTSManager.Instance.SelectedCharacters.Count;
        float angleBetweenCharacters = 360f / numCharacters;

        for (int i = 0; i < numCharacters; i++)
        {
            float angle = i * angleBetweenCharacters * Mathf.Deg2Rad;
            float x = Mathf.Cos(angle) * FormationManager.Instance._unitXOffset;
            float y = Mathf.Sin(angle) * FormationManager.Instance._unitZOffset;
            Vector3 newPos = mousePos + new Vector3(x, 0, y);
            RTSManager.Instance.SelectedCharacters[i].GetComponent<RTSControl>().targetPos = newPos;
        }
    }
}