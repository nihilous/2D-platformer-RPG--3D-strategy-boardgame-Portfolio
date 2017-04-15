using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMoveSwingAttack : EnemyMoveAttack
{
    public float weaponAttackRadious;
    
    
    
    // 정해결 안되면 Instantiate하게하고 Instantiate한것은 자동으로 사라지게
    

    public override void Attack()
    {
        base.Attack();

        /*
        // 공격       이부분 무쓸모
        if(_WeaponattackPoint==null) // 맨손이면
        {                                                   // 원본 _attackPoint.position
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_attackPoint.position, weaponAttackRadious, _monsterState._targetMask);

          // 플레이어데미지 작성해야함
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Player")
            {
                collider.SendMessage("Damage", weaponDamage.damage);
                return;

            }
        }

        }
        */

        // 원ㄹ else if
        if (_WeaponattackPoint != null) // 무기들었으면
        {
            if (gameObject.name == "SkeletonSwordMan")
            {
                polyPlay.playPoly(0);
            }


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

    protected override void Awake()
    {
        base.Awake();
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}
