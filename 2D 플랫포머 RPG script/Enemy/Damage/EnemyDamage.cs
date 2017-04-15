using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    public Transform _damageEffectPos;          // 타격 이펙트 효과 위치
    public GameObject _damageEffectPrefab;      // 타격이펙트 프리팹
                                                //    public float _damageStopDelayTime;          // 데미지 충격시 이동지연시간
    protected CharacterState _monsterState;    // 몬스터상태
   protected Animator _animator;                         // 애니메이터


    protected ItemDrop _itemDrop;

    public EnemyMovement _monsterMovement;

    protected Movement flipper;

   

    public BossAppear bossGener;


    protected BoxCollider2D onOffCollider;

    public Image damageUIImage;
    public Text damageUIText;

    DamageText dtCoroutinCall;

    BossAppear bossIsDead;

    ForeignSound polyPlay;


    // protected CDestroyer _destroyer;

    protected void Awake()
    {
        _monsterState = GetComponent<CharacterState>();
        _animator = GetComponent<Animator>();
        //       _destroyer = GetComponent<CDestroyer>();
        _itemDrop = GetComponent<ItemDrop>();
        flipper = GetComponent<Movement>();
        bossGener =   GameObject.Find("MonsterDeathCountManager").GetComponentInChildren<BossAppear>();
        onOffCollider = gameObject.GetComponentInChildren<BoxCollider2D>();
        polyPlay = GameObject.Find("ForeignSoundManager").GetComponent<ForeignSound>();

        if (gameObject.tag == "BossEnemy")
        {
         bossIsDead = GameObject.Find("MonsterDeathCountManager").GetComponentInChildren<BossAppear>();

            
        }
 
        dtCoroutinCall = GetComponent<DamageText>();

    }



    // 피격처리
    public void DamageFlipper() // 플레이어가 뒤에서 칠경우
    {
   GameObject player = GameObject.Find ("Player");

        


        
            if (_monsterState._isRightDir == true && player.transform.localPosition.x < gameObject.transform.position.x)
            {
                flipper.Flip(); 


          //  Debug.Log(gameObject.transform.position.x - player.transform.localPosition.x);
            if(gameObject.transform.position.x - player.transform.localPosition.x >= 10)
            { 
            RangeCounterAttack();
            }

        }
            if (_monsterState._isRightDir == false && player.transform.localPosition.x > gameObject.transform.position.x)
            {
                flipper.Flip();

        //    Debug.Log(gameObject.transform.position.x - player.transform.localPosition.x);
            if (gameObject.transform.position.x - player.transform.localPosition.x <= -10)
            {
                RangeCounterAttack();
            }
            }
        
    }

    protected virtual void RangeCounterAttack()
    {

    }


    public void Damage(float damage)
    {

        // 몬스터의 체력을 감소함
        if (_monsterState._isDie != true) // 에너미무브 업데이트 부분 걸러줬음
        {
            GameObject effect = Instantiate(_damageEffectPrefab, _damageEffectPos.position, Quaternion.identity);
        }
        _monsterState._hp -= damage;

        if (gameObject.name == "SkeletonSwordMan" || gameObject.name == "SkeletonArcher")
        {
            polyPlay.playPoly(2);
        }
        else if (gameObject.name == "Zombie")
        {
            polyPlay.playPoly(7);
        }
        else if (gameObject.name == "BossWoodGolem")
        {
            polyPlay.playPoly(6);
        }
        else if (gameObject.name == "Dragon")
        {
            polyPlay.playPoly(9);
        }
        StartCoroutine(dtCoroutinCall.AttackDamageShow(damageUIImage, damageUIText, damage));
        DamageFlipper();    // 뒤에서 공격받을시 좌우반전
        if (_monsterState._hp <= 0 ) // 에너미무브 업데이트 부분 걸러줬음
        {
            if (gameObject.name == "SkeletonSwordMan" || gameObject.name == "SkeletonArcher")
            {
                polyPlay.playPoly(3);
            }
            BossAppear.enemyDeathCount++;

            if (gameObject.tag== "BossEnemy")
            {
                bossIsDead.BossKilled();
            }

            Debug.Log(BossAppear.enemyDeathCount + "보스 카운트");
            
            bossGener.BossGen();
            
            _monsterState.state = CharacterState.State.Die;


            _animator.SetBool("Move", false);
            _monsterState._isDie = true;
            _animator.SetTrigger("Die");
            //_animator.Play("Die");
            gameObject.tag = "Untagged";        // 죽고나면 스캔안되고 안맞게
            gameObject.layer = 0;
 
        }

        if (_monsterMovement != null)   
        {
            // 피격당하면 0.5초간 이동을중지함
            _monsterMovement.IdleTimeStop(0.5f);
        }




        // 이펙트가 생성됩니다       // 예전에는 캐스팅이 필요했음 (Object형이라서) 반환형이.. 현재는 게임오브젝트형으로 리턴하기때문에 캐스팅불필요
        //_monsterState._hp >= 0 &&
      
            //  Destroy(effect, 0.25f); // 0.25초후에 이펙트 삭제 현재 오토디스트로이 해둠
        


        // 피격 애니메이션 재생
        if (_monsterState._isDie != true)
        { 
        _animator.Play("Damage", 1);    // 레이어 1에있는 데미지 재생
        }
    }




    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 
    }
}