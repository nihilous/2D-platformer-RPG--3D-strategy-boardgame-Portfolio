using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MpPortionUsing : ItemUsing {

    //protected PlayerSkill mpUp;

   
    public override void ItemUse(int i)
    {

        if (ItemBagList.itemBagStuffList[i].ItemQttProp >= 1)
        {
            ChatBoxController chatCon = GameObject.Find("Player").GetComponent<ChatBoxController>();
            chatCon.StartCoroutine(chatCon.ChatBoxOpener("이거슨\n매직머슈룸!?"));

            PlayerSkill mpUp = GameObject.Find("Player").GetComponent<PlayerSkill>();
            PortionFxGen fxGen = GameObject.Find("Player").GetComponent<PortionFxGen>();

            PlayerAudioSource polyPlay = GameObject.Find("Player").GetComponent<PlayerAudioSource>();
            polyPlay.playPoly(7);
            mpUp.StartCoroutine(mpUp.MpPortionDOT());
            

            fxGen.PortionFxGener(1);       

            ItemBagList.itemBagStuffList[i].ItemQttProp = ItemBagList.itemBagStuffList[i].ItemQttProp - 1;

         

            if (ItemBagList.itemBagStuffList[i].ItemQttProp == 0)
           {
                ItemBagList.itemBagStuffList.Remove(ItemBagList.itemBagStuffList[i]);
               Debug.Log("바이바이");
           }
        }

        methodCaller.WhatIsInBag();

        // 생각좀해보자
        

    }


    protected override void Awake()
    {

        base.Awake();
  //      mpUp = GameObject.Find("Player").GetComponent<PlayerSkill>();
    }





    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
