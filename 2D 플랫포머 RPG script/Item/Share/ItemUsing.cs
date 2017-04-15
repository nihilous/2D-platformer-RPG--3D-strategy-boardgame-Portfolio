using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUsing : MonoBehaviour {
  protected UIBagPannelList methodCaller;

    public virtual void ItemUse(int i)
    {
    
    }

   protected virtual void Awake()
    {
 methodCaller =        GameObject.Find("ButtonPanel").GetComponentInChildren<UIBagPannelList>();

        // methodCaller =        GameObject.Find("ItemsPannel").GetComponent<UIBagPannelList>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
