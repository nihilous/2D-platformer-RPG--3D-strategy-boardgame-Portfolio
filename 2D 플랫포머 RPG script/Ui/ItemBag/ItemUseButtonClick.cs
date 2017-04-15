using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemUseButtonClick : MonoBehaviour {

    public Button[] useButtons;


    public void OnUsingButtonClick()
    {
        if (PlayerDamage.deathInteract == true)
        { 
        for (int i = 0; i < ItemBagList.itemBagStuffList.Count; i++)
        {
          Button clickedButton =  gameObject.GetComponent<Button>();

            if (clickedButton == useButtons[i])
            {
                Debug.Log("뭐라고말좀해봐");

                ItemBagList.itemBagStuffList[i].ItemUseProp.ItemUse(i);           

            }
        }
        }

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
