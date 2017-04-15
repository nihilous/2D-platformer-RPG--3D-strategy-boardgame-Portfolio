using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTargetChecker : MonoBehaviour
{

    protected CharacterState _monsterState; // 몬스터 상태 컴포넌트 참조
    public CharacterState.State _checkState; // 체크할 상태 설정

    public float _checkRange;   // 체크범위
    protected Transform _attackPoint;   // 체크시작위치(공격위치)
    protected Transform _playerPos; // 플레이어위치

    public float AttackDelay;
    void Awake()
    {

        _monsterState = GetComponent<CharacterState>();
        _attackPoint = transform.FindChild("AttackPoint").transform;
    }

    // 몬스터 센서링 가동

    public void FrontTargetChecker(EnemyAttack monsterAttack)
    {
        StartCoroutine("FrontTargetCheckCoroutine", monsterAttack);
    }


    IEnumerator FrontTargetCheckCoroutine(EnemyAttack monsterAttack)
    {
        // 몬스터가 대기상태라면 감시를 진행함
        while (_monsterState.state == _checkState)  // 인스펙터부분
        {
            // 수평 방향으로 발포 감지 레이저를 발사함
            Vector2 endPos = new Vector2(_attackPoint.position.x - ((_monsterState._isRightDir) ? -_checkRange : _checkRange), _attackPoint.position.y);

            // 충돌 체크 디버그 레이저 발사
            // DrawLine은 씬에서는 보이고 게임에서는 보이지않음
            Debug.DrawLine(_attackPoint.position, endPos, Color.green); // 어디서, 어디까지, 어떤색으로 이하의 hitInfo 검출 길이만큼 선을그려줌. 선자체에 검출기능이 있는것은아님, 가시적으로 보기편하게하기위해서

            //----

            // 라인체크
            // Physics2D.Linecast(라인시착위치, 라인끝위치, 검출레이어)
            // 2D에 맞춰서 Raycast를 변화시킨게 Linecast라는듯   피직스는 물리관련인데 그중에서도 cast가붙으면 충돌체크
            RaycastHit2D hitInfo = Physics2D.Linecast(_attackPoint.position, endPos, _monsterState._targetMask);
            // 충돌체가 존재한다면
            if (hitInfo.collider != null)
            {
                // 공격 시작

                monsterAttack.AttackReady();

                yield return new WaitForSeconds(AttackDelay);
            }

            yield return null;

        }

    }

    public void CircleAreaTargetChecker(EnemyAttack monsterAttack)
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        // Debug.Log("player pos =>" + _playerPos.position);

        StartCoroutine("CircleAreaTargetCheckCoroutine", monsterAttack);
    }


    public IEnumerator CircleAreaTargetCheckCoroutine(EnemyAttack monsterAttack)
    {
        // Physics2D.CircleCast 라는 기능도 생겼기때문에.. 이부분은 나중에  이하와 같은개념이라 테스트해봐야함


        // 몬스터가 대기상태라면 감시를 진행함
        while (_monsterState.state == _checkState)
        {
            float distance = Vector2.Distance(_attackPoint.position, _playerPos.position);

            // Debug.Log("player pos =>" + _playerPos.position);

            if (distance < _checkRange)
            {
                // 공격시작
                monsterAttack.AttackReady();

            }

            yield return null;


        }



    }



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}