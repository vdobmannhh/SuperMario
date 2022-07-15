using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    public Transform playerTransform;

    public Vector3 offsetFactor = new Vector3(1, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x + offsetFactor.x, playerTransform.position.y + offsetFactor.y,
            playerTransform.position.z + offsetFactor.z);
    }
}