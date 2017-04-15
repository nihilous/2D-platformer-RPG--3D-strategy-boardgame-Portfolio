using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNameQtt
{
    
    private string itemName;
    
    
    public string ItemNameProp
    {
        get { return itemName; }
        set
        {

            // 리스트 사이즈만큼 돌아가는데
            Debug.Log(ItemBagList.itemBagStuffList.Count);
            Debug.Log(value);
            for (int i = 0; i < ItemBagList.itemBagStuffList.Count; i++)
            {

                // 같은아이템이름 중복이있으면 걸러줌, 아이템이름이 정해져있으면 변경불가
                if(itemName==null)         //ItemBagList.itemBagStuffList[i].ItemNameProp != value && itemName == null)
                { 
                itemName = value;
                }
                else
                {
                  if(  value == ItemDictionary.ItemDic["UTHSword"])
                    itemName = value;
                    else if (value == ItemDictionary.ItemDic["THSword"])
                    itemName = value;
                    if (value == ItemDictionary.ItemDic["UMagicStaff"])
                        itemName = value;
                    else if (value == ItemDictionary.ItemDic["MagicStaff"])
                        itemName = value;


                }

            }
            
        }
    }
    private int itemQtt;

    public int ItemQttProp
    {
        get { return itemQtt; }

        set {

            // 아이템이름이 정상적으로 들어갔을때만 동작하고 벨류는 항상 0이상이여야함
            if (itemName!=null || value > 0)
            { 
            itemQtt = value;
            }
            else
            {
   
            }
        }
    }

    private Sprite itemPic;

    public Sprite ItemPic
    {
        get { return itemPic; }
        set
        {
            if (itemName != null || itemQtt > 0)
            {
                itemPic = value;
            }
        }
    }

    private ItemUsing ItemUse;

    public ItemUsing ItemUseProp
    {
        get { return ItemUse; }
        set {
            if (itemName != null || itemQtt > 0)
            {
                ItemUse = value;
            }
        }
    }

}

public class ItemBagList : MonoBehaviour {


    

 public static List<ItemNameQtt> itemBagStuffList = new List<ItemNameQtt>();

   



    // Use this for initialization
    void Start() {


 
    }

    // Update is called once per frame
    void Update () {
		
	}
}
