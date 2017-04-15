using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponItem : ItemGet {

    protected WeaponCollect weaponBool;

    
  protected override void OnTriggerEnter2D (Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        if(col.tag == "Player")
        {

            ChangeItemBool();

            Destroy(gameObject);
        }


    }

    protected virtual void ChangeItemBool()
    {

    }

 protected  override  void Awake()
    {
        base.Awake();
        weaponBool = GameObject.Find("Player").GetComponent<WeaponCollect>();

    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
