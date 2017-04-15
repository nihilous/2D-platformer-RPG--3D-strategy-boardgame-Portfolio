using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THSUsing : EquipmentUsing {

   static public int thsSI;
    public override void ItemUse(int i)
    {

        
        ItemBagList.itemBagStuffList[i].ItemPic = SwapMethodCaller.SwordWeaponChange();
        ChatBoxController chatCon = GameObject.Find("Player").GetComponent<ChatBoxController>();
        
        if (thsSI == 0)
        {
            Debug.Log(0);
            thsSI++;
            ItemBagList.itemBagStuffList[i].ItemNameProp = ItemDictionary.ItemDic["THSword"];
          chatCon.StartCoroutine(chatCon.ChatBoxOpener("좋은대화수단이지!"));
        }
        else if (thsSI == 1)
        {

            Debug.Log(1);
            thsSI--;

            ItemBagList.itemBagStuffList[i].ItemNameProp = ItemDictionary.ItemDic["UTHSword"];
            chatCon.StartCoroutine(chatCon.ChatBoxOpener("왜...?"));
        }
        
        methodCaller.WhatIsInBag();
        Debug.Log("실행됬니?");
    }

    protected override void Awake()
    {
        base.Awake();
    }

    // Use this for initialization
    void Start () {
        thsSI = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
