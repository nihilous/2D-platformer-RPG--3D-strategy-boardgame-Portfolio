using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    protected Animator _animator;   // 애니메이터
    protected Rigidbody2D _rigidbody2d;     // 물리엔진

    protected float _prevMoveSpeed;     // 이전 몬스터 속도
    public float _moveSpeed;            // 몬스터 속도

    protected GameObject _player;       // 플레이어

    protected override void Awake()
    {
        base.Awake();

        _prevMoveSpeed = _moveSpeed;        // Resume에 사용할 스피드를 저장해둠, 시작하자마자 공격센서안에 플레이어가 있을시 어택스탑 0이 우선적으로 대입되기때문에 몬스터가 움직일수없는 문제를 해결해줌

        _animator = GetComponent<Animator>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }


    // 이동 재시작 AttackStop() IdleStop() 등에 의해 잠시 멈췄을경우
    public virtual void MoveResume()
    {

        // 속도 재설정

        _moveSpeed = _prevMoveSpeed;

        // 이동상태로 다시변경

        _characterState.state = CharacterState.State.Move;



    }
    // 공격을 위해 정지함( 속도0)
    public virtual void AttackStop()
    {

        // 정지 속도 설정
            
        _moveSpeed = 0;

    }

    // 대기 정지
    public virtual void IdleStop()
    {

        // 일시적인 대기 상태전환

        _characterState.state = CharacterState.State.Idle;

        //정지속도설정

        _moveSpeed = 0;

    }
    // 지정한 시간을 멈추는 처리
    public virtual void IdleTimeStop(float time)
    {
        // 이미 멈춰있으면 패스
        if (_characterState.state == CharacterState.State.Idle) return;

        // 멈춰있지 않으면 지정된 시간만큼 멈출것

        StartCoroutine("StopIdleDelayCoroutine", time);

    }

    public virtual IEnumerator StopIdleDelayCoroutine(float time)
    {
        IdleStop(); // 정지
        // 지연
        yield return new WaitForSeconds(time);
        MoveResume();
        
    }

    public virtual void Move()
    {
        // 이동상태를 변경함
       
        _characterState.state = CharacterState.State.Move;
        if (_animator)
        {
            _animator.SetBool("Move", true);
        }
    

    }




    protected virtual void Start()
    {


        // 플레이어를 참조함

        _player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // 이동
        
        Move();
        
    }
}