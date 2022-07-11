using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPos : MonoBehaviour
{
    public GameObject capsule;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.position = capsule.transform.position;
    }
}
