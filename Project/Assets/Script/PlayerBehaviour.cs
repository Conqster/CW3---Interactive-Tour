using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractiveTour;

public class PlayerBehaviour : States
{
    private float xDir, yDir, zDir;
    [SerializeField, Range(0f, 2f)] private float moveSpeed = 3f, rotSpeed = 3f;

    //[SerializeField] private GameState state;
    //private GameBehaviour gameBehaviour;

    private float yaw;

    Rigidbody playerRb;
    PlayerInventory _inventory;  

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        _inventory = GetComponent<PlayerInventory>();   
       //gameBehaviour = GetComponent<GameBehaviour>();
        //state = gameBehaviour.gameState;

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

        if(Input.GetKeyDown(KeyCode.I))
        {
            _inventory.iDCard = true;
        }


        //switch(gameState)
        //{
        //    case GameState.Explore:
        //        xDir = Input.GetAxis("Horizontal");
        //        zDir = Input.GetAxis("Vertical");
        //        yDir = 0f;

        //        yaw = Input.GetAxis("Right Stick X");
        //        break;
        //    case GameState.Dialogue:
        //        xDir = 0f;
        //        zDir = 0f;
        //        yDir = 0f;
        //        break;
        //}

    }

    private void FixedUpdate()
    {
        //playerRb.velocity = new Vector3 (xDir,yDir,zDir) * moveSpeed;

        transform.Translate(new Vector3(xDir * moveSpeed, yDir * moveSpeed, zDir * moveSpeed));

        transform.Rotate(0, yaw * rotSpeed, 0);
    }

}
