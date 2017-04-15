using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonCounter : MonoBehaviour {
    public GameObject dragonCounterSkillPrefab;

    public Transform playerPosition;
    Vector2 whereToGen;

    public float yPosition;
    CharacterState playerDieChecker;

    // 이부분을 데미지받을때마다 올라갈수있게
    // 간단한 인트 ++ 메소드하나를 데미지 애니메이션에넣고  그인트가 5가될때   인스턴시에이트가 실행되게 아래메소드에 조건걸수있음
    public void DragonCounterSkillOn()
    {
       
        if (playerDieChecker._isDie != true)
        { 
        Instantiate(dragonCounterSkillPrefab, playerPosition.position, Quaternion.identity);
        }
    }

    // Use this for initialization
    void Start()
    {
        playerPosition = GameObject.Find("Player").GetComponent<Transform>();
playerDieChecker = GameObject.Find("Player").GetComponent<CharacterState>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
