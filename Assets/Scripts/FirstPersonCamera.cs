using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{  
	[Header("Camera")]
 	[Tooltip("The Camera")]
 	public Camera Camera;
 	[Tooltip("How far in degrees can you move the camera up")]
 	public float TopClamp = 90.0f;
 	[Tooltip("How far in degrees can you move the camera down")]
 	public float BottomClamp = -90.0f;
 	[Tooltip("The Sensitivity for Mouse Camera Movement")]
 	public float sensitivity = 1;
 	[Tooltip("The Smoothness of Camera Rotation")]
 	public float smoothing = 2;
 	
 	public GameObject vr;
  
 	public bool vrActive = true;
  
     // 
 	private Vector2 currentMouseLook;
 	// 
 	private Vector2 appliedMouseDelta;
  
     void Start()
     {
         Cursor.lockState = CursorLockMode.Locked;
 		Cursor.visible = false;
     }
  
     void Update()
     {
 		CameraRotation();
     }
  
     private void CameraRotation()
 	{
 		if (vrActive)
 		{
 			Camera.transform.localRotation =  Quaternion.Euler(vr.transform.eulerAngles.x - transform.eulerAngles.x, 
 															   0, 
 															   vr.transform.eulerAngles.z - transform.eulerAngles.z);
 			transform.localRotation = Quaternion.Euler(0,vr.transform.eulerAngles.y - transform.eulerAngles.y,0);
 		}
 		else
 		{
 			// Get smooth mouse look.
 			Vector2 smoothMouseDelta = Vector2.Scale(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")), Vector2.one * sensitivity * smoothing);
 			appliedMouseDelta = Vector2.Lerp(appliedMouseDelta, smoothMouseDelta, 1 / smoothing);
 			currentMouseLook += appliedMouseDelta;
 			currentMouseLook.y = Mathf.Clamp(currentMouseLook.y, -90, 90);
  
 			// Rotate camera and controller.
 			Camera.transform.localRotation = Quaternion.AngleAxis(-currentMouseLook.y, Vector3.right);
 			transform.localRotation = Quaternion.AngleAxis(currentMouseLook.x, Vector3.up);
 		}
  
  
 	}
  
 	private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
 	{
 		if (lfAngle < -360f) lfAngle += 360f;
 		if (lfAngle > 360f) lfAngle -= 360f;
 		return Mathf.Clamp(lfAngle, lfMin, lfMax);
 	}
 }
