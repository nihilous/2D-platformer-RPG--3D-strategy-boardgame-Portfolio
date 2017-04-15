using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour {

    public int level;
    [HideInInspector]
    public float maxExp;
    [HideInInspector]
    public float exp;



    protected CharacterState hpIncresase;
    protected PlayerSkill mpIncrease;
    // maxExp = maxExp *level *1.1
    HpGageShare maxHpIncrease;
    public Text levelText;
    ChatBoxController chatBoxCall;
    void Awake()
    {
//
        hpIncresase = GetComponent<CharacterState>();
        mpIncrease = GetComponent<PlayerSkill>();
        maxHpIncrease = GetComponent<HpGageShare>();
        exp = 0;
        maxExp = 15;
        levelText.text = level.ToString();
        chatBoxCall = gameObject.GetComponent<ChatBoxController>();
    }
     

    // 이부분 몬스터 죽는 애니메이션에서 이벤트로 실행
    
    public void ExpUp(float monsterExp)
    {
        exp += monsterExp;

        maxHpIncrease.ExpUp(monsterExp);    // 경험치 게이지 올리기


        if (exp >= maxExp)
        {
            
            LevelUp();
            levelText.text = level.ToString();
            //  (exp - maxExp) *
            //  maxHpIncrease.ExpDown()
            maxHpIncrease.LvUpExpZero();
            maxHpIncrease.ExpUp(exp);
        }



    }



    public void LevelUp()
    {
        StartCoroutine(chatBoxCall.ChatBoxOpener("강해진 기분이 드는데?"));

        ++level;
        exp = (exp - maxExp);
        maxExp = (maxExp * level ); // 이부분은 나중에.. 레벨별로 나눠서 경험치 부과
        
        hpIncresase._MaxHp += 10;

        float increasedHp = hpIncresase._MaxHp - hpIncresase._hp;

        hpIncresase._hp = hpIncresase._MaxHp;
        maxHpIncrease.HpUp(increasedHp);

        mpIncrease.maxMp += 1;
        float increasedMp = mpIncrease.maxMp - mpIncrease.nowMp;
        Debug.Log(mpIncrease.maxMp + "최대엠피" + mpIncrease.nowMp + "지금엠피");
        mpIncrease.nowMp = mpIncrease.maxMp;    // 레벨업보상
        maxHpIncrease.MpUp(increasedMp);    // 레벨업보상으로 마나채워줌
        

  //      maxHpIncrease.maxhP += 10;


        Debug.Log(level+ "되었음");
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
