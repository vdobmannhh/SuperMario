using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    public QuestionBlockItems.QuestionBlockItemType itemType;
    
    public GameObject block = null;
    public int coinsCount = 1;
    public GameObject coin = null;
    public GameObject mushroomSizeUp = null;
    public GameObject mushroomLifeUp = null;
    public GameObject fire = null;
    public GameObject star = null;

    public float explosionForce = 200f;
    public float explosionRadius = 3f;
    public float explosionUpward = 20.0f;

    public float animationSpeed = 4f;
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
            collisionHandler();
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
                float inc = Time.deltaTime * animationSpeed;
                transform.position += new Vector3(0, inc, 0);
                height += inc;
            }
            else if (height > initialPos.y)
            {
                up = false;
                float inc = Time.deltaTime * animationSpeed;
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

    void initiateObject(GameObject prefab)
    {
        var objectPos = transform.position;
        objectPos.y += 1.1f;
        var newObject = Instantiate(prefab, objectPos, Quaternion.identity);
        newObject.GetComponent<Rigidbody>()
            .AddExplosionForce(explosionForce, objectPos, explosionRadius, explosionUpward);
    }

    void collisionHandler()
    {
        bool disable = true;

        if (mushroomSizeUp != null)
        {
            GameObject.FindGameObjectWithTag("ItemPopupSound").GetComponent<AudioSource>().Play();
            initiateObject(mushroomSizeUp);
        }
        else if (mushroomLifeUp)
        {
            GameObject.FindGameObjectWithTag("ItemPopupSound").GetComponent<AudioSource>().Play();
            initiateObject(mushroomLifeUp);
        }
        else if (fire != null)
        {
            GameObject.FindGameObjectWithTag("ItemPopupSound").GetComponent<AudioSource>().Play();
            initiateObject(fire);
        }
        else if (star != null)
        {
            GameObject.FindGameObjectWithTag("ItemPopupSound").GetComponent<AudioSource>().Play();
            initiateObject(QuestionBlockItems.GetItemPrefab(itemType));
        }
        else if (coin != null)
        {
            coinsCount--;
            disable = coinsCount == 0;
            initiateObject(coin);
        }


        if (disable)
        {
            gameObject.SetActive(false);
            if (block != null)
            {
                Instantiate(block, transform.position, Quaternion.identity);
            }
        }
    }
}