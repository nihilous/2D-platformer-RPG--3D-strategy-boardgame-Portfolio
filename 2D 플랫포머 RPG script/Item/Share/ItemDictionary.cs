using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDictionary : MonoBehaviour {

   public static Dictionary<string, string> ItemDic = new Dictionary<string, string>();
    public static int dictionarySingleTone =0;


	// Use this for initialization
	void Start () {
        dictionarySingleTone++;

        if (dictionarySingleTone == 1) { 
        ItemDic.Add("HpPortion", "힐링포션");
        ItemDic.Add("MpPortion", "마나포션");
        ItemDic.Add("UTHSword", "도마뱀꼬리");
        ItemDic.Add("UMagicStaff", "간달프의것");
        ItemDic.Add("THSword", "용사의검");
        ItemDic.Add("MagicStaff", "용사의법구");
        ItemDic.Add("DragonHeart", "드래곤하트");
        ItemDic.Add("Eyes", "눈알들");
        ItemDic.Add("ZombieDust", "유해");
        }





    }

    // Update is called once per frame
    void Update () {
		
	}
}
