using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBuffTile : MonoBehaviour {

    UnitStatus tUS;
    TileType tTT;

    void OnTriggerEnter(Collider col)
    {
        tUS = col.gameObject.GetComponent<UnitStatus>();
        if ((int)tUS.whosUnit == (int)tTT.thisTileOwner && tUS.nowTile == tTT.tileNum)
        {
            if(tUS.dices == tUS.maxDices)
            {
                tUS.diceBPProp += 3;
                return;
            }
            else if(tUS.dices < tUS.maxDices)
            {
                tUS.dices = tUS.maxDices;
                tUS.diceBPProp += 3;
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
