using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCam : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform PlayerCamera;
    public Transform Portal;
    public Transform OtherPortal;


    // Update is called once per frame
    void Update()
    {
        //���ƫ��
        Vector3 OffsetFromPortal=PlayerCamera.position - OtherPortal.position;
        
       
        //��ȡ����������֮��ĽǶȲ�ֵ
        //ͬ��ת��
        float angularDifference = -Quaternion.Angle( OtherPortal.rotation, Portal.rotation);
        Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDifference, Vector3.up);
        Vector3 newCamerDirection= portalRotationDifference * PlayerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCamerDirection,Vector3.up);
        //����ת��ƽ��
        Vector3 positionOffset = Quaternion.Euler(0f, angularDifference, 0f) * OffsetFromPortal;
        transform.position = positionOffset + Portal.position;

    }
}
