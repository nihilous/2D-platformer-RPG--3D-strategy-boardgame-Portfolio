using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemPickUp : MonoBehaviour {

    MoneyInfo moneyPickup;

    protected virtual void Awake()
    {
        moneyPickup = GetComponent<MoneyInfo>();
    }

   void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Gold")
        {
      GoldItem PickUpGold   =   col.GetComponentInChildren<GoldItem>();

            Debug.Log(PickUpGold.dropGold);

      MoneyInfo.plusGold(PickUpGold.dropGold);

            Debug.Log(MoneyInfo.gold);

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
