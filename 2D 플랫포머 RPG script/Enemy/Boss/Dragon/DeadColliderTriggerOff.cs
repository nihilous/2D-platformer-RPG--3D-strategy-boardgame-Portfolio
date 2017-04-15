using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadColliderTriggerOff : MonoBehaviour {

    public Collider2D[] colliders;

    Rigidbody2D yHolder;
    CharacterState _monsterState;
    Vector2 deadPosition;
    bool deadBool;
    /*

    public void OnTriggerEnter2D (Collider2D col)
    {
        if(col.tag == "Ground")
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].isTrigger = false;
            }
           yHolder.constraints = RigidbodyConstraints2D.FreezePositionY;
           yHolder.constraints = RigidbodyConstraints2D.FreezePositionX;
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].isTrigger = true;
            }
        }
     }
     */

void        OnTriggerEnter2D  (Collider2D col)
    {
        if (col.tag == "Ground" && _monsterState._isDie == true)
        {
            deadPosition = gameObject.transform.position;
            deadBool = true;
        }
    }

    void DeadPositionHolder (bool dieTrue)
    { 
      if( dieTrue)
        {     
                gameObject.transform.position = deadPosition;
            yHolder.gravityScale = 0f;
        }
    }
    void Awake()
    {
//        yHolder = gameObject.GetComponentInChildren<Rigidbody2D>();
        _monsterState = GetComponent<CharacterState>();
        yHolder = GetComponent<Rigidbody2D>();
        deadBool = false;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        DeadPositionHolder(deadBool);
     
        
    }
}
