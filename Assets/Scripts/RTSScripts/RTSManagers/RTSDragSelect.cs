using UnityEngine;
using UnityEngine.UI;

public class RTSDragSelect : MonoBehaviour
{
    #region Params
    Camera myCam;
    [SerializeField]
    RectTransform boxVisual;

    Rect selectionBox;
    Vector2 startPosition = Vector2.zero;
    Vector2 endPosition = Vector2.zero;

    #endregion
    #region MyMethods
    void DrawVisual()
    {
        Vector2 boxStart = startPosition;
        Vector2 boxEnd = endPosition;

        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        boxVisual.position = boxCenter;
        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));
        boxVisual.sizeDelta = boxSize;
        
    }
    void DrawSelection()
    {
        if (Input.mousePosition.x < startPosition.x)
        {
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPosition.x;
        }
        else
        {
            selectionBox.xMin = startPosition.x;
            selectionBox.xMax = Input.mousePosition.x;
        }
        if (Input.mousePosition.y < startPosition.y)
        {
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPosition.y;
        }
        else
        {
            selectionBox.yMin = startPosition.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
    }
    private void SelectUnits()
    {
        foreach (var unit in RTSManager.Instance.AllSelectableCharacters)
        {
            if (selectionBox.Contains(myCam.WorldToScreenPoint(unit.transform.position)))
            {
                RTSSelector.Instance.ShiftSelect(unit);
            }
        }
    }
    #endregion
    #region MonoBehaviourFunctions
    void Start()
    {
        if (myCam == null)
            myCam = Camera.main;
        
        DrawVisual();
        boxVisual.GetComponent<Image>().enabled = true;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            DrawVisual();
            DrawSelection();
        }
        if (Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
            DrawVisual();
            DrawSelection();
        }
        if (Input.GetMouseButtonUp(0))
        {
            SelectUnits();
            startPosition = Vector2.zero;
            endPosition = Vector2.zero;
            DrawVisual();
        }
    }
    #endregion
}