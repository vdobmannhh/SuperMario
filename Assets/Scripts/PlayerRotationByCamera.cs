using UnityEngine;

public class PlayerRotationByCamera : MonoBehaviour
{
    [Header("Camera")] [Tooltip("The Camera")]
    public Camera playerCamera;

    void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        transform.localRotation =
                Quaternion.Euler(0, playerCamera.transform.eulerAngles.y, 0);
    }
}