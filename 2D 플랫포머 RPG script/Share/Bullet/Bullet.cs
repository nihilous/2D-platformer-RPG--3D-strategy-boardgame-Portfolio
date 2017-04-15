using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bullet : MonoBehaviour {

    public float _dirValue;             // 총알 발사방향
    public float _maxSpeed;             // 총알속도
    protected Rigidbody2D _rigidbody2d; // 물리엔진 컴포넌트 참조


    // 이부분은 GameObejct가 아니고 Object로 만들면  인스턴시에이트할때 GameObject로 casting해야함
    public GameObject _destroyEffectPrefab; // 총알이 파괴될때 생성할 이펙트
    public float _destroyEffectDestroyTime;
    public WeaponInfo bulletDamage;
 
    
    // 총알 초기화

    public virtual void Init(bool isRightDir)
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();

        // 방향 설정
        _dirValue = (isRightDir) ? 1 : -1;

    }



    // 이동 메소드

    public abstract void Move();

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
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

    protected virtual void OnTriggerEnter2D(Collider2D col) // 관통형
    {
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
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {

    }
}
