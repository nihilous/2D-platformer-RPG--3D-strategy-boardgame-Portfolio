using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIBagPannelList : MonoBehaviour {

    public Text bagCapacity;
    public Text[] itemName = new Text[12];
    public Text[] itemQtt = new Text[12];

    public Image[] itemInBag = new Image[12];



    // 아이템 쓸때, 먹을때 불러오면됨?
    public  void WhatIsInBag()
    {
        bagCapacity.text = "소지한계 " + ItemBagList.itemBagStuffList.Count.ToString() + " / 12";
        if (ItemBagList.itemBagStuffList != null)
        {

            for (int i = 0; i < ItemBagList.itemBagStuffList.Count; i++)
            {
            
               itemName[i].text = ItemBagList.itemBagStuffList[i].ItemNameProp.ToString();
                itemQtt[i].text = ItemBagList.itemBagStuffList[i].ItemQttProp.ToString();

                itemInBag[i].sprite = ItemBagList.itemBagStuffList[i].ItemPic;
                if(itemInBag[i] != null)
                {
                    itemInBag[i].color = new Color(1f, 1f, 1f, 1f);
                }

                    itemName[i+1].text = null;
                    itemQtt[i+1].text = null;
                    itemInBag[i+1].sprite = null;
                    itemInBag[i+1].color = new Color(1f, 1f, 1f, 0.117f);

            }
        }
       if (ItemBagList.itemBagStuffList.Count == 0)
        {
            itemName[0].text = null;
            itemQtt[0].text = null;
            itemInBag[0].sprite = null;
            itemInBag[0].color = new Color(1f, 1f, 1f, 0.117f);
        }

        }

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
     //   WhatIsInBag();
	}
}
