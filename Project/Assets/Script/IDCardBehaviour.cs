using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDCardBehaviour : MonoBehaviour
{

    [SerializeField] GameObject PickPopUp;
    private GameObject _player;


    private float phaseShift = 0;
    private float x, oscillation;
    private float verticalShift;     //defines the starting point of the oscillaton and mid point of the whole value
    [SerializeField, Range(0f, 10f)] public float period = 3f, amplitude = 0.5f;     //half of the total value to oscillate from 
    [SerializeField, Range(0f, 10f)] private float RotSpeed, levitation;

    private Transform playerTrans;
    [SerializeField] private Vector2 triggerDis;
    [SerializeField] private bool playerInRange, ignoreRange;

    private Vector3 _size, _originalPos, _levitationPos;
    private bool classActive = false;

    [SerializeField, Range(0f, 10f)] private float pickRange;
    [SerializeField] private bool pickable;
    private PlayerInventory _playerinven;



    private void Start()
    {
        //playerTrans = GameObject.Find("Player").transform;
        _player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = _player.transform;
        verticalShift = transform.position.y + levitation;
        _originalPos = transform.position;
        classActive = true; 
        _levitationPos = new Vector3(transform.position.x, transform.position.y + levitation, transform.position.z);
        _playerinven = _player.GetComponent<PlayerInventory>();

        //_size = transform.localScale;
    }



    private void Update()
    {
        Oscillation();
        //print(oscillation);
        CheckPlayerInRange();
        PickUpRange();
        PlayerInput();
    }



    private void FixedUpdate()
    {
        if(playerInRange)
        {
            RotateMe();
            MoveVertical();
        }
        else
        {
            transform.position = _originalPos;
        }
    }


    private void PlayerInput()
    {
        if(pickable)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _playerinven.iDCard = true; 
                Destroy(gameObject, 0.5f);
            }
        }
    }


    private void CheckPlayerInRange()
    {

        float distX = Mathf.Abs(playerTrans.position.x - transform.position.x);
        float distZ = Mathf.Abs(playerTrans.position.z - transform.position.z);

        // Debug.Log("disX: " + distX + " distZ: " + distZ + " trigger: " + triggerDis);
        if(!ignoreRange)
        {
            if (distX < triggerDis.x && distZ < triggerDis.y)
            {
                playerInRange = true;
            }
            else
            {
                playerInRange = false;
            }
        }
        else
        {
            playerInRange = true;
        }


    }


    private void PickUpRange()
    {
        float distX = Mathf.Abs(playerTrans.position.x - transform.position.x);
        float distZ = Mathf.Abs(playerTrans.position.z - transform.position.z);



        if (distX < pickRange && distZ < pickRange)
        {
            //print("okay pick up in range");
            pickable = true;
            PickPopUp.SetActive(true);
        }
        else
        {
            pickable = false;
            PickPopUp.SetActive(false);
        }

    }



    private void RotateMe()
    {
        transform.Rotate(0, RotSpeed, 0);
    }


    private void MoveVertical()
    {
        //transform.Translate(transform.up * oscillation, Space.World);
        //transform.Translate(0,oscillation,0);
        //transform.position = new Vector3(0,oscillation,0);
        transform.position = new Vector3 (transform.position.x, oscillation, transform.position.z);
        //transform.TransformDirection(transform.up * oscillation);
        //transform.TransformPoint(transform.up * oscillation);
    }

    private void Oscillation()
    {
        x += Time.deltaTime;

        oscillation = amplitude * Mathf.Sin(((2 * Mathf.PI) / period) * (x + phaseShift)) + verticalShift;
    }
    private void OnDrawGizmos()
    {

        _size = transform.localScale;
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + levitation, transform.position.z));
        Gizmos.DrawWireCube(transform.position, new Vector3(triggerDis.x * 2f, 5f, triggerDis.y * 2f));

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pickRange);

        if(classActive)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(_levitationPos, _size);
        }
        else
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y + levitation, transform.position.z), _size);
        }

    }
}
