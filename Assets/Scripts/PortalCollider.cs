using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollider : MonoBehaviour
{
    public Transform Portal;
    public Transform OtherPortal;

    public Transform player;
    private bool teleport=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void LateUpdate()
    {
        if (teleport)
        {
            Vector3 portalToPlayer = player.position-Portal.position;
          
            //如果走到背面点积为负数
            if (Vector3.Dot(Portal.up, portalToPlayer) < 0f)
            {

                float rotationDiff=-Quaternion.Angle(Portal.rotation,OtherPortal.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up,rotationDiff);
                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = OtherPortal.position + positionOffset;
                Debug.Log(player.position);
                teleport = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.tag == "Player") {
            teleport = true;
        }
        if (other.tag == "ball")
        {
            teleport = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            teleport = false;
        }
        if (other.tag == "ball")
        {
            teleport = false;
        }
    }
}
