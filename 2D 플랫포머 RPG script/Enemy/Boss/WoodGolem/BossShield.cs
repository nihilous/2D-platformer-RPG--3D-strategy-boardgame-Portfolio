using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShield : MonoBehaviour {

    GameObject shieldBlockPrefab;
    Transform prefabGenPosition;
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag== "PlayerBullet")
        {
            Destroy(col.gameObject);
        }
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
