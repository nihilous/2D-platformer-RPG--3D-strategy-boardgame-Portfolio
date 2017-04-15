using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerate : MonoBehaviour {

    public Transform[] tileGenPositions;
    public GameObject[] tilePrefabs;
    public List<GameObject> tileSetList = new List<GameObject>();   // 이부분은 클래스 리스트로 만들어서  몇번에 어떤타일이있는지 확인해볼것..
    public List<int> tileNumChecker = new List<int>();
    public bool sameTile = false;
    public int PrefabNum = 0;
    public int i= 0;
    public int[] checkNum;      //  = new int[] {10,14 , 20, 28,48}; 이부분에 선언과동시에 초기화
    public int[] indexNum;      // = new int[] {1, 10 , 14, 20, 28};
    public int numberToSee = 100;
    public Summon checker;

    void TileMaker()
    {
        switch (PrefabNum)
        {
            case 0:
                // 0하고 24자리에  프리팹0으로 베이스타일 세우고서,, 플레이어 팩션에따라서 타운 둘중하나 enable시킴
                // 유닛을 뽑는건 중립거점을 많이 확보할수록 티어를 올릴수있음(?)
                //        Debug.Log("케이스0");
                 tileNumChecker.Add(0);
            //    tileNumChecker.Add((Random.Range(0, tileGenPositions.Length)));
                GameObject Tile = Instantiate(tilePrefabs[PrefabNum], tileGenPositions[tileNumChecker[i]].position, tileGenPositions[tileNumChecker[i]].rotation);
                Tile.name = "Tile" + tileNumChecker[i].ToString();
                Tile.transform.parent = tileGenPositions[tileNumChecker[i]];
   //             BaseTile p1BaseActive = Tile.GetComponent<BaseTile>();
     //           p1BaseActive.ActivateBase((int)checker.PlayerUnits[0].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().unitFaction);
                Tile.SendMessage("ActivateBase", (int)checker.PlayerUnits[0].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().unitFaction, SendMessageOptions.DontRequireReceiver);

                tileSetList.Add(Tile);
                tileSetList[i].GetComponent<TestScriptTileObj>().tileNum = tileNumChecker[i];
//                tileSetList[i].GetComponentInChildren<TileType>().tileNum = tileNumChecker[i];

                i++;

                

                // 베이스타일 블라 = Tile.getcom<베이스타일>.메소드(facnum) // 이거실행시 맞는 팩션 건물이 enable
                //           
                CheckAndMake();
                break;
            case 1:             
            case 2:           
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:

                CheckAndMake();
                break;
            case 19:
   //             Debug.Log("케이스4");
                break;
               
        }
    }






    void CheckAndMake()
    {

     //           Debug.Log(indexNum[PrefabNum] + "다음숫자" + checkNum[PrefabNum]);
   
        for (i = indexNum[PrefabNum]; i < checkNum[PrefabNum]; i++)
        {
       //     Debug.Log(i + "번째 도는중");
            sameTile = false;
            //       if (tileNumChecker.Count >= 1)
            //       {

            switch (PrefabNum)
            {
                case 0:
                    tileNumChecker.Add(24); // 플레이어2 베이스
                    break;
                case 1:
                    tileNumChecker.Add(12); // 항구
                    break;
                case 2:
                    tileNumChecker.Add(36); // 맵병기
                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                    tileNumChecker.Add((Random.Range(0, tileGenPositions.Length)));
                    break;
            }

            /*
            if (PrefabNum == 0)
            {
                tileNumChecker.Add(24);
            }
            else if(PrefabNum == 1)
            {
                tileNumChecker.Add(24);
            }
            else
            { 
            */

           // }    //      
      //      Debug.Log(tileNumChecker[i] + "무슨수?");
                for (int j = 0; j < tileNumChecker.Count - 1; j++)
                {


                    if (tileNumChecker[j] == tileNumChecker[i])
                    {
               //         Debug.Log(tileNumChecker[i] + "중복?" + tileNumChecker[j]);
                        tileNumChecker.Remove(tileNumChecker[i]);
                        --i;
                        sameTile = true;
                        break;
                    }
                }

                if (!sameTile)
                {
                   GameObject Tile = Instantiate(tilePrefabs[PrefabNum], tileGenPositions[tileNumChecker[i]].position, tileGenPositions[tileNumChecker[i]].rotation);
                Tile.name = "Tile" + tileNumChecker[i].ToString();
                Tile.transform.parent = tileGenPositions[tileNumChecker[i]];
                tileSetList.Add(Tile);
                if(tileNumChecker[i] == 12 || tileNumChecker[i] == 36 )
                {
                    Tile.GetComponent<BoxCollider>().center = new Vector3(2.5f, 0, 2.5f);
                    Tile.GetComponent<BoxCollider>().size = new Vector3(10.0f, 0.1f, 10.0f);

                }
                if (PrefabNum==0)
                { 
//                BaseTile p1BaseActive = Tile.GetComponent<BaseTile>();
  //              p1BaseActive.ActivateBase((int)checker.PlayerUnits[1].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().unitFaction);
                Tile.SendMessage("ActivateBase", (int)checker.PlayerUnits[1].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().unitFaction, SendMessageOptions.DontRequireReceiver);
                }

                tileSetList[i].GetComponent<TestScriptTileObj>().tileNum = tileNumChecker[i];
                    
                
                if (i == (checkNum[PrefabNum]-1))
                    {
                        PrefabNum++;
                        
                        TileMaker();

                       break;
                    }
                }

            }
        
    }

    public void BaseOwner()
    {
        tileSetList[0].GetComponent<TileType>().thisTileOwner = TileType.TileOwnerPvP.Player1;
        tileSetList[1].GetComponent<TileType>().thisTileOwner = TileType.TileOwnerPvP.Player2;
    }

    // Use this for initialization
    void Awake()
    {
        checker = GameObject.Find("SummonButton").GetComponent<Summon>();
        checkNum = new int[] { 2, 3, 4, 12, 20, 22, 25, 27, 30, 37, 38, 39, 40, 41, 42, 43, 46, 47, 48};
        indexNum = new int[] { 1, 2, 3, 4,  12, 20, 22, 25, 27, 30, 37, 38, 39, 40, 41, 42, 43, 46, 47};
        //                     0, 1, 2, 3,  4,  5,  6,  7,  8,  9,  10, 11, 12, 13, 14, 15, 16, 17, 18,
        // 인덱스넘이 프리팹종류 순서 
        // 0베이스, 1 항구,2 맵병기 , 3마나리소스, 4골드마인, 5중립요새, 6수비거점, 7힐링텐트, 8맵웨폰키, 9숲, 10공격력, 11방어력, 12이동력, 13유닛마나회복
        // 14 유닛쿨타임초기화, 15 트랩, 16 던젼, 17  마켓, 18 결투장,


        TileMaker();
    }

    void Start () {
        BaseOwner();
        	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
