using UnityEngine;

public class TakePlayerCameraTransform : MonoBehaviour
{
    public Transform playerCamera;
    void LateUpdate()
    {
        transform.position = playerCamera.transform.position;
        transform.rotation = playerCamera.transform.rotation;
    }
}
