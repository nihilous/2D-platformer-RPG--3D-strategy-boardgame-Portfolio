using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DragonHeartUsing : ItemUsing {

    public override void ItemUse(int i)
    {

        if (ItemBagList.itemBagStuffList[i].ItemQttProp >= 1)
        {
            ChatBoxController chatCon = GameObject.Find("Player").GetComponent<ChatBoxController>();
            chatCon.StartCoroutine(chatCon.ChatBoxOpener("마! 내가이겼으! \n 살아있네!" ));

            EndSceneLoader endSceneLoad = GameObject.Find("EndSceneLoader").GetComponent<EndSceneLoader>();
            endSceneLoad.StartCoroutine(endSceneLoad.EndSceneLoaderCoroutine());



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
