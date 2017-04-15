using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGround : MonoBehaviour {

    BoxCollider2D _boxCollider;

    Rigidbody2D _playerRigidbody;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        // 플레이어가 블록보다 위에있고 현재 하강중이라면


        if (_playerRigidbody.transform.position.y > transform.position.y && _playerRigidbody.velocity.y <= 0)
        {
            _boxCollider.isTrigger = false;
        }
        else // 플레이어가 블록 아래있고 현재 상승중이라면 블록으로 점프중인상태
        {
            _boxCollider.isTrigger = true;
        }


    }




    // Use this for initialization
    void Start()
    {

        _playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {

    }
}
