using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeShieldSkill : ActiveSkill
{
   
    void OnTriggerEnter2D(Collider2D col)
    {
       
        if(col.tag == "Enemy" || col.tag == "BossEnemy" )
        {
           StartCoroutine (BladeShieldDamage(col));
        }
    }

    IEnumerator BladeShieldDamage(Collider2D monsterCol)
    {
        while(skillContinue <5)
        {
            CharacterState isDieChecker = monsterCol.GetComponent<CharacterState>();
            if (isDieChecker._isDie == true)
                yield break;
            hpUp = GameObject.Find("Player").GetComponent<CharacterState>();
            if (hpUp._isDie == true)
            {
                Destroy(gameObject);
                Debug.Log("아직돌아감?1");
                StopCoroutine("BladeShieldDamage");     // 디스트로이걸어도 타이밍적으로 이하가실행될수있고
                yield return null;                      // 코루틴 스탑해도 리턴 만날때까지 한번은 도는듯
                Debug.Log("아직돌아감?2");
                yield return null;

            }
            WeaponInfo weaponDam = GameObject.Find("LHTwoHandSword").GetComponent<WeaponInfo>();
            float damage = Random.Range(weaponDam.minDamage,weaponDam.maxDamage+1);
            monsterCol.SendMessage("Damage", Mathf.Round(damage));
        skillContinue++;    // 이부분과 데미지는 스킬 레벨에따라 달라진다면??.. 나중에는 DB에서 가져올수있을듯
        yield return new WaitForSeconds(1f);
        }
    }

    /*
    IEnumerator CoolDownRecharge()
    {

    }
    */
    protected void Awake()
    {
        base.Awake();
    }

        // Use this for initialization
        void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
