using UnityEngine;
using Valve.VR.Extras;

public class LevelComplete : MonoBehaviour
{
    public GameObject laserPointerHand;

    private SteamVR_LaserPointer laserPointerScript;
    // Start is called before the first frame update
    void Start()
    {
        laserPointerScript = laserPointerHand.GetComponent<SteamVR_LaserPointer>();
        laserPointerScript.enabled = true;
    }
}
