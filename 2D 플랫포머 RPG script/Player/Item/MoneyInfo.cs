using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyInfo : MonoBehaviour {

    public static int gold;

    public static void plusGold (int addGold )
    {
        gold += addGold;
    }
    public static void minusGold(int removeGold)
    {
        if (gold >= removeGold)
        { 
        gold -= removeGold;
        }
        else if (gold < removeGold)
        {
            Debug.Log("돈이 부족해..ㅎㅎ");
        }


    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(gold);
	}
}
