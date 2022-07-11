using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBlock : MonoBehaviour
{
public float animationSpeed = 1.5f;
    private bool hitanimation = false;
    private bool up = true;
    private const float MAXHEIGHT = 0.5f;
    private float height;
    private Vector3 initialPos;


    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("PlayerHead"))
        {
            hitanimation = true;
        } 
    }

    private void Start()
    {
        initialPos = transform.position;
        height = initialPos.y;
    }

    private void Update()
    {
        if (hitanimation)
        {
            if (height < initialPos.y + MAXHEIGHT && up) 
            {
                var inc = Time.deltaTime * animationSpeed;
                transform.position += new Vector3(0, inc, 0);
                height += inc;
            }
            else if (height > initialPos.y) 
            {
                up = false;
                var inc = Time.deltaTime * animationSpeed;
                transform.position -= new Vector3(0, inc, 0);
                height -= inc;
            }
            else 
            {
                transform.position = initialPos;
                height = initialPos.y;
                up = true;
                hitanimation = false;
            }
        }
    }
}
