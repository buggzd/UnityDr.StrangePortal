using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPortalTex : MonoBehaviour
{
    public Camera cam;
    public Material PortalMat;
    // Start is called before the first frame update
    void Start()
    {
        if(cam.targetTexture != null)
        {
            cam.targetTexture.Release();
        }
        cam.targetTexture = new RenderTexture(Screen.width, Screen.height,24, RenderTextureFormat.RGB111110Float);
        PortalMat.mainTexture = cam.targetTexture;
    }

  
}
