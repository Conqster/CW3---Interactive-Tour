using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractiveTour;

public class DialogueTrigger : MonoBehaviour
{

    [SerializeField, Range(2f,10f)] private float triggerZone, triggerTimer;
    [SerializeField] private GameObject DialogueSys;
    private DialogueManager2 _dialogueMan;
    [SerializeField] private bool selfDestructReady;
    [SerializeField, Range(3f, 10f)] private float selfDestructTimer = 5f;
    //private GameState gameState;
    //private GameBehaviour gameBehaviour;
    private PlayerBehaviour _player;
    private FollowCam _followCam;
    private NPCBehaviour _npc;

    [SerializeField] private Animator dialogueAnim;
    private int dialAnimHash;

    private Transform playerTrans;


    private void Start()
    {
        playerTrans = GameObject.Find("Player").transform;
        _player = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
        _followCam = GameObject.Find("Main Camera").GetComponent<FollowCam>();
        _npc = FindObjectOfType<NPCBehaviour>();    
        dialogueAnim = GameObject.Find("Placement").GetComponent<Animator>();
        _dialogueMan = DialogueSys.GetComponent<DialogueManager2>();    
        dialAnimHash = Animator.StringToHash("playerDialogue");
        dialogueAnim.enabled = false;
        //gameBehaviour = GetComponent<GameBehaviour>();
    }




    private void Update()
    {
        CheckPlayerDistance();
        selfDestructReady = _dialogueMan.noMoreQuestions;


        if (selfDestructReady)
        {
            Invoke("SelfDistruct", selfDestructTimer);
        }
        
    }

    

    private void CheckPlayerDistance()
    {
        float distX = Mathf.Abs(playerTrans.position.x - transform.position.x);
        float distZ = Mathf.Abs(playerTrans.position.z - transform.position.z);

        if(distX < triggerZone && distZ < triggerZone)
        {
            //print("i'm in");
            //_player.gameState = GameState.Dialogue;
            _followCam.enabled = false;
            dialogueAnim.enabled = true;  
            _player.enabled = false;
            dialogueAnim.SetBool(dialAnimHash, true);
            Invoke("ActivateTrigger", triggerTimer);
            //gameState = GameState.Dialogue;
        }
        else
        {
            _player.enabled = true;
        }

        //Debug.Log("disX: " + distX + " distZ: " + distZ + " trigger: " + triggerZone);

        //if(playerTrans != null)
        //{
        //    if(playerTrans)
        //}
    }

    private void SelfDistruct()
    {
        _npc.moveToIdle = true;
        _followCam.enabled = true;
        _player.enabled = true;                
        dialogueAnim.enabled = false;
        DialogueSys.SetActive(false);
        Destroy(gameObject);
    }


    private void ActivateTrigger()
    {
        DialogueSys.SetActive(true);
    }


    private void DeactivateTrigger()
    {
        DialogueSys.SetActive(false);
    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(triggerZone * 2, triggerZone * 2, triggerZone * 2));
        //Gizmos.DrawCube(transform.position, new Vector3(triggerZone * 2, triggerZone * 2, triggerZone * 2));
    }
}
