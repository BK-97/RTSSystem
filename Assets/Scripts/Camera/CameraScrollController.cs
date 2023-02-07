using UnityEngine;
using Cinemachine;
public class CameraScrollController : MonoBehaviour
{
    #region Params
    [SerializeField]
    private CinemachineVirtualCamera cmv;
    private CinemachineComponentBase componentBase;
    [SerializeField]
    private float sensitivity;
    private float cameraDistance;
    private const float MAX_ZOOM = 5f;
    private const float MIN_ZOOM = 15f;
    #endregion
    #region Methods
    private void Start()
    {
        componentBase = cmv.GetCinemachineComponent(CinemachineCore.Stage.Body);
    }
    private void Update()
    {
        Zoom();
    }
    private void Zoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            cameraDistance = Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            if (componentBase is CinemachineFramingTransposer)
            {
                (componentBase as CinemachineFramingTransposer).m_CameraDistance -= cameraDistance;
                float currentDistance = (componentBase as CinemachineFramingTransposer).m_CameraDistance;
                if (currentDistance < MAX_ZOOM)
                {
                    (componentBase as CinemachineFramingTransposer).m_CameraDistance = MAX_ZOOM;
                }
                if (currentDistance > MIN_ZOOM)
                {
                    (componentBase as CinemachineFramingTransposer).m_CameraDistance = MIN_ZOOM;
                }
            }
        }
    }
    #endregion
}