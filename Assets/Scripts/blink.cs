using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blink : MonoBehaviour
{
    // Start is called before the first frame update
   
    [Tooltip("max lightIntensity"), Range(1f, 10)]
    public float lightIntensity =5;
    [Tooltip("max lightIntensity"), Range(1f, 10)]
    public float minlightIntensity = 2;

    [Tooltip("blink times"), Range(0.001f, 5)]
    public float blinkSpeed = 0.01f;
    bool revert = true;

    float lightWeight = 0.5f;
    Light portalLight;
    void Start()
    {
        portalLight =GetComponent<Light>();
        portalLight.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("lightRevert"+revert+"LightWeight:"+lightWeight+ "LightIntensity:" + portalLight.intensity);

        if (lightWeight < 1)
        {
            if (revert)
            {
                portalLight.intensity = Mathf.Lerp(portalLight.intensity, lightIntensity, lightWeight);
            }
            else
            {
               
                portalLight.intensity = Mathf.Lerp(portalLight.intensity, minlightIntensity, lightWeight);
            }
            
            lightWeight+=Time.deltaTime* blinkSpeed;
        }
        else
        {
            revert = !revert;
            lightWeight=Random.value;
        }
        
        
    }
}
