using UnityEngine;

public class Hands : MonoBehaviour
{
    public Transform playerTransform;

    public Vector3 offsetFactor = new Vector3(1, 1, 1);
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x + offsetFactor.x, playerTransform.position.y + offsetFactor.y,
            playerTransform.position.z + offsetFactor.z);
    }
}