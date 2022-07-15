using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject shootObject;
    public Transform shootPoint;
    public float shootForce = 600;

    private int MAX_FIREBALL_COUNT = 4;
    public static int fireBallCount = 0;
    
    private void Update()
    {
        if(fireBallCount >= MAX_FIREBALL_COUNT) return;
        
        if (Actions.GetShootAction())
        {
            Sounds.GetAudioSource(Sounds.AudioType.Fireball).Play();
            GameObject ball = Instantiate(shootObject,shootPoint.position, shootPoint.rotation);
            fireBallCount++;
            ball.GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce);
        }
    }
}