using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkBuffTile : MonoBehaviour {

    UnitStatus tUS;
    TileType tTT;

    void OnTriggerEnter (Collider col)
    {
        tUS = col.gameObject.GetComponent<UnitStatus>();
        if((int)tUS.whosUnit == (int)tTT.thisTileOwner && tUS.nowTile == tTT.tileNum)
        {
            switch (tUS.unitType)
            {
                case UnitStatus.UnitType.Master:                   
                case UnitStatus.UnitType.BasicMelee:                   
                case UnitStatus.UnitType.BasicRange:                   
                case UnitStatus.UnitType.BasicMagic:
                    tUS.atkPoint = (int)Mathf.Ceil(tUS.atkPoint * 2.5f);
                    tUS.atkBPProp += 5;
                    break;
                case UnitStatus.UnitType.EliteMelee:
                case UnitStatus.UnitType.EliteRange:
                case UnitStatus.UnitType.EliteMagic:
                    tUS.atkPoint = (int)Mathf.Ceil(tUS.atkPoint * 1.5f);
                    tUS.atkBPProp += 4;
                    break;
                case UnitStatus.UnitType.Champion:
                    tUS.atkPoint = (int)Mathf.Ceil(tUS.atkPoint * 1.2f);
                    tUS.atkBPProp += 3;
                    break;
            }


            


        }



    }

	// Use this for initialization
	void Start () {
        tTT = gameObject.GetComponent<TileType>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
