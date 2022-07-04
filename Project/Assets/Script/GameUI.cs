using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI coinDisplay;
    [SerializeField] private TextMeshProUGUI alertDisplay;
    [SerializeField] private Image idCard;

    [SerializeField] private GameObject _alert;
    private PlayerInventory _inventory;
    [SerializeField] private bool hasID, sendingMessage, confirmMessage, useTimer;

    [SerializeField, Range(0f, 5f)] private float messageTimer;
    private float Timer;
    //private int messageCounter = 0;   



    private void Start()
    {
        _inventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        _alert = GameObject.Find("Alert");
    }

    private void Update()
    {
        UpdateCoins();
        Messaging();
        PlayerInput();

        if(useTimer)
            FinishMessaging();

        ConfirmMessage();
        UpdateIDUI();
    }


    private void PlayerInput()
    {
        confirmMessage = Input.GetKeyDown(KeyCode.Escape);
    }

    private void Messaging()
    {
        if(sendingMessage)
        {
            _alert.SetActive(true);
        }
        else
        {
            _alert.SetActive(false);
        }
    }

    private void ConfirmMessage()
    {
        if(confirmMessage)
        {
            sendingMessage = false;
        }
    }

    private void FinishMessaging()
    {
        if(sendingMessage)
        {
            //messageTimer -= Time.deltaTime;
            Timer += Time.deltaTime;
            print(Timer);
            if(Timer >= messageTimer)
            {
                Timer = 0;
                sendingMessage = false;
            }
        }
    }



    public void Alert(string message)
    {
        //alertDisplay.text = message ;
        //print("i'm been called");
        sendingMessage = true;
        alertDisplay.text = message + "\n\t\t\t okay ESC ";
    }

    private void UpdateCoins()
    {
        coinDisplay.text = _inventory.GetCoins().ToString();
    }


    private void UpdateIDUI()
    {
        //idCard.GetComponent<Image>().sprite = "Checkmark";

        hasID = _inventory.IDCard();

        if (hasID)
        {

            idCard.GetComponent<Image>().color = Color.blue;
        }
        else
        {
            idCard.GetComponent<Image>().color = Color.yellow;
        }
    }
}
