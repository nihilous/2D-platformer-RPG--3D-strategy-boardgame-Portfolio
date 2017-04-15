using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefBuffTile : MonoBehaviour {
    UnitStatus tUS;
    TileType tTT;

    void OnTriggerEnter(Collider col)
    {
        tUS = col.gameObject.GetComponent<UnitStatus>();
        if ((int)tUS.whosUnit == (int)tTT.thisTileOwner && tUS.nowTile == tTT.tileNum)
        {
            switch (tUS.unitType)
            {

                case UnitStatus.UnitType.BasicMelee:
                case UnitStatus.UnitType.BasicRange:
                case UnitStatus.UnitType.BasicMagic:
                    tUS.defPoint = (int)Mathf.Ceil(tUS.defPoint * 3.0f);
                    tUS.defBPProp += 5;
                    break;
                case UnitStatus.UnitType.EliteMelee:
                case UnitStatus.UnitType.EliteRange:
                case UnitStatus.UnitType.EliteMagic:
                    tUS.defPoint = (int)Mathf.Ceil(tUS.defPoint * 2.5f);
                    tUS.defBPProp += 4;
                    break;
                case UnitStatus.UnitType.Champion:
                case UnitStatus.UnitType.Master:
                    tUS.defPoint = (int)Mathf.Ceil(tUS.defPoint * 2.0f);
                    tUS.defBPProp += 3;
                    break;
            }





        }



    }

    // Use this for initialization
    void Start()
    {
        tTT = gameObject.GetComponent<TileType>();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
