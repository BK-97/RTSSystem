using UnityEngine;
public class RTSInputManager : Singleton<RTSInputManager>
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RTSSelector.Instance.CheckActionInput(Input.mousePosition);
        }
        if (Input.GetMouseButtonDown(0))
        {
            RTSSelector.Instance.CheckSelectInput(Input.mousePosition);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
            RTSSelector.Instance.isMultiSelecting = true;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            RTSSelector.Instance.isMultiSelecting = false;
    }

}
