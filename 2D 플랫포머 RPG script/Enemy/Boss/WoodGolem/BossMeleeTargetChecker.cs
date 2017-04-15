using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeTargetChecker : MonoBehaviour {

   public BossMeleeAttack attackBegin;


    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player")
        {
            attackBegin.AttackReady();
            Debug.Log("플레이어감지");
        }


    }

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
