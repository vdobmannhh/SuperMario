using UnityEngine;

public class RainbowColor : MonoBehaviour
{
    private Color defaultClr;
    private float hue = 0;
    private Light mainLight;
    public float speed = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        mainLight = GetComponent<Light>();
        defaultClr = mainLight.color;
    }

    // Update is called once per frame
    void Update()
    {
        mainLight.color = Color.HSVToRGB(hue, 0.55f, 1f);
        hue = hue >= 1.0f ? 0 : hue + 0.01f;
    }

    private void OnDisable()
    {
        mainLight.color = defaultClr;
    }
}
