using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : MonoBehaviour {

    public float monsterExp;


    
    // [HideInInspector]
 public   PlayerStat expUp;

    void Awake()
    {

     expUp = GameObject.Find("Player").GetComponent<PlayerStat>(); 
     

    }

    public void GiveExp()
    {
        expUp.ExpUp(monsterExp);

    }
    


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
