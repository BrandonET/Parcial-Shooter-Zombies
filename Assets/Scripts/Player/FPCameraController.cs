using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class FPCameraController : CinemachineExtension
{
    public float mouseSensitivity = 100f;
    public float clampAngle = 90f;
    // Referencia al cuerpo del jugador
    public Transform playerBody;

    Vector3 startingRotation;

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        { 
            if(stage == CinemachineCore.Stage.Aim)
            {
                if(startingRotation == null)
                    startingRotation = transform.localRotation.eulerAngles;

                // Obtener la posicion en X y Y del mouse
                float x = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                Vector2 mousePosition = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                startingRotation.x += mousePosition.x * mouseSensitivity * Time.deltaTime;
                startingRotation.y -= mousePosition.y * mouseSensitivity * Time.deltaTime;

                // Restringues la rotacion de la camara en -90° y 90°
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);

                // Rotacion de la camara en X y Y
                state.RawOrientation = Quaternion.Euler(startingRotation.y, startingRotation.x, 0f);

                // Rotacion de la camara + cuerpo del personaje en X
                playerBody.Rotate(Vector3.up * x);
            }
        }
    }
}
