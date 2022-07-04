using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float xDir, yDir, zDir;
    [SerializeField, Range(0f,2f)] private float moveSpeed = 3f, rotSpeed = 3f;

    private float yaw;

    Rigidbody playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerInput();

        //print(yaw);
    }



    private void PlayerInput()
    {
        xDir = Input.GetAxis("Horizontal");
        zDir = Input.GetAxis("Vertical");
        yDir = 0f;

        yaw = Input.GetAxis("Right Stick X");

    }

    private void FixedUpdate()
    {
        //playerRb.velocity = new Vector3 (xDir,yDir,zDir) * moveSpeed;

        transform.Translate(new Vector3(xDir * moveSpeed, yDir * moveSpeed, zDir * moveSpeed));

        transform.Rotate(0,yaw * rotSpeed, 0) ;
    }
 
}