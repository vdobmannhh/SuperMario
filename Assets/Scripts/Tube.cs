using UnityEngine;
using Valve.VR;

public class Tube : MonoBehaviour
{
    public float animationSpeed = 1.5f;
    public float targetRadius = 0.2f;
    public GameObject endofTube;
    public bool leadsToSecret = false;
    public bool leadsOutOfSecret = false;
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
        if (Actions.GetTubeAction() && isPlayerOnTube && !playerAnimation)
        {
            playerAnimation = true;
            firstPersonController.enabled = false;
            capsuleCollider.enabled = false;
            sphereCollider.enabled = false;
            Sounds.GetAudioSource(Sounds.AudioType.PipeSound).Play();
            var position = transform.position;
            player.transform.position = new Vector3(position.x,
                player.transform.position.y,
                position.z);
        }

        if (playerAnimation)
        {
            if (up)
            {
                player.transform.position += new Vector3(0, Time.deltaTime * animationSpeed, 0);
                if (player.transform.position.y >= endofTube.transform.position.y +
                    endofTube.GetComponent<Collider>().bounds.extents.y)
                {
                    if (leadsToSecret)
                    {
                        Sounds.GetAudioSource(Sounds.AudioType.UnderworldTheme).Play();
                    }
                    else if (leadsOutOfSecret)
                    {
                        Sounds.GetAudioSource(Sounds.AudioType.UnderworldTheme).Pause();
                    }

                    playerAnimation = false;
                    up = false;
                    firstPersonController.enabled = true;
                    capsuleCollider.enabled = true;
                    sphereCollider.enabled = true;
                    isPlayerOnTube = false;
                }
            }
            else
            {
                player.transform.position -= new Vector3(0, Time.deltaTime * animationSpeed, 0);
                if (player.transform.position.y <= transform.position.y)
                {
                    if (leadsToSecret)
                    {
                        Sounds.GetAudioSource(Sounds.AudioType.MainTheme).Pause();
                    }
                    else if (leadsOutOfSecret)
                    {
                        Sounds.GetAudioSource(Sounds.AudioType.MainTheme).Play();
                    }

                    Sounds.GetAudioSource(Sounds.AudioType.PipeSound).Play();
                    up = true;
                    var position = endofTube.transform.position;
                    player.transform.position = new Vector3(position.x,
                        endofTube.transform.position.y,
                        position.z);
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