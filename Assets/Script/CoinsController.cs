﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour  
{

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        player.takeCoins(1);
    }

}
