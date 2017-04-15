using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHorizontalCrossMovement : EnemyMovement
{


    protected override void Start()
    {
        base.Start();

    }


    protected override void Update()
    {
        if (_characterState._isDie == true)     // 죽었으면 더 이동안함

        {
            _rigidbody2d.constraints = RigidbodyConstraints2D.FreezePositionX;
            return;
        }                              // 먹힐때있고 안먹힐때있어서
        base.Update();
    //    }
    }

    public override void Move()
    {


        base.Move();    // 기본 이동 로직 수행
        // 시선 방향에 맞게 지정한 속도로 이동함
        _rigidbody2d.velocity = new Vector2((_characterState._isRightDir) ? _moveSpeed : -_moveSpeed, _rigidbody2d.velocity.y);
    }

    // Trigger 충돌 이벤트
    void OnTriggerEnter2D(Collider2D col)
    {
        // 터닝 포인트랑충돌했다면
        if (col.tag == "TurnPoint")
        {
            Flip(); // 방향전환
        }

    }


}
