using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCounterSkill : MonoBehaviour {

    public GameObject groundFissureSkillPrefab;

    public Transform bossPosition;
    Vector2 whereToGen;

    public float yPosition;
    ForeignSound polyPlay;
    // 이부분을 데미지받을때마다 올라갈수있게
    // 간단한 인트 ++ 메소드하나를 데미지 애니메이션에넣고  그인트가 5가될때   인스턴시에이트가 실행되게 아래메소드에 조건걸수있음
    public void CounterSkillOn()
    {
        Debug.Log("스킬발동");
        Debug.Log(gameObject.transform.position);
        whereToGen =      bossPosition.position;

        whereToGen = new Vector2(whereToGen.x, whereToGen.y - yPosition);

        Instantiate(groundFissureSkillPrefab, whereToGen, Quaternion.identity);
        polyPlay.playPoly(5);

    }
    void Awake()
    {
        polyPlay = GameObject.Find("ForeignSoundManager").GetComponent<ForeignSound>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
