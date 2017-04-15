using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBreathSkill : ActiveSkill
{

    public BoxCollider2D offSetController;
    public WeaponInfo dealingDamage;
    int initSec;
    float MagicDamage;

    public void MagicFlipper(bool isRightDir)       // 왼쪽을 보고있을시 화살의 방향을 자동으로 변경해줌
    {
        if (isRightDir != true)
        {
            transform.localScale = new Vector3(-1f, 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        MagicDamage = Random.Range(dealingDamage.minDamage, dealingDamage.maxDamage + 1);
        if (col.tag == "Enemy" || col.tag == "BossEnemy")
        {
            col.SendMessage("Damage",Mathf.Round(MagicDamage));
        }
    }


    IEnumerator XOffSetMover()
    {
        initSec = 0;
            
            while (initSec < 10)
        {

            
            

            initSec++;
            if (initSec >= 2)
            { 
            offSetController.offset += new Vector2(2.4f, 0f);



            if (initSec == 10)
            {
                StopCoroutine("XOffSetMover");
            }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }




	// Use this for initialization
	void Start () {
        StartCoroutine(XOffSetMover());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
