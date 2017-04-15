using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DirectBullet : Bullet {

    public bool _isPierce;

    public string _targetTag; // 공격 타겟 태그 이름

    PlayerSkill magicArrowManaUp;
    



    public void ArrowFlipper(bool isRightDir)       // 왼쪽을 보고있을시 화살의 방향을 자동으로 변경해줌
    {
        if (isRightDir!=true)
        {
            transform.localScale = new Vector3(-1f, 1f);
        }
    }

    // 직선총알 초기화 (방향)
    public override void Init(bool isRightDir)
    {
       
        base.Init(isRightDir);
        ArrowFlipper(isRightDir);
        Move(); // 총알이동


    }


    // 총알 이동을 처리함
    public override void Move()
    {

        // 지정한 방향과 속도로 총알이 이동함
        _rigidbody2d.velocity = new Vector2(_dirValue * _maxSpeed, _rigidbody2d.velocity.y);

    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어 피격시
        if (collision.gameObject.tag == _targetTag)
        {

            bulletDamage.damage = Random.Range(bulletDamage.minDamage, bulletDamage.maxDamage + 1);
            collision.gameObject.SendMessage("Damage", Mathf.Round(bulletDamage.damage));


            
            // 총알을 파괴함
            Destroy(gameObject);
        

        }


        // 벽 충돌시
        base.OnCollisionEnter2D(collision);




    }

    protected override void OnTriggerEnter2D(Collider2D col)    // 몹은 istrigger가 되어있어서 총알이 istrigger가 아니어도
    {                                                       // 항상 관통하는거로 보이기때문에,, 관통형 비관통형 만들어야함
        // 플레이어 피격시                                 // 불타입 옵션 만들어서
        if (col.tag == _targetTag || col.tag == "Boss" + _targetTag)
        {

            
            bulletDamage.damage = Random.Range(bulletDamage.minDamage, bulletDamage.maxDamage + 1);
            col.SendMessage("Damage", Mathf.Round(bulletDamage.damage));
 
            if (_isPierce == false) // 관통형총알은 플레이어가쏜.. 마법 평타일경우에 마나1씩올려줌
                {
                if (gameObject.tag == "PlayerBullet")

                    magicArrowManaUp =  GameObject.Find("Player").GetComponentInChildren<PlayerSkill>();
                    magicArrowManaUp.plusMp();
                    Destroy(gameObject);
        
            }

        }


        // 벽 충돌시
        base.OnTriggerEnter2D(col);
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
