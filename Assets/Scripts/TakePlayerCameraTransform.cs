using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePlayerCameraTransform : MonoBehaviour
{
    public Transform playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerCamera.transform.position;
        transform.rotation = playerCamera.transform.rotation;
    }
}
