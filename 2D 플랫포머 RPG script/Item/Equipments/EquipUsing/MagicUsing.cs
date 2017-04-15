using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicUsing : EquipmentUsing
{
    static public int magicSI;

    public override void ItemUse(int i)
    {
        ItemBagList.itemBagStuffList[i].ItemPic = SwapMethodCaller.MagicWeaponChange();
        ChatBoxController chatCon = GameObject.Find("Player").GetComponent<ChatBoxController>();

        if (magicSI == 0)
        {
            Debug.Log(0);
            magicSI++;
            ItemBagList.itemBagStuffList[i].ItemNameProp = ItemDictionary.ItemDic["MagicStaff"];
            chatCon.StartCoroutine(chatCon.ChatBoxOpener("닝겐노지팡이와 튼튼데스"));
        }
        else if (magicSI == 1)
        {

            Debug.Log(1);
            magicSI--;

            ItemBagList.itemBagStuffList[i].ItemNameProp = ItemDictionary.ItemDic["UMagicStaff"];
            chatCon.StartCoroutine(chatCon.ChatBoxOpener("하드모드?.."));
        }

        methodCaller.WhatIsInBag();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    // Use this for initialization
    void Start () {
        magicSI = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
