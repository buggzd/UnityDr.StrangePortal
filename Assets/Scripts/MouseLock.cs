using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    [Header("�ӽ��ƶ�")]
    [Tooltip("�����ƶ��ٶ�")]
    //��Ұת���ٶ�
    public  float speedX = 10f;
    [Tooltip("�����ƶ��ٶ�")]
    public float speedY = 10f;
    //���¹۲췶Χ
    float minY = -60;
    float maxY = 60;
    //�۲�仯��
    float rotationX;
    float rotationY;
    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * speedX;
        rotationY += Input.GetAxis("Mouse Y") * speedY;
        if (rotationX < 0)
        {
            rotationX += 360;
        }
        if (rotationX > 360)
        {
            rotationX -= 360;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState= CursorLockMode.None;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState=CursorLockMode.Locked;
        }
       
        rotationY = Mathf.Clamp(rotationY, minY, maxY);
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
}
