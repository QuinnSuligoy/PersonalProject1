﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public GameObject Lazer;
    public bool CanSee;
    public GameObject Blaster;
    public  int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        CanSee = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Turn The Blaster
        if(CanSee == true)
        {
            Blaster.transform.LookAt(Player.transform.position);
            InvokeRepeating("Fire", 1f, 5f);
        }
        else
        {
            CancelInvoke();
        }
    }
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            CanSee = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            CanSee = false;
        }
    }

    private void Fire()
    {
        Instantiate(Lazer, transform.position, Blaster.transform.rotation);
    }
}
