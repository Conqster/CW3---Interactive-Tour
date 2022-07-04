using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPopUp : MonoBehaviour
{

    private RectTransform m_RecTransform;
    private float m_Width, m_Height, m_yRot, camRotY;
    private Quaternion m_Rot, camRot;
    private Transform _CameraTrans;

    private void Start()
    {
        m_RecTransform = GetComponent<RectTransform>();
        _CameraTrans = GameObject.Find("Main Camera").GetComponent<Transform>();

        m_yRot = m_RecTransform.rotation.y;
        camRotY = _CameraTrans.rotation.y;    

        m_Rot = m_RecTransform.rotation;
        camRot = _CameraTrans.rotation;
    }


    private void Update()
    {
        camRotY = _CameraTrans.rotation.y;

        m_yRot = camRotY;  
    }



    private void OnDrawGizmos()
    {
        m_RecTransform = GetComponent<RectTransform>();

        if (m_RecTransform != null)
        {
            m_Width = m_RecTransform.rect.width;
            m_Height = m_RecTransform.rect.height;

            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, new Vector2(m_Width, m_Height));
        }
    }
}
