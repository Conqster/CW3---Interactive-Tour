using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //Contains ID card, Coins 

    [SerializeField] private int coins;
    public bool iDCard;

    public bool IDCard()
    {
        return iDCard;
    }




    public int GetCoins()
    {
        return coins;
    }


    public void AddCoins()
    {

    }



}
