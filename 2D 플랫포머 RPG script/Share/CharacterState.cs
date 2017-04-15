using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour {
    
    public LayerMask _targetMask; // 충돌레이어
    public float _hp;   // 체력 상태
    public bool _isDie = false; // 사망여부
    public bool _isRightDir = false; // 시선

    [HideInInspector]
    public float _MaxHp;

    void Awake()
    {
        _MaxHp = _hp;
    }

    // 상태

    public enum State
    {
        Idle, Move, Attack, Damage, Die
        // 대기, 이동, 공격, 데미지, 사망
    };

    
    public State _state;



    // 캐릭터 상태 프로퍼티
    public State state
    {
        get { return this._state; }
        set { this._state = value; }
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
