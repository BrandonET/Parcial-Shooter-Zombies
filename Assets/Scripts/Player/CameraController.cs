using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameType gameType;
    public CinemachineVirtualCamera camera2D;
    public CinemachineVirtualCamera firstPersonCamera;
    public CinemachineVirtualCamera thirdPersonCamera;

    private void Start()
    {
        // Desactivamos todas la cámaras
        firstPersonCamera.gameObject.SetActive(false);
        thirdPersonCamera.gameObject.SetActive(false);
        camera2D.gameObject.SetActive(false);

        // Depende del juego que queramos hacer activamos su cámara correspondiente
        switch (gameType)
        {
            case GameType.FirstPerson:
                Camera.main.orthographic = false;
                firstPersonCamera.gameObject.SetActive(true);
                break;
            case GameType.ThirdPerson:
                Camera.main.orthographic = false;
                thirdPersonCamera.gameObject.SetActive(true);
                break;
            case GameType.SideScroller:
                Camera.main.orthographic = true;
                camera2D.gameObject.SetActive(true);
                camera2D.transform.localPosition = new Vector3(0, 0, -10);
                camera2D.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                camera2D.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = 0.9f;
                break;
            case GameType.TopView:
                Camera.main.orthographic = true;
                camera2D.gameObject.SetActive(true);
                camera2D.transform.localPosition = new Vector3(0, 10, 0);
                camera2D.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
                camera2D.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = 0.5f;
                break;
        }
    }
}
