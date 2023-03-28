using UnityEngine;
public class InputManager : MonoBehaviour
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
    }

}
