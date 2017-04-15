using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement {

    public float _speed;

    [HideInInspector]

    public Rigidbody2D _rigidbody2d;
    
    // 스프라이트

 //   SpriteRenderer _spriteRenderer;
    // 애니메이터

    Animator _animator;
    // 이동속도

    public bool _isJump = false;// 1단점프 유무
    public bool _isDoubleJump = false; // 2단점프 유무
    // 점프크기(힘)
    public float _jumpPower;
    // 지면위여부
    public bool _isGround = false;

   public Transform skyTransform;
    public Transform chatBox;

    public SkinnedMeshRenderer TwoHandSword;
    bool _isTwoHandSword;

    public SkinnedMeshRenderer MagicEquipments;
    bool _isMagic;


    public void BackGroundFlip()
    {

        Vector3 skyScale=  skyTransform.transform.localScale;
        Vector3 chatScale = chatBox.transform.localScale;
        skyScale.x *= -1;
        chatScale.x *= -1;
        skyTransform.transform.localScale = skyScale;
        chatBox.transform.localScale = chatScale;
    }

    public virtual void Move()
    {
        
        float h = Input.GetAxis("Horizontal");


        if ((_characterState._isRightDir && h < 0) || (!_characterState._isRightDir && h > 0))
        {
            Flip(); // CMove.Flip() 호출
            BackGroundFlip();
        }

        // 캐릭터에 속도를 부여함
        _rigidbody2d.velocity = new Vector2(h * _speed, _rigidbody2d.velocity.y);

       


        // 이동 애니메이션을 수행함
        _animator.SetFloat("Horizontal", h);

        
        // 수직 상승하강 속도를 애니메이터에 알려줌
        _animator.SetFloat("Vertical", _rigidbody2d.velocity.y);
   
        
    }


    
        public void Jump(float jumpPower)
        {
            _animator.SetTrigger("Jump");
            // 점프 초기화

            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, 0f);

            // 점프
            _rigidbody2d.AddForce(Vector2.up * jumpPower);
        }

        void InputJump()
        {
            // 왼쪽 컨트롤키를 누르면
            if (Input.GetKeyDown(KeyCode.Z))
            {
                // 점프를 안한상태면
                if (!_isJump) // _isJump == false    현재   !_isJump == true
                {
                    Jump(_jumpPower); // 점프수행
                    _isJump = true; // 점프를 한상태로 변경

                }
                // 이미 점프 한 상태에서 2단 점프를 하지 않은 상태면
                else if (_isJump && !_isDoubleJump)
                {
                    Jump(_jumpPower); // 점프 수행

                    _isDoubleJump = true; // 이단 점프를 한 상태로 변경
                }
            }
        }

    protected override void Awake()
    {
        base.Awake();
        _rigidbody2d = GetComponent<Rigidbody2D>();
      //  _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(_characterState._isDie!=true)
        { 

        if(TwoHandSword.enabled==true )
        {
            _isTwoHandSword = true;
            _animator.SetBool("TwoHandSwordActiveSelf", _isTwoHandSword);
            Move();
        }
        if(TwoHandSword.enabled == false)
        {

                _isTwoHandSword = false;
                _animator.SetBool("TwoHandSwordActiveSelf", _isTwoHandSword);
                Move();
        }

        if(MagicEquipments.enabled == true)
            {
                _isMagic = true;
                _animator.SetBool("MagicActive", _isMagic);
                Move();
            }
        if(MagicEquipments.enabled ==false)
            {
                {
                    _isMagic = false;
                    _animator.SetBool("MagicActive", _isMagic);
                    Move();
                }


            }


        InputJump();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // 캐릭터가 지면에 충돌 했다면
        if (col.gameObject.tag.Equals("Ground") || col.gameObject.tag.Equals("MoveGround"))
        {
            GroundSetting(true);
            _isJump = _isDoubleJump = false;

            // 이동 블럭의 경우
            if (col.gameObject.tag.Equals("MoveGround"))    // 무브그라운드에 접촉하면 무브그라운드의 자식이됨
            {
                // 캐릭터를 이동 블럭의 자식으로 등록함
                transform.SetParent(col.transform);
            }
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            GroundSetting(true);
        }
    }


    void OnCollisionExit2D(Collision2D col)
    {
        // 캐릭터가 지면에서 떨어졌다면
        if (col.gameObject.tag.Equals("Ground") || col.gameObject.tag.Equals("MoveGround"))
        {
            GroundSetting(false);

            // 이동블럭의 경우
            if (col.gameObject.tag.Equals("MoveGround"))    // 무브그라운드를 떠나면 셋페어런츠가 null이됨
            {
                // 캐릭터를 이동 블럭의 자식으로 등록함
                transform.SetParent(null);
            }


        }
    }



    void GroundSetting(bool isGround)
    {

        _isGround = isGround;



        _animator.SetBool("IsGround", isGround);

    }


}
