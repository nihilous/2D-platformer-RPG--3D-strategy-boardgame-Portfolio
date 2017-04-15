using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyChecker : MonoBehaviour {
    protected CharacterState _monsterState;
    Transform dragonPos;
    Transform playerPos;
    Movement flipper;
    public void PlayerCheckFlipper() // 플레이어가 뒤에서 칠경우
    {
        if (_monsterState._isDie != true)
        {


            Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, 10f, _monsterState._targetMask);

            foreach (Collider2D col in colliders)
            {
                if (col.tag == "Player")
                {

                    if (_monsterState._isRightDir == true && col.transform.localPosition.x < gameObject.transform.position.x)
                    {
                        
                        flipper.Flip(); 
                    }
                    if (_monsterState._isRightDir == false && col.transform.localPosition.x > gameObject.transform.position.x)
                    {
                        flipper.Flip();
                    }

                }
            }
        }
    }
       void Awake()
    {
        // 몬스터 상태 컴포넌트 참조
        _monsterState = gameObject.GetComponent<CharacterState>();
        flipper = gameObject.GetComponent<Movement>();
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
