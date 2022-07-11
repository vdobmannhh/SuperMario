using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Goomba : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    public float movementSpeed = 2f;
    public float rotationSpeed = 0.5f;
    public float rotationStart = 0.1f;
    public float rotationStop = 0.5f;
    public float movementStart = 0.1f;
    public float movementStop = 0.05f;

    public GameObject explosionPrefab;

    private int g_counter = 0;
    private int max_counter = 30;
    private float velocity;

    private string movement = "Idle";
    private float deathAnimationTime;
    private int rotation = 0;
    private int[] rotation_options = {0, -1, 1};
    public bool dieing = false;
    
    public enum DeathTypes
    {
        DeathShrink,
        DeathFlyAway,
        DeathExplosion
    }

    private Dictionary<DeathTypes, string> dieAnmiation = new Dictionary<DeathTypes, string>
    {
        { DeathTypes.DeathShrink, "DeathShrink" },
        { DeathTypes.DeathFlyAway, "DeathFlyAway" }
    };

    
    private void Start()
    {
        animator = this.GetComponentInChildren<Animator>();
        animator.SetFloat("runningSpeed", 2.0f * movementSpeed);
    }

    // Update is called once per frame
    private void Update()
    {   
        if (!dieing) 
        {
            velocity = movementSpeed * Time.deltaTime;
            g_counter++;

            if (g_counter == max_counter) 
            {
                g_counter = 0;
                changeMovement(false);
                changeRotating(false);
            }
            float randomSpeed = Random.Range(1.0f, 3.0f);
            transform.Rotate(0, rotationSpeed * randomSpeed * rotation,0);
            
            if (movement != "Idle") 
            {
                transform.Translate(0,0,velocity);
            }
        }
    }


    private void changeMovement(bool random)
    {
        float rand = random ? 1.0f : Random.Range(0.0f, 1.0f);
        switch (movement) {
            case "Idle" : 
                if (rand < movementStart)
                {
                    movement = "Running_Start";
                    animator.SetBool("isRunning", true);
                }
                break;
            case "Running_Start" :
                movement = "Running_Mid";
                break;
            case "Running_Mid" :
                if (rand < movementStop)
                {
                    movement = "Running_End";
                    animator.SetBool("isRunning", false);
                }
                break;
            case "Running_End" :
                movement = "Idle";
                break;     
        }  
    }

    private void changeRotating(bool random)
    {
        float rand = random ? 1.0f : Random.Range(0.0f, 1.0f);
        switch (rotation) {
            case 0 :          
                if (rand < rotationStart)
                {
                    rotation = -1;
                } else if (rand > 1.0f - rotationStart)
                {
                    rotation = 1;
                }
                break;
            case -1 :
                if (rand > 1.0f - rotationStop)
                {
                    rotation = 0;
                }
                break;
            case 1 :
                if (rand > 1.0f - rotationStop)
                {
                    rotation = 0;
                }
                break;
        }  
    }

    public void die(DeathTypes type)
    {
        GameObject.FindGameObjectWithTag("GoombaStomp").GetComponent<AudioSource>().Play();
        ChangeUi.scoreInc("Kill");
        rotation = 0;
        movementSpeed = 0;
        dieing = true;
        float animationTime = 0;

        switch (type)
        {
            case DeathTypes.DeathShrink:
            case DeathTypes.DeathFlyAway:
                GetComponent<Rigidbody>().isKinematic = true;
                animator.SetBool(dieAnmiation[type], true);
                animationTime = GetAnimationTimeOfDeath(type);
                break;
            case DeathTypes.DeathExplosion:
                Instantiate(explosionPrefab, transform.position, transform.rotation);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        
        
        Destroy(this.gameObject, animationTime);
    }

    private float GetAnimationTimeOfDeath(DeathTypes type)
    {
        float animationTime = 0;
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name == dieAnmiation[type])
            {
                animationTime = clip.length;
            }
        }
        return animationTime;
    }
}
