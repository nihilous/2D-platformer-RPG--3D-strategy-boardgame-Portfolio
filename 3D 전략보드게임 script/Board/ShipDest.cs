using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShipDest : MonoBehaviour {

    PiratesBayTile pbtInfo;
    public int posNum;

 void    OnTriggerEnter (Collider col)
    {
        if (pbtInfo.destNum.Count == 0)
        { 
            return;
        }
        if (col.tag == "SHIP" && posNum == pbtInfo.destNum[0] &&pbtInfo.passenger != null)
        {
         TileUnitList tempTUL =   GameObject.Find("TileGenPos" + posNum).GetComponent<TileUnitList>();
            
                GameObject tempUnit = pbtInfo.passenger;
            tempUnit.transform.parent = null;   ///   
            /*
            if (tempUnit.transform.parent != null)
            {
                tempUnit.transform.parent = tempUnit.transform.parent.parent;   // 패런츠와 수평관계로 만들어줌
            }
            */
            tempUnit.transform.position = GameObject.Find("TileGenPos" + posNum + "SubPos" + tempTUL.thisTileUnitList.Count).transform.position;
            tempUnit.GetComponent<NavMeshAgent>().enabled = true;
            tempUnit.GetComponent<UnitStatus>().nowTile = posNum;
            tempUnit.GetComponent<NavMeshAgent>().destination = GameObject.Find("TileGenPos" + posNum + "SubPos" + tempTUL.thisTileUnitList.Count).transform.position;
            pbtInfo.boardOn = false;
            pbtInfo.passenger = null;
            col.gameObject.GetComponent<NavMeshAgent>().destination = GameObject.Find("ShipDest12").transform.position;
            pbtInfo.destNum.Clear();
        }
    }

	// Use this for initialization
	void Start () {
        pbtInfo = GameObject.Find("Tile12").GetComponent<PiratesBayTile>();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
