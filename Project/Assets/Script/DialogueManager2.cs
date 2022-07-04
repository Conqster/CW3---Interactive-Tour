using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractiveTour;
using TMPro;
using UnityEngine.UI;

public class DialogueManager2 : MonoBehaviour
{



    private GameObject[] playerDialogue;

    [SerializeField] private GameObject playerDial1;
    [SerializeField] private GameObject playerDial2;
    [SerializeField] private GameObject playerDial3;


    private string[] dialogues, response;
    private int  number;
    private GameObject _Question, _Answer;


    [SerializeField] private TextMeshProUGUI answerOut;
    [SerializeField] private TextMeshProUGUI questionOut;


    public bool noMoreQuestions;



    private void Start()
    {

        _Question = GameObject.Find("Question");
        _Answer = GameObject.Find("Answer");

        //DisableAll();

        playerDialogue = new GameObject[]
        {
            playerDial1,
            playerDial2,
            playerDial3,
        };

        dialogues = new string[]
        {
            "What is this room?",
            "What are the opening times?",
            "What modules are taught here?",
        };


        response = new string[]
        {
            "The is the Game and Digital Lab where most studends will have thier practical sessions.",
            "The labs open from 9am to 9pm Monday to Thursday," +
            " 9am to 7pm Friday and " +
            "10am to 4pm Saturday and Sunday.",
            "Games Development, Virtual Reality, Modelling and Animation," +
            " Programming and Digtal Media Development modules use this room.",
        };

        //foreach (GameObject options in playerDialogue)
        //{
        //    dialogues = options.name;
        //}

    }



    private void Update()
    {
        PlayerChoose();
        Invoke("AllQueAsk", 5);   // almost twice as long with the lecturer response
    }


    private void AllQueAsk()
    {
        if(playerDial1 == null && playerDial2 == null && playerDial3 == null)
        {
            noMoreQuestions = true; 
        }
        else
        {
            noMoreQuestions = false;
        }
    }



    private void PlayerChoose()
    {
        if(playerDial1 != null)
        {
            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.Space))
            {
                Question(0);
                Destroy(playerDial1.gameObject);
            }
        }


        if (playerDial2 != null)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.Space))
            {
                Question(1);
                Destroy(playerDial2.gameObject);
            }
        }


        if(playerDial3 != null)
        {
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.Space))
            {
                Question(2);
                Destroy(playerDial3.gameObject);
            }
        }
    }



    private void Question(int value)
    {
        DisableObj(_Answer);
        ActivateObj(_Question);
        questionOut.text = dialogues[value];
        number = value;
        Invoke("Answer", 3);
    }

    private void Answer()
    {
        DisableObj(_Question);
        ActivateObj(_Answer);
        answerOut.text = response[number];
    }


    private void DisableAll()
    {
        if(_Question != null && _Answer != null)
        {
            _Question.SetActive(false);
            _Answer.SetActive(false);
        }
    }

    private void ActivateObj(GameObject obj)
    {
        obj.SetActive(true);
    }

    private void DisableObj(GameObject obj)
    {
            obj.SetActive(false);
    }

}
