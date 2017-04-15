using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInfo{
    // 접근할땐 게임매니지._플레이어인포[디스턴플레이어].occupiedMsGsFort[접근원하는자원인덱스]
    public int[] occupiedMsGsFort = new int[3] { 0, 0, 0 };   // 원래는 0이었음 // 유닛 코스트만큼 - 시킬생각임  // 임시적으로 10으로바꿈
// 턴넘기고나면 유닛안뽑아도 기초마나 1이 사라지는문제

}

public class GameManage : MonoBehaviour {

    public List<PlayerInfo> _playerInfo = new List<PlayerInfo>();
    public Summon checker;
    public AttackButtonClick attacker;
    RaycastHit hit;
    public static Transform targetTr;   // 공격대상은 매번 변함..  파티클 발사시 위치참조할것
    public static int TargetNum;
    public List<GameObject> tempRangeTarget = new List<GameObject>();
    public int[] goldSum;



    // Use this for initialization
    void Awake()
    {
        PlayerInfo p1Info = new PlayerInfo();
        PlayerInfo p2Info = new PlayerInfo();
        _playerInfo.Add(p1Info);
        _playerInfo.Add(p2Info);
        goldSum = new int[] { 1, 1 };   // 초기값 00 이어야함

    }
    void Start () {
        checker = GameObject.Find("SummonButton").GetComponent<Summon>();
        attacker = GameObject.Find("AttackButton").GetComponent<AttackButtonClick>();
    }

    /*      // 직접 달아줘야하는듯.
    void OnMouseDown()
    {
        Debug.Log("???");
    }
    */
    // Update is called once per frame

        public void RangeAttackFxGen()
    {
        if (checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().attackFxPrefab != null)
        {
            Debug.Log(tempRangeTarget[0].name);
            targetTr = tempRangeTarget[0].transform;
            GameObject tempPrefab = Instantiate(checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().attackFxPrefab, checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().attackFxPos.position, checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().attackFxPos.rotation);

            Destroy(tempPrefab, 6.0f);
            tempRangeTarget.RemoveRange(0, tempRangeTarget.Count);
//            attacker.attackSubject.RemoveRange(0, attacker.attackSubject.Count);

        }
    }

    void Update () {
  


        // 이부분을 공격 당하는 입장에서만 호출한다면?
        if (Input.GetMouseButtonDown(0))
        {

            /*
              if (checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().attackFxPrefab != null)
              {
                  GameObject tempPrefab = Instantiate(checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().attackFxPrefab, checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().attackFxPos.position, checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().attackFxPos.rotation);
                  Destroy(tempPrefab, 6.0f);
              }
            */


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                                                            // 1번부터 7번까지는 무시하고 8번만 검출
           // Physics.Raycast(ray, out hit , Mathf.Infinity,1<<LayerMask.NameToLayer("UNIT")); // 오버로드 10번



            Physics.Raycast(ray,out hit);

            if (hit.collider != null)
            { 
            Debug.Log(hit.collider.gameObject.name + "단순클릭시  오브젝트네임");
            }
            // 이부분에서 공격가능한 대상인지 확인하고 포문내부 리스트에서 클릭한오브젝트가 공격대상이라면
            // 현재 순서인 유닛은 공격실행(공격대상보고), 데미지 호출
            // 공격해야될 대상 리스트의 카운트가 0이아니고, 주도권을 가진유닛이 다른 행동을 하지 않은상태라면
            if (attacker.attackSubject.Count != 0 && !checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().hadAction)
            { 



                for (int i = 0; i < attacker.attackSubject.Count; i++)
                {
                    // Debug.Log(hit.collider.gameObject.name + "힛트 콜라이더 게임오브젝트 네임");
                    // Debug.Log(attacker.attackSubject[i].gameObject.name + "리스트 요소 네임");

                    Debug.Log(hit.collider.gameObject.name);
                    for (int j = 0; j < attacker.attackSubject.Count; j++)
                    {
                        Debug.Log(attacker.attackSubject[j].name + "공격대상이름");
                    }
                    
                    if (hit.collider.gameObject == attacker.attackSubject[i].gameObject )
                    {
                        tempRangeTarget.Add(attacker.attackSubject[i]);

                        attacker.attackSubject[i].GetComponent<UnitDamage>().Damage(checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().atkPoint);


                        Animator[] attackController = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponentsInChildren<Animator>();

                        int a = Random.Range(1, 3);
                        for (int j = 0; j < attackController.Length; j++)
                        {

                            attackController[j].Play("Attack"+a, 0);

                        }
                        NavMeshAgent objNMA = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<NavMeshAgent>();
                        objNMA.transform.LookAt(attacker.attackSubject[i].transform);

                        /*
                        if (checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().attackFxPrefab != null)
                        {
                            targetTr = attacker.attackSubject[i].transform;
                            GameObject tempPrefab = Instantiate(checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().attackFxPrefab, checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().attackFxPos.position, checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().attackFxPos.rotation);
                          
                            Destroy(tempPrefab, 6.0f);
                        }
                        */

                        attacker.attackSubject[i].transform.LookAt(checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<Transform>());
                        Animator[] hitController = attacker.attackSubject[i].GetComponentsInChildren<Animator>();


                        for (int j = 0; j < hitController.Length; j++)
                        {

                            hitController[j].Play("Hit", 0);

                        }


                        Debug.Log(attacker.attackSubject[i].name + "을 공격했음");
                     checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].transform.LookAt(attacker.attackSubject[i].transform.position);
                     attacker.attackSubject.RemoveRange(0, attacker.attackSubject.Count);
                     checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().hadAction = true;
                        break;
                    }


                }
            }
            

        }
        }
}
