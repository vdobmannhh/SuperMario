using System;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    public enum ItemType
    {
        None,
        Coin,
        MushroomSizeUp,
        MushroomLifeUp,
        Fire,
        Star
    };

    [Header("Item hidden in QuestionBlock")] [Tooltip("Item to get when Player hits QuestionBlock")] [SerializeField]
    private ItemType itemType;

    [SerializeField] private int itemCount = 1;


    [Header("Item Pop Up")] [Tooltip("How Item jumps out of QuestionBlock")] [SerializeField]
    private float explosionForce = 200f;

    [SerializeField] private float explosionRadius = 3f;
    [SerializeField] private float explosionUpward = 20.0f;
    [SerializeField] private float animationSpeed = 4f;

    [Header("Prefabs")] [Tooltip("Which Prefabs to Use")] [SerializeField]
    private GameObject coin;

    [SerializeField] private GameObject mushroomSizeUp;
    [SerializeField] private GameObject mushroomLifeUp;
    [SerializeField] private GameObject fireFlower;
    [SerializeField] private GameObject star;
    [SerializeField] private GameObject block;


    private bool hitanimation = false;
    private bool up = true;
    private const float MAXHEIGHT = 0.5f;
    private float height;
    private Vector3 initialPos;


    private void OnTriggerEnter(Collider obj)
    {
        if (itemType == ItemType.None) return;

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

        initiateObject(GetItemPrefab(itemType));
        PlaySoundOfItemPopUp(itemType);

        if (itemType == ItemType.Coin)
        {
            itemCount--;
            disable = itemCount == 0;
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

    
    private void PlaySoundOfItemPopUp(ItemType type)
    {
        switch (type)
        {
            case ItemType.None:
                break;
            case ItemType.Coin:
                break;
            case ItemType.MushroomSizeUp:
            case ItemType.MushroomLifeUp:
            case ItemType.Fire:
            case ItemType.Star:
                GameObject.FindGameObjectWithTag("ItemPopupSound").GetComponent<AudioSource>().Play();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }

    private GameObject GetItemPrefab(ItemType type)
    {
        switch (type)
        {
            case ItemType.Coin:
                return coin;
            case ItemType.MushroomSizeUp:
                return mushroomSizeUp;
            case ItemType.MushroomLifeUp:
                return mushroomLifeUp;
            case ItemType.Fire:
                return fireFlower;
            case ItemType.Star:
                return star;
            case ItemType.None:
                return null;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}