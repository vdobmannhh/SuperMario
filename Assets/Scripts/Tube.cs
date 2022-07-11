using UnityEngine;
using Valve.VR;

public class Tube : MonoBehaviour
{
    public float animationSpeed = 1.5f;
    public float targetRadius = 0.2f;
    public GameObject endofTube;
    public bool leadsToSecret = false;
    public bool leadsOutOfSecret = false;


    private const float offset = 2.5f;

    private bool isPlayerOnTube = false;
    private bool playerAnimation = false;
    private bool up = false;
    private GameObject player;
    private GameObject playerFeet;
    private FirstPersonController firstPersonController;
    private CapsuleCollider capsuleCollider;
    private SphereCollider sphereCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerFeet = GameObject.FindGameObjectWithTag("PlayerFeet");
        sphereCollider = playerFeet.GetComponent<SphereCollider>();
        capsuleCollider = player.GetComponent<CapsuleCollider>();
        firstPersonController = player.GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Actions.GetTubeAction().state && isPlayerOnTube && !playerAnimation)
        {
            playerAnimation = true;
            firstPersonController.enabled = false;
            capsuleCollider.enabled = false;
            sphereCollider.enabled = false;
            GameObject.FindGameObjectWithTag("PipeSound").GetComponent<AudioSource>().Play();
            var position = transform.position;
            player.transform.position = new Vector3(position.x,
                                                    player.transform.position.y,
                                                    position.z);
        }

        if (playerAnimation)
        {
            if (!up)
            {
                player.transform.position -= new Vector3(0, Time.deltaTime * animationSpeed, 0);
                if (player.transform.position.y <= 0)
                {
                    if (leadsToSecret)
                    {
                        GameObject.FindGameObjectWithTag("MainTheme").GetComponent<AudioSource>().Pause();
                    }
                    else if (leadsOutOfSecret)
                    {
                        GameObject.FindGameObjectWithTag("MainTheme").GetComponent<AudioSource>().Play();
                    }
                    GameObject.FindGameObjectWithTag("PipeSound").GetComponent<AudioSource>().Play();
                    up = true;
                    var position = endofTube.transform.position;
                    player.transform.position = new Vector3(position.x,
                                                            0,
                                                            position.z);
                }
            }
            else 
            {
                player.transform.position += new Vector3(0, Time.deltaTime * animationSpeed, 0);
                if (player.transform.position.y >= endofTube.transform.position.y + offset)
                {
                    if (leadsToSecret)
                    {
                        GameObject.FindGameObjectWithTag("Underworld").GetComponent<AudioSource>().Play();
                    }
                    else if (leadsOutOfSecret)
                    {
                        GameObject.FindGameObjectWithTag("Underworld").GetComponent<AudioSource>().Pause();
                    }
                    playerAnimation = false;
                    up = false;
                    firstPersonController.enabled = true;
                    capsuleCollider.enabled = true;
                    sphereCollider.enabled = true;
                    isPlayerOnTube = false;
                }
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerFeet"))
        {
            // Check if Players Position is in center of Tube
            if ((System.Math.Abs(player.transform.position.x - transform.position.x) <= targetRadius)
                       && (System.Math.Abs(player.transform.position.z - transform.position.z) <= targetRadius))
            {
                isPlayerOnTube = true;
            }          
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("PlayerFeet"))
        {
            isPlayerOnTube = false;
        }
    }

}
