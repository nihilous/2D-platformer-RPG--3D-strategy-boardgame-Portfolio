using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveShotAttack : EnemyMoveAttack {

    public GameObject _bulletPrefab;
    

    public override void Attack()
    {
        // Debug.Log("Shot Attack!!!");

        // 총알발사
        base.Attack();

        GameObject bullet = Instantiate(_bulletPrefab, _attackPoint.position, Quaternion.identity) as GameObject;

        bullet.SendMessage("Init", _monsterState._isRightDir);
        
       if (gameObject.name == "SkeletonArcher")
        {
            polyPlay.playPoly(1);
        }
       else if (gameObject.name == "BossWoodGolem")
        {
            polyPlay.playPoly(4);
        }

    }


}
