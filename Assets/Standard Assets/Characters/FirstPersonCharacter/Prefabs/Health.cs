﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxhealth = 100;
    public int health = 100;
    public int damageAmount = 34;
    public bool damage = false;
    public Slider HealthBar;
    public GameObject Playerspawner;
    public float time;
    public bool countTime = false;

    // Use this for initialization
    void Start () {
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (countTime)
        {
            time += Time.deltaTime;
            if (time > 0.5)
            {
                health -= damageAmount;
                HealthBar.value = health;
                Playerspawner = GameObject.Find("PlayerSpawner");
                transform.position = Playerspawner.transform.position;
                countTime = false;
                time = 0;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "deadly")
        {
            
            health -= damageAmount;
            HealthBar.value = health;
            Playerspawner = GameObject.Find("PlayerSpawner");
            transform.position = Playerspawner.transform.position;
        }
        if (collision.gameObject.name == "TeleportA")
        {

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        countTime = true;
    }
}
