using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : PlayerAttack {

    // Animator _animator;

    //   int _attackIndex = 1;

    /*
    public Transform _attackPoint;
    */
    public SkinnedMeshRenderer MagicEquipments;
//    public GameObject MagicEquipments;  // 이미지만.. 껏다켜야할듯함
    public Transform AttackFxPosition;
    public GameObject MagicAttackPrefab;
    public WeaponInfo magidDamageUp;
    /*
    public GameObject SkillPrefab01;
    public GameObject SkillPrefab02;
    public GameObject SkillPrefab03;

    PlayerSkill mpCheckMpDown;
    HpGageShare mpGageDown;
   public CrusaderHealSkill skillUse;
   */
    PlayerAudioSource polyPlay;

    protected override bool IsAttack()
    {
        // 전사의 공격 상태는 Attack1 ~ Attack3 애니메이션 상태를 의미함
        if (
            _animator.GetCurrentAnimatorStateInfo(0).IsName("MagicAttack1") ||
            _animator.GetCurrentAnimatorStateInfo(0).IsName("MagicAttack2"))
        {
            return true;
        }

        // else
        return false;
    }

    //

    public void MagicAttackFx()      // 공격 애니메이션에서 이벤트로 호출함 현재 프리팹 스프라이트는 y 플립상태
    {



        GameObject magicArrow = Instantiate(MagicAttackPrefab, AttackFxPosition.position, Quaternion.identity) as GameObject; ;
        magicArrow.SendMessage("Init", _cState._isRightDir);
        WeaponInfo arrowDamage = magicArrow.GetComponent<WeaponInfo>();

        arrowDamage.minDamage += magidDamageUp.minDamage;
        arrowDamage.maxDamage += magidDamageUp.maxDamage;
        Debug.Log(arrowDamage.minDamage);

    }

    protected override void Attack()
    {
        // 왼쪽의 X키를 누르면
        if (MagicEquipments.enabled == true && Input.GetKeyDown(KeyCode.X))
        {
            // 공격모션중이면 return~ 공격모션을 다마친후에 다음것동작
            if (IsAttack()) return;

            // string과 int가 있으면 형변환이 string으로 우선됨
            _attackIndex = Random.Range(1, 3);

            _animator.SetTrigger("MagicA" + _attackIndex);
            polyPlay.playPoly(1);
        }

    }
   

    protected override void Awake()
    {
        base.Awake();
        polyPlay = gameObject.GetComponent<PlayerAudioSource>();
    }
    
    void Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
    {

        base.Update();
 
    }
}
