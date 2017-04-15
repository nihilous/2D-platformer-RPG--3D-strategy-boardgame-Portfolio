using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DragonSkill : MonoBehaviour {
    public Collider2D skillHitJudge;

    public WeaponInfo givingDamage;

    float damage;

    int secCounter;

    void OnTriggerEnter2D (Collider2D col)
    {

        damage = Random.Range(givingDamage.minDamage, givingDamage.maxDamage + 1f);

        if (col.tag == "Player")

        {
            col.SendMessage("Damage",Mathf.Round(damage));
        }

    }


    IEnumerator ColliderOn ()
    {
        while (secCounter < 3)
        {

            Debug.Log(secCounter);
            secCounter++;
            if(secCounter == 3)
            {
                skillHitJudge.enabled = true;

                StopCoroutine("ColliderOn");
            }


            yield return new WaitForSeconds(1f);
        }


    }

    void Awake()
    {
        secCounter = 0;
    }

    // Use this for initialization
    void Start () {
        StartCoroutine("ColliderOn");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
