using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float shootSpeed;
    public GameObject explosionPrefab;
    public float explosionScale;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Goomba"))
        {
            collision.gameObject.GetComponent<Goomba>().die(Goomba.DeathTypes.DeathExplosion);
            Destroy(this.gameObject);
        }
        else if (!collision.transform.CompareTag("Ground") && !collision.transform.CompareTag("RightHand"))
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            explosion.transform.localScale *= explosionScale;
            Destroy(this.gameObject);
        }
    }
}