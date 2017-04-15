using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDamage : MonoBehaviour {
    UnitStatus thisUnitStat;


    public void Damage(int enemyAtkPoint)
    {
        thisUnitStat.lifePointProp -= Mathf.Abs(thisUnitStat.defPoint - enemyAtkPoint);
        if(thisUnitStat.lifePointProp <= 0)
        {
            thisUnitStat.UnitDead();
        }
    }


	// Use this for initialization
	void Start () {
        thisUnitStat = GetComponent<UnitStatus>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
