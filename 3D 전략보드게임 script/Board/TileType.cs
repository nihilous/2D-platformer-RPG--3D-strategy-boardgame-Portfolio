using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileType : MonoBehaviour {
                        // 마나주는타일,화폐자원 , 숨을수있는 숲(?), 건물지을수있는곳(치료소, 수비거점 등등) 평지, 맵병기(리소스 드는 고대무기(?)
    public enum TileTypes {Base,Bay,MapWeapon,Mana , Gold , Fort, Guard, Tent, MapWeaponKey,Forrest,AtkUp,DefUp,DiceUp,ManaCharger,CoolZero,Trap,Dungeon,Market,Duel }
    // 0베이스, 1 항구,2 맵병기 , 3마나리소스, 4골드마인, 5중립요새, 6수비거점, 7힐링텐트, 8맵웨폰키, 9숲, 10공격력, 11방어력, 12이동력, 13유닛마나회복
    // 14 유닛쿨타임초기화, 15 트랩, 16 던젼, 17  마켓, 18 결투장,

    public TileTypes thisTileType;
    public enum TileOwnerPvP {Player1, Player2, None }
    public TileOwnerPvP thisTileOwner;
    public int tileNum;
    public int subdueCost = 0;  // 타일을 정복하면 subduecost가 올라감. 선점시에는 0 후점시에는1 이후에도 +1씩 점령하는데 골드를소모하고
    // 골드가없다면 점령할수없음.  시장에서 이부분에관하여  모라토리움, 인플레이션등을 줄수있음
    
    GameManage manaup;
    // 게임매니지._플레이어인포[디스턴플레이어].occupiedMsGsFort[접근원하는자원인덱스]

    // 각 타일이 별개의 스크립트를 가지고있고  하위에서 겟컴퍼넌트로 접촉시 메소드,  액션시 메소드를 콜해줌
    // 유닛은 항상 on action command 만 호출하면됨

    // 액션커맨드 사용시에

        public void ResourceOccupy(int resourceType)    // 0은마나, 1은금, 2는 맵웨폰키(?) 뭐할지모르겠따
    {
        if (thisTileOwner == TileOwnerPvP.None)
        {

            manaup._playerInfo[(int)FinishButtonClick.thisTurnPlayer].occupiedMsGsFort[resourceType] += 1;
            
        }

        else if ((int)thisTileOwner != (int)FinishButtonClick.thisTurnPlayer && thisTileOwner != TileOwnerPvP.None)
        {
            manaup._playerInfo[(int)FinishButtonClick.thisTurnPlayer].occupiedMsGsFort[resourceType] += 1;
            if (FinishButtonClick.thisTurnPlayer == FinishButtonClick.WhosTurn.Player1)  // 플레이어1턴이면
            {
                manaup._playerInfo[1].occupiedMsGsFort[resourceType] -= 1; // 플레이어2 마나광산 -1
            }
            else
            {
                manaup._playerInfo[0].occupiedMsGsFort[resourceType] -= 1; // 플레이어1턴이아니면 플레이어1 마나광산 -1
            }
        }
    }

    public void OnActionCommand()
    {
        Debug.Log("섭듀이후 온액션 커맨드1");


        switch (thisTileType)
        {
            case TileTypes.Base:
                break;
            case TileTypes.Bay:
                break;
            case TileTypes.MapWeapon:
                break;
            case TileTypes.Mana:
                ResourceOccupy(0);
                break;
            case TileTypes.Gold:
                ResourceOccupy(1);
                break;
            case TileTypes.Fort:
                break;
            case TileTypes.Guard:
                break;
            case TileTypes.Tent:
                break;
            case TileTypes.MapWeaponKey:
                ResourceOccupy(2);
                break;
            case TileTypes.Forrest:
                break;
            case TileTypes.AtkUp:
                break;
            case TileTypes.DefUp:
                break;
            case TileTypes.DiceUp:
                break;
            case TileTypes.ManaCharger:
                break;
            case TileTypes.CoolZero:
                break;
            case TileTypes.Trap:
                break;
            case TileTypes.Dungeon:
                break;
            case TileTypes.Market:
                break;
            case TileTypes.Duel:
                break;
            default:
                break;
        }
    }

    /*
     // 적 아군이 충돌시에 (?)
     void OnTriggerEnter(Collider col)
     {
     
             switch (thisTileType)
             {
                 case TileTypes.Base:
                     break;
                 case TileTypes.Mana:
                     break;
                 case TileTypes.Gold:
                     break;
                 case TileTypes.Fort:
                     break;
                 case TileTypes.Tower:
                     break;
                 case TileTypes.Tent:
                     break;
                 case TileTypes.MapWeapon:
                     break;
                 case TileTypes.Plain:
                     break;

             }


             Debug.Log("자원획득");
         }
     }
          */
    // Use this for initialization
    void Start () {
        tileNum = GetComponentInParent<TestScriptTileObj>().tileNum;
        manaup = GameObject.Find("GameManager").GetComponent<GameManage>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
