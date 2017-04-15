using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptTileObj : MonoBehaviour {
    public int tileNum;
 
    private TileType thisTileType;
    public TileUnitList tUL;

    public GameObject[] playerSymbols;
    void OnTriggerEnter (Collider col)
    {

      //  Debug.Log(tileNum + "타일번호" + "     "+ Move.destNum + "목적지번호");
      
        if (col.tag == "UNIT" && col.GetComponent<UnitStatus>().newBorn)// 새로만든 유닛일경우 ( 처음 마스터랑, 새로 소환한유닛)
        {

                tUL.thisTileUnitList.Add(col.gameObject);           // 이동시키면 바로 해제하면됨
        }
        else if (col.tag == "UNIT" && tileNum == col.GetComponent<UnitStatus>().nowTile)
        {

            tUL.thisTileUnitList.Add(col.gameObject);


            Animator[] moveController = col.gameObject.GetComponentsInChildren<Animator>();


            for (int i = 0; i < moveController.Length; i++)
            {
                Debug.Log(col.name + "무브펄스");
                if (moveController[i].GetBool("Move"))
                { 
                moveController[i].SetBool("Move", false);
                }
            }
            
        }
    }
  
    void OnTriggerExit (Collider col)
    {
       
        if ( tUL.thisTileUnitList.Count >= 1)
        {
            for (int i = 0; i < tUL.thisTileUnitList.Count; i++)
            {
                if (tUL.thisTileUnitList[i] == col.gameObject)
                {
                    tUL.thisTileUnitList.Remove(tUL.thisTileUnitList[i]);
                }
            }


        }

    }


	// Use this for initialization

        void Awake()
    {
        
    }
	void Start () {
        tUL = GameObject.Find("TileGenPos" + tileNum.ToString()).GetComponent<TileUnitList>();
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
