using UnityEngine;

public class BrickExplosion : MonoBehaviour
{
    public float explosionForce = 70f;
    public float explosionRadius = 3f;
    public float explosionUpward = 0.3f;
    public Material brickMaterial;
    public GameObject brickPrefab;
    private AudioSource brickExplosion;

    public float brickMass = 0.2f;
    private float brickSize = 0.5f;
    public int bricksPerRow = 3;
    float bricksPivotDistance;
    Vector3 bricksPivot;

     void Start() {
        //pivot distance
        bricksPivotDistance = brickSize * bricksPerRow / 2;
        //create pivot vector
        bricksPivot = new Vector3(bricksPivotDistance, bricksPivotDistance, bricksPivotDistance);
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("PlayerHead"))
        {
            explode();
            ChangeUi.scoreInc("Brick");
        }
    }
    
    void explode() {
        GameObject.FindGameObjectWithTag("BrickExplosion").GetComponent<AudioSource>().Play();
        //make brick block disappear
        gameObject.SetActive(false);
        //create single bricks
        for (int x = 0; x < bricksPerRow; x++) {
            for (int y = 0; y < bricksPerRow; y++) {
                for (int z = 0; z < bricksPerRow; z++) {
                    createBrick(x, y, z);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders) {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null) {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

    }

    void createBrick(int x, int y, int z) {
        GameObject brick;
        brick  = Instantiate(brickPrefab, new Vector3(0,0,0), Quaternion.identity) as GameObject;
        brick.transform.position = transform.position + new Vector3(brickSize * x, brickSize * y, brickSize * z) - bricksPivot;
  
        brick.AddComponent<Rigidbody>();
        brick.GetComponent<Rigidbody>().mass = brickMass;

        brick.GetComponent<Renderer>().material = brickMaterial;
        brick.AddComponent<BoxCollider>();

    }

}
