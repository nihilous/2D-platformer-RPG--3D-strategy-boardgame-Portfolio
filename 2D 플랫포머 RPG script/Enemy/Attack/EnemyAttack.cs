using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    protected Transform _attackPoint;   // 공격위치
    public Transform _WeaponattackPoint;   // 공격위치
    protected Animator _animator;   // 애니메이터
    protected CharacterState _monsterState; // 몬스터 상태 컴포넌트 참조
    protected Rigidbody2D _rigidbody2d;
   protected ForeignSound polyPlay;
    protected virtual void Awake()
    {
        // 애니메이터 컴포넌트 참조
        _animator = GetComponent<Animator>();

        // 몬스터 상태 컴포넌트 참조
        _monsterState = GetComponent<CharacterState>();

        // 공격위치 참조
        _attackPoint = transform.FindChild("AttackPoint").transform;

        // 공격시 잠시 멈춤, 벨로시티 사용이라서 x잠궈줘야함

        _rigidbody2d = GetComponent<Rigidbody2D>();
        polyPlay = GameObject.Find("ForeignSoundManager").GetComponent<ForeignSound>();
        



    }

    protected virtual void Start()
    {

    }

    public virtual void AttackReady()
    {
        // 공격 상태 변경
        
        _monsterState.state = CharacterState.State.Attack;
        // 공격 애니메이션

        _animator.SetTrigger("AttackTrigger");  // 트리거가 더 효율 좋은듯함
       
        //  _animator.SetBool("Attack", true);

    }

    public abstract void Attack();

    public virtual void AttackFinish()
    {

        // 대기 상태 변경

        _monsterState.state = CharacterState.State.Idle;
        // 대기 애니메이션
        
      //  _animator.SetBool("Attack", false);



    }


    // Update is called once per frame
    void Update()
    {

    }
}