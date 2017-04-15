using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTile : MonoBehaviour {

    TestScriptTileObj allyChecker;
    TileType ownerChecker;
    UnitStatus whosUnitChecker;
    public GameObject trapFx;
    public Transform trapFxGenPos;
    // 이부분이 과연 리스트에 넣는부분 이후에 작동할것인가
   void OnTriggerEnter(Collider col)
    {
        whosUnitChecker = col.gameObject.GetComponent<UnitStatus>();

        // 타일에 주인이있고 접근한 유닛이 타일주인과 다른팩션인경우, 해당유닛의 목적지가 함정타일인경우
        if (ownerChecker.thisTileOwner != TileType.TileOwnerPvP.None && (int)ownerChecker.thisTileOwner != (int)whosUnitChecker.whosUnit && allyChecker.tileNum == whosUnitChecker.nowTile)
        {
            Instantiate(trapFx, trapFxGenPos.position, trapFxGenPos.rotation);

                // 타일에 속한유닛들을 체크해서
                for (int i = 0; i < allyChecker.tUL.thisTileUnitList.Count ; i++)
                {   
                // 적유닛인경우면
                  if((int)ownerChecker.thisTileOwner != (int)allyChecker.tUL.thisTileUnitList[i].GetComponent<UnitStatus>().whosUnit)
                   {
                    // 데미지를 20줌
                    allyChecker.tUL.thisTileUnitList[i].SendMessage("Damage", 20, SendMessageOptions.DontRequireReceiver);
                    // 유닛이 데미지받고 죽었을때의 처리를 해야함 카운터 하나 줄여야함 죽이는부분의 체크를해서
                   }

                }
        }
    }



	// Use this for initialization
	void Start () {
        allyChecker = gameObject.GetComponent<TestScriptTileObj>();
        ownerChecker = gameObject.GetComponent<TileType>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
