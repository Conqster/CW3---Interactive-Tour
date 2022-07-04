using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractiveTour;


    [ExecuteAlways]
    public class DialogueTextDebug : MonoBehaviour
    {

        private float width;
        private float height;

        private RectTransform _TextTrans;

        [SerializeField] private Colour colour;
        private Color _myColour;



        private void Start()
        {
            _TextTrans = GetComponent<RectTransform>();
        }


        private void Update()
        {
            width = _TextTrans.rect.width;
            height = _TextTrans.rect.height;

            ReturnColour();
        }


        private void ReturnColour()
        {

            switch(colour)
            {
                case Colour.Black:
                    _myColour = Color.black;
                    break;
                case Colour.Red:
                    _myColour = Color.red;
                    break;
                case Colour.Blue:
                    _myColour = Color.blue;
                    break;
                case Colour.White:
                    _myColour = Color.white;
                    break;
            }
        }

        private void OnDrawGizmos()
        {

            Gizmos.color = _myColour;
            Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));

        }
    }

