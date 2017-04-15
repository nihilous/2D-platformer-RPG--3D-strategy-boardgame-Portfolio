using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAttack : EnemyAttack {

    // 몬스터 타겟 체크 컴포넌트 참조
    protected MonsterTargetChecker _targetChecker;
    // 몬스터 이동 컴포턴트 참조
    protected EnemyMovement _monsterMove;
    public WeaponInfo weaponDamage;
    float OriginalMinDamage;
    float OriginalMaxDamage;


    protected override void Awake()
    {
        base.Awake();
        _targetChecker = GetComponent<MonsterTargetChecker>();
        _monsterMove = GetComponent<EnemyMovement>();
        if(weaponDamage != null)
        {
OriginalMinDamage=           Mathf.Round(weaponDamage.minDamage);
            OriginalMaxDamage = Mathf.Round(weaponDamage.maxDamage);

        }

    }
    // 공격준비(시작)
    public override void AttackReady()
    {
        // 이동정지
        _monsterMove.AttackStop();
        // 공격준비
        base.AttackReady();

    }

    // 공격       어떤공격을할지는 무브샷, 무브스윙에서 각각해줄것
    public override void Attack()
    {   
//        아쳐가 활쏘고 움직이는문제는,, 애니메이션이 늦게풀리는것 뿐이었음
    //       _rigidbody2d.constraints = RigidbodyConstraints2D.FreezePositionX;
    //    _rigidbody2d.velocity = Vector2.zero;
       // _rigidbody2d.velocity = new Vector2(0f,0f);
    }


    // 공격종료
    public override void AttackFinish()
    {
        base.AttackFinish();
        // 몬스터 이동재개

        //   _rigidbody2d.constraints = RigidbodyConstraints2D.None;     // 리짓바디 x걸었던거풀어줌
        //  _rigidbody2d.velocity = Vector2.zero;
        _animator.speed = 1;
        if (weaponDamage != null)
        {
            weaponDamage.minDamage = OriginalMinDamage;
            weaponDamage.maxDamage = OriginalMaxDamage;
        }
        _monsterMove.MoveResume();
        // 몬스터 공격 타겟 체크
    //    _targetChecker.FrontTargetChecker(this);  // 코루틴에 딜레이줬고 이부분 주석막았음
    }

    // 예전에는 오버라이드한경우에는 메소드가 애니메이션 이벤트 에서 안잡혔었는데 요즘은 굳이.. 이럴필요없고 바로 Attack, AttackFinish 호출해서 써도됨

    public void AttackAnimationEvent()
    {
        Attack();
    }
    public void AttackFinishAnimationEvent()
    {

        AttackFinish();

    }


    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        // 몬스터  공격 타겟 체크
        _targetChecker.FrontTargetChecker(this);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
