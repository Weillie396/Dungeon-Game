using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chest : Collectable
{

    public Sprite emptyChest;
    public int moneyAmount;
    protected override void OnCollect()
    {
        if (!collected)
        {
            moneyAmount = Random.Range(2, 10);
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.ShowText("+" + moneyAmount + " Coins!", 25, Color.green, transform.position, Vector3.up * 30, 1.5f);
            GameManager.instance.moneyTotal += moneyAmount;

        }
    }

}
