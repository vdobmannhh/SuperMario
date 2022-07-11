using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject playerHead;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.position = playerHead.transform.position;
    }
}
