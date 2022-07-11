using System;
using UnityEngine;
using Valve.VR;


public class VRHandTracking : MonoBehaviour
{
    public SteamVR_Input_Sources inputSource;
    public Transform vrHdm;
    public Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0.35f, 1.4f, 0.35f);
        if (inputSource == SteamVR_Input_Sources.LeftHand)
        {
            offset.x *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Actions.GetPoseAction()[inputSource].localPosition;
        transform.localRotation = Actions.GetPoseAction()[inputSource].localRotation;
    }
}
