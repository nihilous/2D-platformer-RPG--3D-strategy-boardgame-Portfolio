using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSummonButton : MonoBehaviour {

    Summon checker;
    Summon closePannel;
    public int[] startPosition;
    public void SummonUnitButtonClick()
    {
        Debug.Log(checker.manaPoint[(int)FinishButtonClick.thisTurnPlayer] + "는 현재마나입니다.");

        switch(gameObject.name) // 버튼명에따른 유닛소환
        {
            case "BasicMeleeSB": SummonChecker(0);
                break;
            case "BasicRangeSB": SummonChecker(1);
                break;
            case "BasicMagicSB": SummonChecker(2);
                break;
            case "EliteMeleeSB": SummonChecker(3);
                break;
            case "EliteRangeSB": SummonChecker(4);
                break;
            case "EliteMagicSB": SummonChecker(5);
                break;
            case "ChampionSB": SummonChecker(6);
                break;
        }
     }


    // 지금 이부분이 클릭하면 임의 위치에 생성만되는데
    // 실제로 해야할부분은 클릭시에 index번호만 변경이되고
    // 유닛을 현재 마스터가있는 위치에 소환할것인가, 마스터가있는위치에서 +- 로 어딘가에 선택해서 소환할것인가, 본진에만 소환할것인가 

    // 어디생성할지 맵을 클릭해서  그맵의 위치를 가지고
    // 영웅순서 인덱스[] 어떤프리팹 인덱스[] 를가지고  그 맵 위치에 인스턴시에이트 해주면됨
    


    public void SummonChecker(int unitNum)
    {
        // 유닛은 소환한만큼 코스트를 먹기떄문에 매턴 마나가 수급된다 - 코스트를 제외한다
        if( !Summon._isSummon && checker.manaPoint[(int)FinishButtonClick.thisTurnPlayer] >= (unitNum+1))  // 이부분조건을  && 플레이어마나 >= (unitnum + 1) 소환하면서 플레이어마나 -= unitnum+1 
        {
            Debug.Log(checker.manaPoint[(int)FinishButtonClick.thisTurnPlayer] + "소환전 마나");
        UnitStatus thisTurnPlayerStatus = GameObject.Find(FinishButtonClick.thisTurnPlayer + "_Master").GetComponent<UnitStatus>();


            // 이부분 소환할때  해당 마스터유닛 있는 타일 리스트 체크해서  서브포인트에 넣어줌
            // 서브포인트에 넣어줄때.. 메인포인트는 비우고 그 리스트 0번은 리스트 카운트 -1 로해서 서브포인트1에넣어주고 그다음유닛은 2에다
            // 넣어주면 길막없이 대칭구조가능,  일반 유닛 이동할때도 리스트에 애드하는순간 그부분 적용 가능한것같음
            // 중앙위치 버리고 사선으로 이동할수있게,  // 한타일에서 2마리유닛이 싸우다 1유닛 죽으면 나머지유닛은  한번더 네브메쉬 데스티네이션 콜해서 중앙으로
            // GameObject summonedUnit = Instantiate(checker.unitPrefabCArr[(int)thisTurnPlayerStatus.unitFaction].unitPrefabs[unitNum], GameObject.Find(FinishButtonClick.thisTurnPlayer + "_Master").GetComponent<Transform>().transform.position, Quaternion.identity);

            int tULC;
            tULC = GameObject.Find("TileGenPos" + startPosition[(int)FinishButtonClick.thisTurnPlayer].ToString()).GetComponent<TileUnitList>().thisTileUnitList.Count;

        //    Debug.Log(tULC + "생성되야할 포지션");
            GameObject summonedUnit = Instantiate(checker.unitPrefabCArr[(int)thisTurnPlayerStatus.unitFaction].unitPrefabs[unitNum], GameObject.Find("TileGenPos" + startPosition[(int)FinishButtonClick.thisTurnPlayer].ToString() + "SubPos" + tULC).GetComponent<Transform>().position, Quaternion.identity);

            summonedUnit.GetComponent<UnitStatus>().whosUnit = FinishButtonClick.thisTurnPlayer;

            // summonedUnit.GetComponent<UnitStatus>().nowTile = GameObject.Find(FinishButtonClick.thisTurnPlayer + "_Master").GetComponent<UnitStatus>().nowTile;
            summonedUnit.GetComponent<UnitStatus>().nowTile = startPosition[(int)FinishButtonClick.thisTurnPlayer];
            summonedUnit.name = FinishButtonClick.thisTurnPlayer + checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units.Count.ToString();
        
            checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units.Add( summonedUnit);



            checker.manaPoint[(int)FinishButtonClick.thisTurnPlayer] -= (unitNum + 1);
      //      Debug.Log(checker.manaPoint[(int)FinishButtonClick.thisTurnPlayer] + "소환후 마나");
            Summon._isSummon = true;
            // 생성하면서   일단 숨겨두고 
            closePannel.OpenSummonPannel();
        }
    }

    // Use this for initialization
    void Start () {
        checker = GameObject.Find("SummonButton").GetComponent<Summon>();
        closePannel = GameObject.Find("SummonButton").GetComponent<Summon>();
        startPosition = new int[] {0,24 };

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
