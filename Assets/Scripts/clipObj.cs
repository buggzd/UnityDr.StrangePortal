using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clipObj : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Portal;
    public Material mat;
    void Start()
    {
        mat.SetVector("_PortalPos_WS", Portal.position);
        mat.SetVector("_PortalForward_WS", Portal.forward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
