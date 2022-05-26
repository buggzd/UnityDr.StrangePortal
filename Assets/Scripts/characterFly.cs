
using UnityEngine;
using System.Collections;

public class characterFly : MonoBehaviour
{
    [Header("�ƶ�")]
    [Tooltip("�ƶ��ٶ�")]
    public float speed = 6.0F;
    [Tooltip("��Ծ�ٶ�")]
    public float jumpSpeed = 8.0F;
    [Tooltip("����ϵ��")]
    public float gravity = 0F;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {

    }
  
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
            if (Input.GetButton("Down"))
                moveDirection.y = -jumpSpeed;
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
 

