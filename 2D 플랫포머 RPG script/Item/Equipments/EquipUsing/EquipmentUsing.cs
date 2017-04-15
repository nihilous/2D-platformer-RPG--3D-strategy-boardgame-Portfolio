using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;

public class EquipmentUsing : ItemUsing
{

    public SpriteMesh[] EquipmentSM;
    protected THSWeaponSwap SwapMethodCaller;

    public override void ItemUse(int i)
    {
        //        ItemBagList.itemBagStuffList[i].ItemNameProp;
        //      ItemBagList.itemBagStuffList[i].ItemPic;

    }

    protected override void Awake()
    {
        base.Awake();
        SwapMethodCaller = GameObject.Find("Player").GetComponent<THSWeaponSwap>();
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
