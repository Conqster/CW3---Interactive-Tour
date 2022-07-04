using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerBehaviour : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float interactiveDist;
    [SerializeField] private bool playerInRange, hasID;

    private int alertCounter = 0;

    private Transform playerTrans;
    private PlayerInventory _playerInventory;
    private GameUI _gameUI;



    private void Start()
    {
        playerTrans = GameObject.Find("Player").transform;
        _playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        _gameUI = FindObjectOfType<GameUI>();
        //_gameUI = GameObject.Find("Game UI").GetComponent<GameUI>();    
    }


    private void Update()
    {
        CheckPlayerInRange();
        Login();    
        //print(alertCounter);    
    }




    private void Login()
    {
        if (playerInRange)
        {
            //alertCounter = 0;

            if (_playerInventory != null)
            {
                hasID = _playerInventory.IDCard();
            }




            if(hasID)
            {
                if(alertCounter <= 0)
                {
                    alertCounter++;
                    _gameUI.Alert("Player can login");
                }
                
            }
            else
            {
                if(alertCounter <= 0)
                {
                    alertCounter++;
                    _gameUI.Alert("player needs ID");
                }
            }
        }
        else
        {
            alertCounter = 0;   
        }
    }






    private void CheckPlayerInRange()
    {

        float distX = Mathf.Abs(playerTrans.position.x - transform.position.x);
        float distZ = Mathf.Abs(playerTrans.position.z - transform.position.z);

        if (distX < interactiveDist && distZ < interactiveDist)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }


    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, new Vector3(interactiveDist * 2 , 5, interactiveDist * 2));
    }
}
