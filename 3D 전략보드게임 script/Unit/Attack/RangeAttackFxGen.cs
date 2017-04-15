using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackFxGen : MonoBehaviour {
    public Summon checker;
    public AttackButtonClick attacker;
    public GameManage gm;
    public void RangeAttack()
    {
        gm.RangeAttackFxGen();
        
    }

    // Use this for initialization
    void Start () {
        checker = GameObject.Find("SummonButton").GetComponent<Summon>();
        attacker = GameObject.Find("AttackButton").GetComponent<AttackButtonClick>();
        gm = GameObject.Find("GameManager").GetComponent<GameManage>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
