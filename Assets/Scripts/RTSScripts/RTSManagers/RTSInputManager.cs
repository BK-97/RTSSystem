using UnityEngine;
public class RTSInputManager : Singleton<RTSInputManager>
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RTSManager.Instance.CheckRightClick(Input.mousePosition);
        }
        if (Input.GetMouseButtonDown(0))
        {
            RTSManager.Instance.CheckLeftClick(Input.mousePosition);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
            RTSManager.Instance.multiSelect = true;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            RTSManager.Instance.multiSelect = false;
    }

}
