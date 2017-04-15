using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHandSword : PlayerAttack
{
   // Animator _animator;

 //   int _attackIndex = 1;

    /*
    public Transform _attackPoint;
    */
    public SkinnedMeshRenderer LHTwoHandSword;
    public Transform AttackFxPosition;
    public GameObject TwoHandSwordAttackFx;
    PlayerAudioSource polyPlay;

    protected override bool IsAttack()
    {
        // 전사의 공격 상태는 Attack1 ~ Attack3 애니메이션 상태를 의미함
        if (
            _animator.GetCurrentAnimatorStateInfo(0).IsName("TwoHandAttack1") ||
            _animator.GetCurrentAnimatorStateInfo(0).IsName("TwoHandAttack2") ||
            _animator.GetCurrentAnimatorStateInfo(0).IsName("TwoHandAttack3"))
        {
            return true;
        }

        // else
        return false;
    }

  //
  
        public void AttackFx()      // 공격 애니메이션에서 이벤트로 호출함 현재 프리팹 스프라이트는 y 플립상태
    {
        Instantiate(TwoHandSwordAttackFx, AttackFxPosition.position, AttackFxPosition.rotation);
    }
          
   protected override void Attack()
    {
        // 왼쪽의 X키를 누르면
        if (LHTwoHandSword.enabled == true && Input.GetKeyDown(KeyCode.X))
        {
            // 공격모션중이면 return~ 공격모션을 다마친후에 다음것동작
            if (IsAttack()) return;

            // string과 int가 있으면 형변환이 string으로 우선됨
            _attackIndex = Random.Range(1, 4);

            _animator.SetTrigger("TwoHandSwordA" + _attackIndex);
            polyPlay.playPoly(0);
//            if (_attackIndex > 3) _attackIndex = 1;
        }

    }
  

    protected override void Awake()
    {
        base.Awake();
        polyPlay = gameObject.GetComponent<PlayerAudioSource>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
   protected override void Update()
    {

        base.Update();
  
    }
}
