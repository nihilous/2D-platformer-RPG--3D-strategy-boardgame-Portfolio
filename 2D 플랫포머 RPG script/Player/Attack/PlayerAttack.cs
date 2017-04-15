using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {
    protected Animator _animator;
protected CharacterState _cState ;
   protected int _attackIndex = 1;

    public Transform _attackPoint;

    public WeaponInfo _weaponDamage;
    Image enemyDamageUIImage;
    Text enemyDamageUIText;
    RectTransform enemyDamageUITextFlipper;

    public PlayerSkill mpUp;

    // 3D에서는 판정이 쉽지만 2D에서 어려운부분이있기때문에  때릴때마다 콜라이더 생성해줌 
    // 포인트 하나 정해놓고 그위에 판정박스 열어줌.  애니메이션상에서   메소드 호출해줌
    // 이부분에 덱스를 이용한 랜덤값으로... 미스라던가  크리티컬 해줄수있음
    public void AttackAnimationEvent()
    {

        // 공격 포인트에서 1반지름 안에 들어오는 몬스터들의 콜라이더를 검출함
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_attackPoint.position, 0.85f, 1 << LayerMask.NameToLayer("Enemy"));
        // OverlapCircleAll 은 복수의 오브젝트를 검출함, 디테일하게 나누려면 태그와 레이어를 같이써도됨



        // 검출된 콜라이더에서

        foreach (Collider2D collider in colliders)
        {
            // 몬스터에게

            if (collider.tag == "Enemy" || collider.tag == "BossEnemy")
            {
                mpUp.plusMp();

                // 피격 처리를 요청함   인터페이스를 안쓰고 데미지 주려고 센드메세지사용함


                // 이부분에 덱스를 이용한 랜덤값으로... 미스라던가  크리티컬 해줄수있음

                _weaponDamage = GameObject.Find("LHTwoHandSword").GetComponent<WeaponInfo>();

                _weaponDamage.damage = Random.Range(_weaponDamage.minDamage, _weaponDamage.maxDamage + 1);
             
                collider.SendMessage("Damage", Mathf.Round(_weaponDamage.damage));
                return;  // 리턴하는이유는 1마리씩만 때리려고
            }
        }


    }

    // 공격시 컴포넌트검색
    public void AttackDamageUIOpen(Collider2D col, int damageFromPlayer)
    {
       enemyDamageUIImage = col.GetComponentInChildren<Image>();
       enemyDamageUIText = col.GetComponentInChildren<Text>();
 //       enemyDamageUITextFlipper = col.GetComponentInChildren<RectTransform>();   is direction 에서 확인할 문제였음
 //       enemyDamageUITextFlipper = enemyDamageUITextFlipper.Find("DamageText").GetComponent<RectTransform>();
        StartCoroutine("EnemyAttackDamageShow", damageFromPlayer);

    }

    // UI열어주고 일정시간후 닫아주고
    IEnumerator EnemyAttackDamageShow(float damageFrom)
    {
        enemyDamageUIImage.enabled = true;
        enemyDamageUIText.enabled = true;
//        enemyDamageUITextFlipper.localScale = new Vector3(-1f, 1);  // 몬스터 좌우 보는것에따라 숫자가 좌우 반전되서 나와서  is direction 에서 확인할문제였음
        enemyDamageUIText.text = damageFrom.ToString();

        yield return new WaitForSeconds(0.2f);
        enemyDamageUIImage.enabled = false;
        enemyDamageUIText.enabled = false;
        StopCoroutine("EnemyAttackDamageShow");
    }

    protected virtual bool IsAttack()
    {
        return false;
    }

    protected virtual void Attack()
    {

    }

   protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
        _cState = GetComponent<CharacterState>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        if(_cState._isDie!=true)
        { 
        Attack();
        }
    }
}
