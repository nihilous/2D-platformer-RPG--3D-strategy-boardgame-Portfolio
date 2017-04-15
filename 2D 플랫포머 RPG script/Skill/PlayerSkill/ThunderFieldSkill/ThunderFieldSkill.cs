using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderFieldSkill : ActiveSkill {

    float MagicDamage;
    public WeaponInfo dealingDamage;
    public BoxCollider2D colliderOff;


    void OnTriggerEnter2D(Collider2D col)
    {
        MagicDamage = Random.Range(dealingDamage.minDamage, dealingDamage.maxDamage + 1);
        if (col.tag == "Enemy" || col.tag == "BossEnemy")
        {
            col.SendMessage("Damage", Mathf.Round(MagicDamage));
        }
    }

    IEnumerator ColliderOff()
    {
        yield return new WaitForSeconds(0.2f);

        colliderOff.enabled = false;

        StopCoroutine("ColliderOff");

        yield return null;
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(ColliderOff());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
