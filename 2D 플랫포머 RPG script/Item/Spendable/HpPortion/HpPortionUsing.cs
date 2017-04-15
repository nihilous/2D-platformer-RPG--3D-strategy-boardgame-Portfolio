using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPortionUsing : ItemUsing {

    protected CharacterState hpUp;
    protected HpGageShare hpGageUP;

    public override void ItemUse(int i)
    {
       
        if (ItemBagList.itemBagStuffList[i].ItemQttProp >= 1)
        {
            PortionFxGen fxGen = GameObject.Find("Player").GetComponent<PortionFxGen>();
            fxGen.PortionFxGener(0);
            ChatBoxController chatCon = GameObject.Find("Player").GetComponent<ChatBoxController>();
            chatCon.StartCoroutine(chatCon.ChatBoxOpener("포션기모찌\n인정?"));

            PlayerAudioSource polyPlay = GameObject.Find("Player").GetComponent<PlayerAudioSource>();
            polyPlay.playPoly(7);

            float dotHealRate = hpUp._MaxHp / 100;
            if (hpUp._hp > hpUp._MaxHp)
            {

                //                hpUp._hp = hpUp._MaxHp;
                hpGageUP.HpUp(1);   // 그냥 1을 넣어주면 알아서 메소드에서 맞춰줌
                                    //     yield break; 멈출필요는 없는듯 걍 만피만 유지해주면됨 만피에서 떨어지면 이하가실행
            }
            hpUp._hp = hpUp._hp + (dotHealRate * 30);
            hpGageUP.HpUp(0.3f);




            ItemBagList.itemBagStuffList[i].ItemQttProp = ItemBagList.itemBagStuffList[i].ItemQttProp - 1;
            

            if (ItemBagList.itemBagStuffList[i].ItemQttProp ==0)
            {
                ItemBagList.itemBagStuffList.Remove(ItemBagList.itemBagStuffList[i]);
                
            }
        }

        methodCaller.WhatIsInBag();

        // 생각좀해보자
    }

    protected override void Awake()
    {
        base.Awake();
        hpUp = GameObject.Find("Player").GetComponent<CharacterState>();
        hpGageUP = GameObject.Find("Player").GetComponent<HpGageShare>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
