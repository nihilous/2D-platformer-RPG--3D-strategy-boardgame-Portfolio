using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour {

    CharacterState _state;
    Animator _animator;
    HpGageShare _hpGager;
    public Transform _fxPosition; 
    public GameObject _damagePrefab;
    DamageText dtCoroutinCall;
    public Image damageUIImage;
    public Text damageUIText;
    ChatBoxController chatCon;
    public static bool deathInteract;
    PlayerAudioSource polyPlay;

   public Collider2D[] colliders;
    public PhysicsMaterial2D frictionMax;

    public void Awake()
    {
        _state = GetComponent<CharacterState>();
        _animator = GetComponent<Animator>();
        _hpGager = GetComponent<HpGageShare>();
        dtCoroutinCall = GetComponent<DamageText>();
        chatCon = gameObject.GetComponent<ChatBoxController>();
        deathInteract = true;
        polyPlay = gameObject.GetComponent<PlayerAudioSource>();
    }

    




    // 이부분 몬스터별로 데미지 줄수있게... parameter int형으로 만들고 호출해야할듯 몬스터 데미지도 각각해주고
    public void Damage(float damage)

    {
        // _state.state == CharacterState.State.Damage ||  이부분은 idle전환에서 문제가 많아서 빼버림
        if (_animator.GetCurrentAnimatorStateInfo(1).IsName("Damage"))
            return;
        Instantiate(_damagePrefab, _fxPosition.position, Quaternion.identity);

        _hpGager.HpDown(damage);

        _state._hp -= damage;

        StartCoroutine(dtCoroutinCall.AttackDamageShow(damageUIImage, damageUIText, damage));
        polyPlay.playPoly(5);



        // 플레이어의 상태를 데미지 상태로 변경함
        _state.state = CharacterState.State.Damage;
        // 피격 애니메이션을 실행함
        _animator.Play("Damage", 1);


        if (_state._hp<=0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].sharedMaterial = frictionMax;
            }


            deathInteract = false;
            _state._isDie = true;
            _animator.SetTrigger("Die");
            _animator.Play("Die");
            gameObject.tag = "Untagged";        // 죽고나면 스캔안되고 안맞게
            gameObject.layer = 0;
            StartCoroutine(chatCon.ChatBoxOpener("엌ㅋㅋㅋ.."));
            DeadPannelOpen openD = GameObject.Find("ButtonPanel").GetComponent<DeadPannelOpen>();
            openD.DeathPannelOpen();
        }



    }

    public void DamageAnimationEndEvent()
    {

        _state.state = CharacterState.State.Idle;
    

    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /* 죽는모션 확인
        if (_state._isDie == true)
        {
            _animator.Play("Die");
        }
        */

    }
}
