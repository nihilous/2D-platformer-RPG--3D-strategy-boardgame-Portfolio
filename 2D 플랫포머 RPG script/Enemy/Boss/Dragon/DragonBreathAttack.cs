using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBreathAttack : MonoBehaviour {

    Transform _breathGenPoint;

   public GameObject dbPrefab;

    Transform dragonPos;
    Transform playerPos;
    Vector2 targetVector;
    protected CharacterState _monsterState;
    protected Animator _animator;   // 애니메이터
    protected Movement flipper;

    protected virtual void Awake()
    {
        // 애니메이터 컴포넌트 참조
        _animator = GetComponent<Animator>();

        // 몬스터 상태 컴포넌트 참조
        _monsterState = GetComponent<CharacterState>();

        // 공격위치 참조
    _breathGenPoint = transform.FindChild("BossRangeWeaponAttackPoint").transform;
        flipper = GetComponent<Movement>();
        // 공격시 잠시 멈춤, 벨로시티 사용이라서 x잠궈줘야함

        //    _rigidbody2d = GetComponent<Rigidbody2D>();

    }

    // 최초위치가 계속 적용되서
   public void DragonPlayerSense()
    {
        if (_monsterState._isDie != true)
        {


            Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, 10f, _monsterState._targetMask);

            foreach (Collider2D col in colliders)
            {
                if (col.tag == "Player")
                {
                    _animator.SetTrigger("AttackTrigger");

                    playerPos = col.transform;

                    dragonPos = gameObject.transform;


                    targetVector = (playerPos.position - dragonPos.position).normalized;


                    AttackFlipper(playerPos);// 플리퍼안에서 다시구해서 쏴야할듯







                    GameObject db = Instantiate(dbPrefab, _breathGenPoint.position, _breathGenPoint.rotation);
                    DragonBreathBullet dbBullet = db.GetComponentInChildren<DragonBreathBullet>();
                    dbBullet.Init(_monsterState._isRightDir, targetVector);




                    //   StartCoroutine(ShootBreath(targetVector));
                    CancelInvoke("DragonPlayerSense");
                    StartCoroutine(ShootAgain());

                    //      InvokeRepeating("DragonPlayerSense", 0f, 1f);

                    break;

                }
            }
        }
    }


    IEnumerator ShootAgain()
    {
        int i = 0;
        while (i<1)
        {
            
            yield return new WaitForSeconds(0.9f);
            


            InvokeRepeating("DragonPlayerSense", 0f, 1f);
            i++;
            StopCoroutine("ShootBreath");

            //  

        }

    }


    /*
    
    
    IEnumerator ShootBreath (Vector2 shootToWhere)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.9f);
            StopCoroutine("ShootBreath");

            GameObject db = Instantiate(dbPrefab, _breathGenPoint.position, _breathGenPoint.rotation);

            DragonBreathBullet dbBullet = db.GetComponentInChildren<DragonBreathBullet>();

            dbBullet.Init(_monsterState._isRightDir, shootToWhere);
            //    InvokeRepeating("DragonPlayerSense", 0f, 1f);


            //   CancelInvoke("DragonPlayerSense");
           
            InvokeRepeating("DragonPlayerSense", 0f, 1f);
            yield return null;
            Debug.Log("코루틴 도니?");

           
            

        }

    }
    
    */

    public void AttackFlipper(Transform player ) // 플레이어가 뒤에서 칠경우
    {
      // 플레이어는 로컬포지션이 있는데,,  몬스터는 이동할때 로컬포지션이 젠포지션 기준임..
      
        if (_monsterState._isRightDir == true && player.transform.localPosition.x < gameObject.transform.position.x)
        {
            flipper.Flip();

            //
        }
        if (_monsterState._isRightDir == false && player.transform.localPosition.x > gameObject.transform.position.x)
        {
            flipper.Flip(); 
        }

    }




    // Use this for initialization

    void Start () {
        InvokeRepeating("DragonPlayerSense", 0f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
