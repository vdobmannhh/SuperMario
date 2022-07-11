using System;
using UnityEngine;
using Valve.VR;

public class Shoot : MonoBehaviour
{
    public GameObject shootObject;
    public Transform shootPoint;
    public float shootForce = 600;
  //  public SteamVR_Input_Sources inputSource;
    
    private void Update()
    {
        if (Actions.GetShootAction().GetStateUp(SteamVR_Input_Sources.Any))
        {
            GameObject ball = Instantiate(shootObject,shootPoint.position, shootPoint.rotation);
            ball.GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce);
        }
    }
}