using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_CC : MonoBehaviour
{
    public float speed;
    public float gravity;

    float xRotate, yRotate, xRotateMove, yRotateMove;
    float rotateSpeed = 800f;

    CharacterController cc;
    Vector3 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        gravity = 20f;

        moveDir = Vector3.zero;
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        FirstView();

        if(cc.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            moveDir = transform.TransformDirection(moveDir);

            moveDir *= speed;
        }

        moveDir.y -= gravity * Time.deltaTime;

        cc.Move(moveDir * Time.deltaTime);
    }

    void FirstView()
    {
        if (Input.GetMouseButton(1))
        {
            xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;

            yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;

            yRotate = yRotate + yRotateMove;
            xRotate = xRotate + xRotateMove;

            xRotate = Mathf.Clamp(xRotate, -90, 90);

            Quaternion quat = Quaternion.Euler(new Vector3(xRotate, yRotate, 0));
            transform.rotation = Quaternion.Slerp(transform.rotation, quat, Time.deltaTime);
        }
        
    }
}
