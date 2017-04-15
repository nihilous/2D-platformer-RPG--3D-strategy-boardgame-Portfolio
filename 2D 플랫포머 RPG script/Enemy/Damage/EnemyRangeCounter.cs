using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeCounter : MonoBehaviour {

    public WeaponInfo damageUp;
    public EnemyMovement speedUp;
public Animator animationSpeedUp;


   protected virtual void  OnTriggerEnter2D (Collider2D col)
    {
        if(col.tag == "PlayerBullet")
        {
            damageUp.minDamage += 1;

            damageUp.maxDamage += 1;

            speedUp._moveSpeed += 2.5f;

            animationSpeedUp.speed *= 1.2f;

            
            Debug.Log(animationSpeedUp.speed);


        }
    }


    void Awake()
    {

        damageUp = gameObject.GetComponentInChildren<WeaponInfo>();

        speedUp = gameObject.GetComponentInChildren<EnemyMovement>();

        animationSpeedUp = gameObject.GetComponentInChildren<Animator>();

    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
