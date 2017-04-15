using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonBreathBullet : MonoBehaviour {

    public float _dirValue;             // 총알 발사방향
    public float _maxSpeed;             // 총알속도
    protected Rigidbody2D _rigidbody2d; // 물리엔진 컴포넌트 참조

    public bool _isPierce;
    // 이부분은 GameObejct가 아니고 Object로 만들면  인스턴시에이트할때 GameObject로 casting해야함
    public GameObject _destroyEffectPrefab; // 총알이 파괴될때 생성할 이펙트
    public float _destroyEffectDestroyTime;
    public WeaponInfo bulletDamage;
    public string _targetTag;

  
     


    public void BreathFlipper(bool isRightDir)       // 왼쪽을 보고있을시 화살의 방향을 자동으로 변경해줌
    {
        if (isRightDir != true)
        {
            transform.localScale = new Vector3(-1f, 1f);
        }
    }

    public virtual void Init(bool isRightDir, Vector2 targetVector)
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _dirValue = (isRightDir) ? 1 : -1;
        BreathFlipper(isRightDir);
        Move(targetVector); // 총알이동


    }



    void Move(Vector2 _breathDir)
    {
        _rigidbody2d.velocity = (_breathDir * _maxSpeed );

    }


    protected void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어 피격시
        if (collision.gameObject.tag == _targetTag)
        {
            Debug.Log("충돌했음");

            bulletDamage.damage = Random.Range(bulletDamage.minDamage, bulletDamage.maxDamage + 1);
            collision.gameObject.SendMessage("Damage", Mathf.Round(bulletDamage.damage));
            Debug.Log("데미지전달");
            // 총알을 파괴함

    
            Destroy(gameObject);
    


        }
        if (collision.gameObject.tag == "Ground")
        {
            if (_destroyEffectPrefab != null)
            {
                GameObject effect = Instantiate(_destroyEffectPrefab, transform.position, Quaternion.identity); // Quaternion.identity 
                Destroy(effect, _destroyEffectDestroyTime);
            }

            Destroy(gameObject);


        }




    }

    protected void OnTriggerEnter2D(Collider2D col)    // 몹은 istrigger가 되어있어서 총알이 istrigger가 아니어도
    {                                                       // 항상 관통하는거로 보이기때문에,, 관통형 비관통형 만들어야함
        // 플레이어 피격시                                 // 불타입 옵션 만들어서
        if (col.tag == _targetTag || col.tag == "Boss" + _targetTag)
        {


            Debug.Log("관통했음");
            bulletDamage.damage = Random.Range(bulletDamage.minDamage, bulletDamage.maxDamage + 1);
            col.SendMessage("Damage", Mathf.Round(bulletDamage.damage));
            Debug.Log("데미지전달");


            if (_isPierce == false) // 관통형총알은 플레이어가쏜.. 마법 평타일경우에 마나1씩올려줌
            {
               
               
                Destroy(gameObject);
          
            }

        }
        if (col.tag == "Ground")
        {
            if (_destroyEffectPrefab != null)
            {
                GameObject effect = Instantiate(_destroyEffectPrefab, transform.position, Quaternion.identity); // Quaternion.identity 
                Destroy(effect, _destroyEffectDestroyTime);
            }

            Destroy(gameObject);


        }
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
