using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Move : MonoBehaviour {
    public GameObject leftRight;
    public GameObject actionUi;
    public static int nowPosition;
    public int moveDistance;
    private int tempAbsNum;
//    public Transform objTr;
  //  public NavMeshAgent objNMA; 
    public Transform destinationTr;
    public TileUnitList tileUnitCounter;
    int plusLater;
    int tULC; // 타일유닛리스트카운터
    public static int destNum;
    public Summon checker;
    public TileUnitList tempTUL;
    public UnitStatus attackInfo;
    public int tempNowTile;

    public Image[] buttonImages;
    public Button[] buttons;
    public Text[] texts;
    public Camera diceCam;
    // 다음유닛때  각 플레이어 유닛풀 리스트 카운트까지로 맥시멈잡고 0부터 ++ 해서
    // 네브메쉬 에이젼트를 가진 유닛을 담은 리스트의 인덱스를 [플레이어번호][풀인덱스].destination 해주면됨
    // 각캐릭터가 주사위를 굴렸는지 안굴렸는지 불타입체크를해야하고
    // 인덱스마다 불타입체크저장을해야함. 굴린 유닛은 주사위 못굴리게하고, 굴린 이동값은 저장되야함



    // 이부분을 대국적으로짜서 턴종료할때랑, 다음유닛때 숫자 계속바꿔서  어떤 오브젝트의(오브젝트명+ 플레이어몇번 리스트넘버) 의 네브메쉬 에이젼트를 이동시키면됨
    // i++해서 리스트 인덱스에 접근하는데 다음유닛할때랑 턴종료할때
    // x플레이어유닛갯수넘버리스트.count == i가되면 i = 0으로 만들면됨


    // 이동할때 각 타일은 게임오브젝트의 리스트를 가지고있음


    // 0~ 10타일까지 이동을한다고치면


    // 10타일째 도착했을때 ontrigger엔터가 발동하면서  그 유닛을  타일 리스트에넣고


    // exit하믄서  remove를함.(혹은 다음타일에 도착할때 이전타일 정보를 가지고있고 그타일에 접근해서 리스트에서 해당오브젝트를 삭제함)

    // 그후에 임시번호를 현재위치로 바꿈

    // 이걸기준으로  자신위치에서 목적지까지 가기전에


    // 현위치 ~ 목적지 위치까지의 타일 오브젝트들이 가진 게임오브젝트 리스트에 접근해서


    // count가 1 이상이면  그 유닛들이 아군인지 아닌지, 적군이라면 수비모드인지 아닌지를 체크함

    // 적군 수비모드 유닛이 있다면 목적지 위치를 수비모드쪽 타일로 바꿈( 이동력이 얼마남았던 상관이없음)

    public void OnClickLeft()
    {
        diceCam.enabled = false;
        for (int i = 0; i < DiceRoll.rolledDiceList.Count; i++)
        {
            Destroy(DiceRoll.rolledDiceList[i]);

        }
        DiceRoll.rolledDiceList.Clear();

        //        Debug.Log(nowPosition + " 현재위치값" + checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].name);
        if (checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().newBorn)
        { 
        checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().newBorn = false;
        }
        foreach (int value in DiceRoll.diceValues)
        {
            //          Debug.Log(value + "이동할값");
            moveDistance += value;
        }
        ////////////////


        attackInfo = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>();

        tempTUL = GameObject.Find("TileGenPos" + attackInfo.nowTile).GetComponent<TileUnitList>();  // 현재타일 검색

        tempNowTile = attackInfo.nowTile - 1;   // 해당타일 제외하고, -타일들검색

        
        for (int i = 1; i <= moveDistance; tempNowTile--) // 1부터 최대 레인지까지
        {

            if (tempNowTile == -1)
            {
                tempNowTile = 47;

            }
            tempTUL = GameObject.Find("TileGenPos" + tempNowTile).GetComponent<TileUnitList>();
            for (int j = 0; j < tempTUL.thisTileUnitList.Count; j++)
            {   
                if (tempTUL.thisTileUnitList[j].GetComponent<UnitStatus>().isDefence)
                {
                    moveDistance = i;   // 적유닛이 방어 모드이면 i를 이동거리에 대입하고 루프탈출
                    
                    break;

                }
            }
            if(i==moveDistance) // i가 이동거리일때면 루프탈출 최소거리에 방어유닛이 있다는뜻
            {
                break;
            }
            i++;
        }

        ////////////////
        if (nowPosition - moveDistance < 0)
        {
            // 0부터라 48이고 -1빼면 실제 인덱스는 47이지만
            tempAbsNum = (48 - Mathf.Abs(nowPosition - moveDistance));

            // 오브젝트 찾을때는 47번위치로가야해도 이름을 48로 찾아야함
            nowPosition = tempAbsNum;
            destNum = tempAbsNum;
            checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().nowTile = destNum;

            //          Debug.Log(nowPosition + "원점에서왼쪽");
            //       tempAbsNum = tempAbsNum + 1;


            tileUnitCounter = GameObject.Find("TileGenPos" + tempAbsNum).GetComponent<TileUnitList>();
            tULC = tileUnitCounter.thisTileUnitList.Count;   // 해당타일에 몇개있는지 먼저체크
            destinationTr = GameObject.Find("TileGenPos" + tempAbsNum + "SubPos" + tULC).GetComponent<Transform>();

            //         Debug.Log(checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].name);

            NavMeshAgent objNMA = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<NavMeshAgent>();

            objNMA.destination = destinationTr.position;
            Debug.Log(objNMA.velocity.sqrMagnitude);
            Debug.Log(objNMA.velocity.magnitude);

            Animator[] moveController = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponentsInChildren<Animator>();
            //            Rigidbody tempR = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<Rigidbody>();

            for (int i = 0; i < moveController.Length; i++)
            {

                moveController[i].SetBool("Move", true);

            }

            CameraMover.nowCamNum = tempAbsNum;

        }
        else if (nowPosition - moveDistance >= 0)
        {
            // 0부터라 48이고 -1빼면 실제 인덱스는 47이지만
            tempAbsNum = (nowPosition - moveDistance);

            nowPosition = tempAbsNum;
            destNum = tempAbsNum;

            checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().nowTile = destNum;

            //      Debug.Log(nowPosition + "왼쪽으로");
            //      tempAbsNum = tempAbsNum + 1;
            tileUnitCounter = GameObject.Find("TileGenPos" + tempAbsNum).GetComponent<TileUnitList>();
            tULC = tileUnitCounter.thisTileUnitList.Count;   // 해당타일에 몇개있는지 먼저체크
            destinationTr = GameObject.Find("TileGenPos" + tempAbsNum + "SubPos" + tULC).GetComponent<Transform>();

            //         Debug.Log(checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].name);

            NavMeshAgent objNMA = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<NavMeshAgent>();

            objNMA.destination = destinationTr.position;
      
            // 애니메이션 담당

            Animator[] moveController = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponentsInChildren<Animator>();
//            Rigidbody tempR = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<Rigidbody>();

            for (int i = 0; i < moveController.Length; i++)
            {

                moveController[i].SetBool("Move", true);

            }

            CameraMover.nowCamNum = tempAbsNum;

        }

        //     Debug.Log("목적지 인덱스" + destNum);
        moveDistance = 0;
        

        for (int i = 0; i < 2; i++)
        {
            buttonImages[i].enabled = false;
            buttons[i].enabled = false;
            texts[i].enabled = false;
        }



        // 트루펄스타입줘서  턴종료시는 다시펄스하고  이동전에 액션해도 트루,,,  펄스로 not false일때만 작동
        actionUi.SetActive(true);
    }

    public void OnClickRIght()
    {
        diceCam.enabled = false;
        for (int i = 0; i < DiceRoll.rolledDiceList.Count; i++)
        {
            Destroy(DiceRoll.rolledDiceList[i]);

        }
        DiceRoll.rolledDiceList.Clear();


        //     Debug.Log(nowPosition + " 현재위치값" + checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].name);
        if (checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().newBorn)
        {
            checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().newBorn = false;
        }
        foreach (int value in DiceRoll.diceValues)
        {
            //         Debug.Log(value + "이동할값");
            moveDistance += value;
        }

        /////
        ////////////////


        attackInfo = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>();

        tempTUL = GameObject.Find("TileGenPos" + tempNowTile).GetComponent<TileUnitList>();

        tempNowTile = attackInfo.nowTile + 1;   // 해당타일 제외하고, +타일들검색

        for (int i = 1; i <= moveDistance; tempNowTile++) // 1부터 최대 레인지까지
        {
            if (tempNowTile == 48)
            {
                tempNowTile = 0;
            }
            tempTUL = GameObject.Find("TileGenPos" + tempNowTile).GetComponent<TileUnitList>();
            for (int j = 0; j < tempTUL.thisTileUnitList.Count; j++)
            {   // 적군이면 담음
                if (tempTUL.thisTileUnitList[j].GetComponent<UnitStatus>().isDefence)
                {
                    
                    moveDistance = i;   // 적유닛이 방어 모드이면 i를 이동거리에 대입하고 루프탈출

                    break;

                }
            }
            if (i == moveDistance) // i가 이동거리일때면 루프탈출 최소거리에 방어유닛이 있다는뜻
            {
                break;
            }
            i++;
        }
        

        if (nowPosition + moveDistance > 47)
        {

            tempAbsNum = nowPosition + moveDistance;

            tempAbsNum = (tempAbsNum - 48);

            nowPosition = tempAbsNum;
            destNum = tempAbsNum;

            checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().nowTile = destNum;

            //      Debug.Log(nowPosition + "원점에서오른쪽");
            //      tempAbsNum = tempAbsNum + 1;
            tileUnitCounter = GameObject.Find("TileGenPos" + tempAbsNum).GetComponent<TileUnitList>();
            tULC = tileUnitCounter.thisTileUnitList.Count;   // 해당타일에 몇개있는지 먼저체크
            destinationTr = GameObject.Find("TileGenPos" + tempAbsNum + "SubPos" + tULC).GetComponent<Transform>();

            //         Debug.Log(checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].name);

            NavMeshAgent objNMA = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<NavMeshAgent>();

            objNMA.destination = destinationTr.position;
            Debug.Log(objNMA.velocity.sqrMagnitude);
            Debug.Log(objNMA.velocity.magnitude);

            Animator[] moveController = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponentsInChildren<Animator>();
            //            Rigidbody tempR = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<Rigidbody>();

            for (int i = 0; i < moveController.Length; i++)
            {

                moveController[i].SetBool("Move",true);
            }

            CameraMover.nowCamNum = tempAbsNum;

        }
        else if (nowPosition - moveDistance <= 47)
        {

            tempAbsNum = (nowPosition + moveDistance);

            nowPosition = tempAbsNum;
            destNum = tempAbsNum;

            checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().nowTile = destNum;


            //        Debug.Log(nowPosition + "오른쪽으로");
            //        tempAbsNum = tempAbsNum + 1;
            tileUnitCounter = GameObject.Find("TileGenPos" + tempAbsNum).GetComponent<TileUnitList>();
            tULC = tileUnitCounter.thisTileUnitList.Count;   // 해당타일에 몇개있는지 먼저체크
            destinationTr = GameObject.Find("TileGenPos" + tempAbsNum + "SubPos" + tULC).GetComponent<Transform>();

            //         Debug.Log(checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].name);

            NavMeshAgent objNMA = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<NavMeshAgent>();

            objNMA.destination = destinationTr.position;
            

            Animator[] moveController = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponentsInChildren<Animator>();
            //            Rigidbody tempR = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<Rigidbody>();

            for (int i = 0; i < moveController.Length; i++)
            {

                moveController[i].SetBool("Move", true);

            }

            CameraMover.nowCamNum = tempAbsNum;

        }
        //     Debug.Log("목적지 인덱스" + destNum);
        moveDistance = 0;

        for (int i = 0; i < 2; i++)
        {
            buttonImages[i].enabled = false;
            buttons[i].enabled = false;
            texts[i].enabled = false;
        }

        actionUi.SetActive(true);



    }


  

    void OnEnable()
    {

     //  objTr = GetComponent<Transform>();
    }

	// Use this for initialization
	void Start () {
        checker = GameObject.Find("SummonButton").GetComponent<Summon>();
     
}

	// Update is called once per frame
	void Update () {

    //    NavMeshAgent objNMA = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<NavMeshAgent>();

    //  Debug.Log(  objNMA.velocity.magnitude);


    }
}
