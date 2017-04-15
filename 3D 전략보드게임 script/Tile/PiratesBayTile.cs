using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PiratesBayTile : MonoBehaviour {

    public Transform shipPos;
    public List<Transform> destPos = new List<Transform>();
    public NavMeshAgent shipMover;
    public Summon checker;
    public GameManage goldChecker;
    public TileType bayOwner;
    public List<int> destNum = new List<int>();
    public GameObject passenger = null;
    public RaycastHit hit;
    public bool boardOn = false;


        public void Boarding()
    {
        GameObject thisUnit = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex];
        passenger = thisUnit;
        UnitStatus thisUnitStatus = thisUnit.GetComponent<UnitStatus>();


        if (thisUnitStatus.nowTile == 12 && (int)bayOwner.thisTileOwner == (int)thisUnitStatus.whosUnit )
        {
            // 금 - 1
            goldChecker.goldSum[(int)FinishButtonClick.thisTurnPlayer] = goldChecker.goldSum[(int)FinishButtonClick.thisTurnPlayer] -1;

            
            thisUnit.transform.position = shipPos.position;
            thisUnit.GetComponent<NavMeshAgent>().enabled = false;
            
            thisUnit.transform.SetParent(shipPos);
            thisUnit.transform.rotation = shipPos.transform.rotation;
            boardOn = true;
        }
    }

    public void Sail(bool board , RaycastHit hit)
    {
        GameObject thisUnit = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex];
        UnitStatus thisUnitStatus = thisUnit.GetComponent<UnitStatus>();
        if (hit.collider.tag == "TILE" && thisUnitStatus.hadAction == false)
        {
            destNum.Add(hit.collider.gameObject.GetComponent<TileType>().tileNum);
            shipMover.destination = destPos[destNum[0]].position;
    //            board = false; 이부분은 각 포지션 콜라이더가 가지고있는 부분에서 접근해야할듯함 콜라이더에 접근하면 배도 다시 원위치로 돌려줘야함
        }

    }


    // Use this for initialization
    void Start () {
        checker = GameObject.Find("SummonButton").GetComponent<Summon>();
        goldChecker = GameObject.Find("GameManager").GetComponent<GameManage>();
        bayOwner = gameObject.GetComponent<TileType>();
        shipPos = GameObject.Find("BoardingPosition").transform;
        shipMover = GameObject.Find("Ship").GetComponent<NavMeshAgent>();
        for (int i = 0; i < 48; i++)
        {
            destPos.Add(GameObject.Find("ShipDest" + i).GetComponent<Transform>());
        }

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown (0) && checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().nowTile == 12)
        {



            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out hit);



            if (hit.collider.tag == "TILE" && passenger == null && goldChecker.goldSum[(int)FinishButtonClick.thisTurnPlayer] >= 1)
            {
                if (hit.collider.gameObject.GetComponent<TileType>().thisTileType == TileType.TileTypes.Bay)
                { 
                Boarding();
                }
            }


           
        }

        if(passenger !=null)
        {
            passenger.transform.position = shipPos.position;
        }


        if (Input.GetMouseButtonDown(1) && passenger != null && checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().nowTile ==12)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out hit);
            if (boardOn && hit.collider != null)
            {
                Sail(boardOn, hit);
            }
        }






    }
}
