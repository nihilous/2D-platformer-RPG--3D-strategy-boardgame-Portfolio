using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HpPortionItemQUp : ItemGet {

    

 protected override    void OnTriggerEnter2D (Collider2D col)
    {

        base.OnTriggerEnter2D(col);

        if(col.tag == "Player")
        {
            methodCaller.WhatIsInBag();
           Destroy(gameObject);

        }
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
