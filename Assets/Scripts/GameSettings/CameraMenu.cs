using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class CameraMenu : MonoBehaviour
{
    #region Singleton
    private static CameraMenu singletone;

    public static CameraMenu cameraMenu {get { return singletone; } }
    #endregion
    private void Awake()
    {
        singletone = this;
    }
    [SerializeField] private Camera camera; 
    [SerializeField] private CinemachineVirtualCamera cameraVC; 

    public Camera GetCamera() {  return camera; }
    public CinemachineVirtualCamera GetCameraVC() { return cameraVC; }
}
