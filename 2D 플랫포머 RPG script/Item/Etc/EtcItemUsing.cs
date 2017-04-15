using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtcItemUsing : ItemUsing {

    

    public override void ItemUse(int i)
    {

        if (ItemBagList.itemBagStuffList[i].ItemQttProp >= 1)
        {
            ChatBoxController chatCon = GameObject.Find("Player").GetComponent<ChatBoxController>();
            if (ItemBagList.itemBagStuffList[i].ItemNameProp == ItemDictionary.ItemDic["Eyes"])
            { 
                chatCon.StartCoroutine(chatCon.ChatBoxOpener("이런건 왜 떨어\n트리는거냐?"));
            }
            else if (ItemBagList.itemBagStuffList[i].ItemNameProp == ItemDictionary.ItemDic["ZombieDust"])
            {
                
                GameObject player = GameObject.Find("Player");
                player.SendMessage("Damage", 100);
                chatCon.StartCoroutine(chatCon.ChatBoxOpener("밥경찰..\n사람잡네"));
                ItemBagList.itemBagStuffList[i].ItemQttProp = ItemBagList.itemBagStuffList[i].ItemQttProp - 1;



                if (ItemBagList.itemBagStuffList[i].ItemQttProp == 0)
                {
                    ItemBagList.itemBagStuffList.Remove(ItemBagList.itemBagStuffList[i]);
                    
                }

            }
            //    SceneManager.LoadScene("");

        }

        methodCaller.WhatIsInBag();

        // 생각좀해보자
    }

    protected override void Awake()
    {
        base.Awake();

    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
