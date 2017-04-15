using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMeleeAttack : MonoBehaviour {
    protected Transform _attackPoint;   // 공격위치
    public Transform _WeaponattackPoint;   // 공격위치
    protected Animator _animator;   // 애니메이터
    protected CharacterState _monsterState; // 몬스터 상태 컴포넌트 참조
    protected Rigidbody2D _rigidbody2d;
    protected EnemyMovement _monsterMove;
    public float weaponAttackRadious;

    public WeaponInfo weaponDamage;
   

    

   
    public virtual void Attack()
    {
        if (_WeaponattackPoint != null) // 무기들었으면
        {



            Collider2D[] colliders = Physics2D.OverlapCircleAll(_WeaponattackPoint.position, weaponAttackRadious, _monsterState._targetMask);

            // 플레이어데미지 작성해야함
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Player")
                {

                    weaponDamage.damage = Random.Range(weaponDamage.minDamage, weaponDamage.maxDamage + 1);

                    collider.SendMessage("Damage", Mathf.Round(weaponDamage.damage));
    


                    return;

                }
            }
        }
    }

    public virtual void AttackReady()
    {
        _monsterMove.AttackStop();
        // 공격 상태 변경

        _monsterState.state = CharacterState.State.Attack;
        // 공격 애니메이션


        _animator.SetTrigger("AttackTrigger2");

    }
    

    public virtual void AttackFinish()
    {

        // 대기 상태 변경

        _monsterState.state = CharacterState.State.Idle;
        // 대기 애니메이션

//        _animator.SetBool("Attack2", false);

        _rigidbody2d.constraints = RigidbodyConstraints2D.None;     // 리짓바디 x걸었던거풀어줌
        _monsterMove.MoveResume();

    }
    public void MeleeAttackAnimationEvent()
    {
        Attack();
    }
    public void MeleeAttackFinishAnimationEvent()
    {

        AttackFinish();

    }
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
        _monsterMove = GetComponent<EnemyMovement>();


    }

    // Update is called once per frame
    void Update()
    {

    }
}