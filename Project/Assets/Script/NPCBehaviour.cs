using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPCBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject idlePosition;
    private Transform idleLocation;
    public bool moveToIdle;
    [SerializeField, Range(0f,10f)] private float movementSpeed;
    [SerializeField, Range(5f, 100f)] private float rotSpeed;   

    private Rigidbody m_Rb;
    private Vector3 m_rayHit;
    private Collider m_rayHitCollider;
    private Collider idleLocationCollider;
    [SerializeField, Range(0f, 10f)] private float playerInRange;

    private int layerMask = 1 << 6;


    private void Start()
    {
        idleLocation = idlePosition.transform;
        idleLocationCollider = idleLocation.GetComponent<Collider>();
        m_Rb = GetComponent<Rigidbody>();
    }



    private void Update()
    {
        CheckNPCLocation();

        //print(Math.Sqrt(4));
    }

    private void FixedUpdate()
    {
        DoRayCast();
        MoveToIdleLocation();
    }


    private void CheckNPCLocation()
    {
        if(idleLocation != null)
        {
            IsNPCClose();
        }
    }


    private void IsNPCClose()
    {

        float DirX = Mathf.Abs(idleLocation.transform.position.x - transform.position.x);
        float DirZ = Mathf.Abs(idleLocation.transform.position.z - transform.position.z);

        //Debug.Log("distance on X: " + DirX + "distance on Z: " + DirZ);
        if(DirX <= playerInRange && DirZ <= playerInRange)
        {
            moveToIdle = false;
        }


    }

    private void DoRayCast()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            m_rayHit = hit.transform.position;
            m_rayHitCollider = hit.collider;
        }
        //print(hit.collider);

    }



    private void MoveToIdleLocation()
    {
        if(moveToIdle)
        {
            Vector3 changePos = Vector3.Lerp(transform.position, idleLocation.transform.position, Time.deltaTime);

            //float distanceX = Mathf.Abs(idleLocation.transform.position.x - transform.position.x);
            //float distanceZ = Mathf.Abs(idleLocation.transform.position.z - transform.position.z);

            //double diagonalDis = Mathf.Sqrt((distanceX * distanceX) + (distanceZ * distanceZ));
            /////Vector3 changePos = new Vector3(((float)diagonalDis, 0f, (float)diagonalDis) * Time.deltaTime);
            ////Vector3 changePos = Vector3.Lerp(transform.position)
            //float lerpDis = Mathf.Lerp(0,(float)diagonalDis , 3);  
            //print(lerpDis); 

            //if(m_rayHit  == idleLocation.transform.position)
            if(m_rayHitCollider == idleLocationCollider)
                // might want to change the logic to confirm collider hit not position 
            {
                m_Rb.velocity = transform.forward * Mathf.Abs(changePos.z + changePos.x);

                //m_Rb.velocity = transform.forward * (float)lerpDis * Time.deltaTime;
            }
            else
            {
                transform.Rotate(new Vector3(0f,1f,0f), rotSpeed * Time.deltaTime);
            }

        }
    }


    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.yellow;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, m_rayHit);

        idleLocation = idlePosition.transform;
        
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(idleLocation.transform.position, playerInRange);
    }
}
