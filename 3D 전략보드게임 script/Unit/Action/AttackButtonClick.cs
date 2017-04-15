using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButtonClick : MonoBehaviour {

    public UnitStatus attackInfo;
    public Summon checker;
    public List<GameObject> attackSubject = new List<GameObject>();
    public TileUnitList tempTUL;

    public int tileCount;
    public int tempPlusNum;
    public int tempMinusNum;
    public int tempNowTile;


    // 이부분을 int 값 받는 메소드로 만든다면?? attack range대신에 스킬에관해서도 range 적용가능
    public void AttackListSet()
    {
        
        if (attackSubject.Count != 0)
        {
     //       Debug.Log(attackSubject.Count + "지우기전 공격대상수");
            attackSubject.RemoveRange(0, attackSubject.Count);
     //       Debug.Log(attackSubject.Count + "지우고나서 공격대상수");
        }
        
        tempTUL = GameObject.Find("TileGenPos" + attackInfo.nowTile).GetComponent<TileUnitList>();  // 현재타일 검색
        for (int i = 0; i < tempTUL.thisTileUnitList.Count; i++)
        {   // 적군이면 담음

            if (checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().whosUnit != tempTUL.thisTileUnitList[i].GetComponent<UnitStatus>().whosUnit)
            {

                attackSubject.Add(tempTUL.thisTileUnitList[i]);
            }
        }

        tempNowTile = attackInfo.nowTile - 1;   // 해당타일 제외하고, -타일들검색

        for (int i = 1; i <= attackInfo.AttackRange; tempNowTile--) // 1부터 최대 레인지까지
                {

                    if (tempNowTile == -1)
                    {
                        tempNowTile = 47;
 
                    }
            tempTUL = GameObject.Find("TileGenPos" + tempNowTile).GetComponent<TileUnitList>();
            for (int j = 0; j < tempTUL.thisTileUnitList.Count; j++)
            {   // 적군이면 담음
                if (checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().whosUnit != tempTUL.thisTileUnitList[j].GetComponent<UnitStatus>().whosUnit)
                {

                    attackSubject.Add(tempTUL.thisTileUnitList[j]);
                }
            }

            i++;
                }
                tempNowTile = attackInfo.nowTile + 1;   // 해당타일 제외하고, +타일들검색

                for (int i = 1; i <= attackInfo.AttackRange; tempNowTile++) // 1부터 최대 레인지까지
                {
            if (tempNowTile == 48)
                    {
                        tempNowTile = 0;
                    }
                    tempTUL = GameObject.Find("TileGenPos" + tempNowTile).GetComponent<TileUnitList>();
                    for (int j = 0; j < tempTUL.thisTileUnitList.Count; j++)
                      {   // 적군이면 담음
                         if (checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().whosUnit != tempTUL.thisTileUnitList[j].GetComponent<UnitStatus>().whosUnit)
                           {

                    attackSubject.Add(tempTUL.thisTileUnitList[j]);
                           }
                      }
                    i++;
                }
                
    }



    public void OnAttackButtonClick()
    {
        if (!checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().hadAction)
            {

            attackInfo = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>();
            switch (attackInfo.unitType)
             {


            case UnitStatus.UnitType.BasicMelee:
            
                AttackListSet();
                break;
            case UnitStatus.UnitType.EliteMelee:
            
                AttackListSet();
                break;
            case UnitStatus.UnitType.BasicRange:
           
                AttackListSet();
                break;
            case UnitStatus.UnitType.EliteRange:
         
                AttackListSet();
                break;
            case UnitStatus.UnitType.BasicMagic:
            
                AttackListSet();
                break;
            case UnitStatus.UnitType.EliteMagic:
               
                AttackListSet();
                break;
            case UnitStatus.UnitType.Champion:

                AttackListSet();
                break;
            case UnitStatus.UnitType.Master:
              
                AttackListSet();
                break;
        }
    }
    }

   


    // Use this for initialization
    void Start () {
    checker = GameObject.Find("SummonButton").GetComponent<Summon>();
}
	
	// Update is called once per frame
	void Update () {
		
	}
}
