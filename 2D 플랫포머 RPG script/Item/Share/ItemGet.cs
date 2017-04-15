using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGet : MonoBehaviour {

   protected UIBagPannelList methodCaller;
    static int bagClear = 0;
   protected virtual void Awake()
    {
        methodCaller = GameObject.Find("ButtonPanel").GetComponentInChildren <UIBagPannelList>();
    }

   protected virtual void OnTriggerEnter2D(Collider2D col)
    {


        if (col.tag == "Player")
        {
            
            
            if (ItemBagList.itemBagStuffList.Count == 0)    // 아이템 하나도 없을경우
            {
                ItemNameQtt Item = new ItemNameQtt();

                ItemBagList.itemBagStuffList.Add(Item);
                Item.ItemNameProp = ItemDictionary.ItemDic[gameObject.name];    // 이부분 딕셔너리 키로 넣고 벨류 받아오면됨
                Item.ItemQttProp = Item.ItemQttProp + 1;
                Item.ItemPic = gameObject.GetComponent<SpriteRenderer>().sprite;
                Item.ItemUseProp = gameObject.GetComponent<ItemUsing>();
                
            }

            else
            {
                ItemNameQtt Item = new ItemNameQtt();
                ItemBagList.itemBagStuffList.Add(Item);
                Item.ItemNameProp = ItemDictionary.ItemDic[gameObject.name];
                Item.ItemQttProp = Item.ItemQttProp + 1;
                Item.ItemPic = gameObject.GetComponent<SpriteRenderer>().sprite;
                Item.ItemUseProp = gameObject.GetComponent<ItemUsing>();
                string[] itemNameChecker = new string[ItemBagList.itemBagStuffList.Count];
      //          string[] itemToPut = new string[ItemBagList.itemBagStuffList.Count];
                int sameNameCounter = 0;
                int originalNameNum = 0;
                for (int i = 0; i < ItemBagList.itemBagStuffList.Count; i++)
                {
                    itemNameChecker[i] = ItemBagList.itemBagStuffList[i].ItemNameProp;

                    if (itemNameChecker[i] == ItemDictionary.ItemDic[gameObject.name])  // 아이템이 중복인경우
                    {

                        sameNameCounter++;
                        if (sameNameCounter == 1)   // 동일아이템이 있다면 db에 이미 있는걸로 간주하여 빠른인덱스를 저장함
                        {
                     
                            originalNameNum = i;
                           
                        }
                        if (sameNameCounter == 2)   // 동일한아이템이 2개이상있다면 빠른인덱스에 아이템갯수 더해주고, 인덱스에서 삭제함
                        {
                        
                            ItemBagList.itemBagStuffList[originalNameNum].ItemQttProp += ItemBagList.itemBagStuffList[i].ItemQttProp;
                  
                            ItemBagList.itemBagStuffList.Remove(ItemBagList.itemBagStuffList[i]);

                            sameNameCounter = 1;
                           
                        }
                    }

                 

                }
            }
        
    //        Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        bagClear++;
        if (bagClear==2)
        {
            methodCaller.WhatIsInBag();
            bagClear--;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
