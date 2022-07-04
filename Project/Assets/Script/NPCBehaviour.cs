using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject idlePosition;
    private Transform idleLocation;
    public bool moveToIdle;
    [SerializeField, Range(0f,10f)] private float movementSpeed;


    private Rigidbody m_Rb;


    private void Start()
    {
        idleLocation = idlePosition.transform;  
        m_Rb = GetComponent<Rigidbody>();
    }



    private void Update()
    {

        CheckNPCLocation();
        MoveToIdleLocation();
    }


    private void CheckNPCLocation()
    {
        if(idleLocation != null)
        {
            if(idleLocation.transform.position == transform.position)
            {
                moveToIdle = false;
            }
        }
    }



    private void MoveToIdleLocation()
    {
        if(moveToIdle)
        {
            Vector3 changePos = Vector3.Lerp(transform.position, idleLocation.transform.position, Time.deltaTime);
            //print (changePos);
            //transform.position = changePos;

            print(changePos.z);
            m_Rb.velocity = new Vector3(0, 0, changePos.z);

        }
    }

}
