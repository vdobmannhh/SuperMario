using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject playerHead;
    // Update is called once per frame
    void Update()
    {
        transform.position = playerHead.transform.position;
    }
}
