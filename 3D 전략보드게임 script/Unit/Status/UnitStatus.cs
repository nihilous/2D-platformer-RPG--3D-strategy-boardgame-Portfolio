using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatus : MonoBehaviour {

    // 매턴이 돌아올때 기본은 마스터유닛, 다음유닛으로 넘기면 어떤유닛인지 이넘타입으로 파악해서
    // 스태틱에 현재 유닛이 어떤유닛인지 알리고
    // 그 스태틱을 토대로
    // 스킬부분에 사용할 UI를 마스터용, 소환된유닛용으로 나눠서 델리게이트로 쓰고
    // 클릭할때 각각 유닛에 맞는 UI를 보여줌
    // 클릭시  다음에 열릴 UI의 텍스트, 사진과 그 UI버튼에 연결될 델리게이트도 변경해줌 , 아니면 델리게이트대신에 그 이넘타입을 바탕으로
    // 메소드를 스위치형으로 짜버림 


    public string unitName;
    public int nowTile; // 카메라뷰가 nowTile을 기준삼아 캐릭터가 어떤위치에있는지보고 로테이션을 조절하면됨

    public int maxDices;
    public int dices;
    public int originDices;
    private int diceBuffPeriod;
    [SerializeField]
    public int diceBPProp
    {
        get { return diceBuffPeriod; }
        set {
            if (value < 0)
                value = 0;
            diceBuffPeriod = value;
        }
    }

    
    public bool hadAction;  // false 였다가 일단 삭제함
    public bool hadRollDice = false;
    public int AttackRange;

    public int originAtk;
    public int atkPoint;
    [SerializeField]
    private int atkBuffPeriod;

    public int atkBPProp
    {
        get { return atkBuffPeriod; }
        set {
            if (value < 0)
                value = 0;
            atkBuffPeriod = value;
            }
    }

    public int originDef;
    public int defPoint;
    [SerializeField]
    private int defBuffPeriod;

    public int defBPProp
    {
        get { return defBuffPeriod; }
        set {
            if (value < 0)
                value = 0;
            defBuffPeriod = value;
            }
    }

    public int maxLifePoint;
    [SerializeField]
    private int lifePoint;

    public int lifePointProp
    {
        get { return lifePoint; }
        set {
            if(value <= 0)
            {
                value = 0;
                lifePoint = value;
            }
            else
            {
                lifePoint = value;
            }
        }
    }

    public int maxManaPoint;

    [SerializeField]
    private int manaPoint;

    public int manaPointProp
    {
        get { return manaPoint; }
        set {
            if (value <= 0)
            {
                value = 0;
                manaPoint = value;
            }
            else
            {
                manaPoint = value;
            }

        }
    }


    public int killCount;   // 킬카운트 일정이상되면 유닛 진급 혹은 능력치상승
     
    public int skillCool;

    public int nowSkillCool;

    public int manaCost;    // 턴종료후 새로운턴 돌아올시 각 유닛의 마나코스트를 현재 마나 보유량에서 제거  고급유닛일수록
                            // 소환시 마나사용량은 티어에 비례하고  소환후 마나소모는 적음 즉 고급유닛 소수 vs 하급유닛 다수가 가능
                            // 고급유닛을 먼저 많이 생산후 하급유닛을 보충하는 전략도 가능
    public bool isFly;

    public bool isDefence;  // 이동중에 이즈디펜스유닛과 콜라이더 충돌하면  디펜스유닛의 nowtile을 목적지로 바꾸고 이동력 0으로, 이후 싸움
                            // 더블스위치로 팩션으로 첫분기나누고 이후에 유닛타입으로 나눔
    public bool newBorn = true;

    public bool isRange;

    public int unitNum; // 마스터는 0번이고 소환되는 순서대로 번호를가짐    // 이부분을 리스트에 넣어야함. 리스트에넣고 죽으면 번호도 바꿔주고
    
    public FinishButtonClick.WhosTurn whosUnit;

    public enum Faction { Academy, Stronghold }

    public Faction unitFaction;
                                    
    public enum UnitType { Master, BasicMelee, BasicRange, BasicMagic, EliteMelee, EliteRange, EliteMagic, Champion }

    public UnitType unitType;

    Summon checker;

    int tempCounter;
    public GameObject attackFxPrefab;
    public Transform attackFxPos;

    // 인덱스 에러가 나는데 원인을 특정할수없음
    public void UnitDead()
    {
        checker = GameObject.Find("SummonButton").GetComponent<Summon>();
        TileUnitList tempUL = GameObject.Find("TileGenPos" + nowTile).GetComponent<TileUnitList>();
        tempCounter = tempUL.thisTileUnitList.Count;
        
                Debug.Log(tempCounter + "타일종속유닛수");
                for (int i = 0; i < tempCounter; i++)
                {

                   if ( gameObject == tempUL.thisTileUnitList[i])
                    {
                        Debug.Log(gameObject.name + "타일에서 지워진 게임오브젝트이름");

                tempUL.thisTileUnitList.RemoveAt(i);   //(tempUL.thisTileUnitList[i]);
                break;
                    }
                }

        tempCounter = checker.PlayerUnits[(int)whosUnit].Units.Count;
      
        for (int i = 0; i < tempCounter; i++)
        {
            if (gameObject ==   checker.PlayerUnits[(int)whosUnit].Units[i])
            {

                checker.PlayerUnits[(int)whosUnit].Units.RemoveAt(i);  //Remove(checker.PlayerUnits[(int)whosUnit].Units[i].gameObject);        // 죽을때 데미지 받은 오브젝트를 유닛 리스트에서 제거
                break;
            }
        }

        Animator[] dieController = gameObject.GetComponentsInChildren<Animator>();


        for (int j = 0; j < dieController.Length; j++)
        {

            dieController[j].SetBool("Die", true);  // 어차피 죽는부분이라 false로 돌릴필요없음
            Debug.Log("사망애니메이션");
        }

        Animator[] killController = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponentsInChildren<Animator>();


        for (int j = 0; j < killController.Length; j++)
        {

            killController[j].SetTrigger("Kill");
            Debug.Log("죽는타이밍에 피살자를 죽이는데 성공한유닛을 승리모션 불러옴");
        }

        Destroy(gameObject, 6.0f);
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
