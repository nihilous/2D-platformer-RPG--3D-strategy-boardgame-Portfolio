using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusaderHealSkill : ActiveSkill
{

    public void HealUse()
    {
        if (hpUp._isDie != true)
        { 
        Debug.Log("힐유즈");
        StartCoroutine(HpUpDotHeal());
        Debug.Log("힐유즈");
       _animation.Play("SkillUsing");
        }
    }

    public IEnumerator HpUpDotHeal()
    {
        
        float dotHealRate = hpUp._MaxHp/100;
        while (skillContinue <5 && hpUp._isDie == false)
        {
          if (hpUp._hp > hpUp._MaxHp)
            {

                //                hpUp._hp = hpUp._MaxHp;
                hpGageUP.HpUp(1);   // 그냥 1을 넣어주면 알아서 메소드에서 맞춰줌
            //     yield break; 멈출필요는 없는듯 걍 만피만 유지해주면됨 만피에서 떨어지면 이하가실행
            }
            hpUp._hp = hpUp._hp + (dotHealRate * 10);
            hpGageUP.HpUp(0.1f);    // 체력을 10퍼씩 올리므로
            Debug.Log("최대 hp" + hpUp._MaxHp);

            Debug.Log("힐량" + dotHealRate * 10);
            Debug.Log("현재 hp"+ hpUp._hp);

            Debug.Log(hpUp._isDie + "죽었다");
            skillContinue++;
            if (skillContinue == 5)
            {
                
                StopCoroutine("HpUpDotHeal");
                
            }
            Debug.Log("hpupdotHeal 힐스킬" + skillContinue);
            yield return new WaitForSeconds(1f);
        }
        

    }

	// Use this for initialization
	void Start () {

        HealUse();
        Debug.Log("힐스타트");

    }
	protected void Awake()
    {
        base.Awake();
    }





	// Update is called once per frame
	void Update () {
        
    }
}
