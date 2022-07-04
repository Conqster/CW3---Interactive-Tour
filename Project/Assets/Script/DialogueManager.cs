using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractiveTour;

public class DialogueManager : MonoBehaviour
{



    [SerializeField] private GameObject[] playerDialogue;




    private void Start()
    {
        //dialogue = new List<GameObject>();
        //dialogue = gameObject.FindGameObjectsWithTag("Options");
        playerDialogue = GameObject.FindGameObjectsWithTag("Options");
        //shit = gameObject.FindGameObjectsWithTag("Options");
    }



    private void Update()
    {
        
    }

}
