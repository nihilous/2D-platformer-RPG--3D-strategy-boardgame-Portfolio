using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FinishButtonClick : MonoBehaviour {

    public enum WhosTurn { Player1,Player2,Player3,Player4 }
    public static WhosTurn thisTurnPlayer;
    public Summon spriteChangeCaller;
    public DiceRoll diceControl;
    GameManage manaup;

    public Sprite[] heroImages;

    public Image heroImageUI;
    UnitInfoUiControl unitInfoPannelOff;

    public float turnNum = 1.0f;
    
public Text manaOccu;
public Text goldOccu;
public Text unitQtt; // 이부분은... 뭘로할지 잘
    Vector3 mousePos;
    public GameObject turnCounter;

    public void ResourceStat()  // 시작시랑 정복버튼에서도 불러오고 턴종료시에도불러옴
    {
        
            manaOccu.text = manaup._playerInfo[(int)thisTurnPlayer].occupiedMsGsFort[0].ToString();
            goldOccu.text = manaup.goldSum[(int)thisTurnPlayer].ToString();
            unitQtt.text = manaup._playerInfo[(int)thisTurnPlayer].occupiedMsGsFort[2].ToString();

    }

public void OnFinishButtonClick ()
    {
        heroImageUI.sprite = heroImages[(int)FinishButtonClick.thisTurnPlayer];

        // 턴종료시 해당 턴 종료한유닛들을 다음에 이동가능하게 바꿔놓고 주도권 넘김
        for (int i = 0; i < spriteChangeCaller.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units.Count; i++)
        {
            spriteChangeCaller.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[i].GetComponent<UnitStatus>().hadRollDice = false;
            spriteChangeCaller.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[i].GetComponent<UnitStatus>().hadAction = false;

        }

        // 게임매니져에서 마나자원 점령한 수만큼 마나 더해줌, // 플레이어 마스터는 기본으로 마나 1을 항상 생성하고  유닛들은 모두 마나코스트를 가지고있다
        // 마나를 수급하는건 여기서하고,
        Debug.Log(manaup._playerInfo[(int)FinishButtonClick.thisTurnPlayer].occupiedMsGsFort[0] + "는 마나광산수" + FinishButtonClick.thisTurnPlayer);
        Debug.Log(spriteChangeCaller.manaPoint[(int)thisTurnPlayer] + "는 더하기전 마나");
        spriteChangeCaller.manaPoint[(int)thisTurnPlayer] = manaup._playerInfo[(int)FinishButtonClick.thisTurnPlayer].occupiedMsGsFort[0];
        Debug.Log(spriteChangeCaller.manaPoint[(int)thisTurnPlayer] + "는 더하고 나서 마나");
        manaup.goldSum[(int)thisTurnPlayer] += manaup._playerInfo[(int)thisTurnPlayer].occupiedMsGsFort[1];

        for (int i = 0; i < spriteChangeCaller.PlayerUnits[(int)thisTurnPlayer].Units.Count; i++)
        {
            UnitStatus tUS = spriteChangeCaller.PlayerUnits[(int)thisTurnPlayer].Units[i].GetComponent<UnitStatus>();

           if( tUS.atkBPProp != 0 || tUS.defBPProp != 0 || tUS.diceBPProp != 0)
            {
                switch (tUS.atkBPProp)
                {
                    case 0:
                        break;
                    case 1:

                        tUS.atkBPProp--;
                        tUS.atkPoint = tUS.originAtk;
                        break;
                    default:
                        tUS.atkBPProp--;
                        break;
                }
                switch (tUS.defBPProp)
                {
                    case 0:
                        break;
                    case 1:

                        tUS.defBPProp--;
                        tUS.defPoint = tUS.originDef;
                        break;
                    default:
                        tUS.defBPProp--;
                        break;
                }
                switch (tUS.diceBPProp)
                {
                    case 0:
                        break;
                    case 1:

                        tUS.diceBPProp--;
                        tUS.dices = tUS.originDices;
                        break;
                    default:
                        tUS.diceBPProp--;
                        break;
                }
                
            }


        }

        

        ++thisTurnPlayer;
        if (thisTurnPlayer == WhosTurn.Player3)
        {
            thisTurnPlayer = WhosTurn.Player1;
        }
        // 마나코스트를 가져가는건 플레이어가 변경된후에~ 유닛스테이터스 포문돌려서 현재 플레이어 마나에서 차감
        // 소환할때의 차감과  코스트는 조금 다른거라고 생각함. 이걸 기준으로 유닛간 성능격차를 벌이면된다고생각
        UnitStatus thisTurnPlayerStatus = GameObject.Find(thisTurnPlayer + "_Master").GetComponent<UnitStatus>();

        spriteChangeCaller.FinishSummonPannelSpriteChanger((int)thisTurnPlayerStatus.unitFaction);

        NextButtonClick.unitMoveIndex = 0;

        Move.nowPosition = spriteChangeCaller.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().nowTile;
        CameraMover.nowCamNum = spriteChangeCaller.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().nowTile;
        diceControl.diceQuantity = spriteChangeCaller.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().dices;
    //    diceControl.NextUnitAndTurnEnd();
        Debug.Log(thisTurnPlayer);
        Summon._isSummon = false;
        ResourceStat();
        turnNum++;
        TurnCounterOn();
    }


    public void TurnCounterOn()
    {
        turnCounter.SetActive(true);
        turnCounter.GetComponentInChildren<Text>().text = thisTurnPlayer + "의 턴" + (Mathf.Ceil(turnNum / 2.0f)).ToString();
    }

    // Use this for initialization
    void Start () {

        thisTurnPlayer = WhosTurn.Player1;
        spriteChangeCaller = GameObject.Find("SummonButton").GetComponent<Summon>();
        diceControl = GameObject.Find("RollDiceButton").GetComponent<DiceRoll>();
        manaup = GameObject.Find("GameManager").GetComponent<GameManage>();
        ResourceStat();
        TurnCounterOn();
    

    }

    // Update is called once per frame
    void Update()
    {
        if (turnCounter.activeSelf == true)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            if (hit.collider != null )
            { 
            turnCounter.SetActive(false);
            }
        }
    }
}
