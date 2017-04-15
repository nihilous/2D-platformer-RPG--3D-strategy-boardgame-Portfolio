using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFissureSkill : MonoBehaviour {

    public WeaponInfo damage;
    float giveDamage;
    int skillLoopTimes;
    int triggerCounter;
    bool isPlayerIn;
    CharacterState playerDieChecker;

  //  Collider2D playerCol;
    
         void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            
                           triggerCounter++;
                    if (triggerCounter == 2)
                    {
                isPlayerIn = true;
                        triggerCounter = 0;
                        
            StartCoroutine(GroundFissureDamage(col));
        }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log(col);
        if(col.tag == "Player")
        {
            isPlayerIn = false;
        }
    }


    IEnumerator GroundFissureDamage(Collider2D playerCol)
    {
        while (skillLoopTimes < 3)
        {

            
        giveDamage =      Random.Range(damage.minDamage,damage.maxDamage + 1);
        

        Debug.Log(skillLoopTimes + "몇번째");
            
            if(playerDieChecker._isDie != true && isPlayerIn == true)
            { 
            playerCol.SendMessage("Damage",Mathf.Round(giveDamage));
            }
            skillLoopTimes++;
            if (skillLoopTimes == 3)
            {
                StopCoroutine("GroundFissureDamage");
            }
            yield return new WaitForSeconds(1f);
        }
    }

    // Use this for initialization

        void Awake()
    {
        skillLoopTimes = 0;
        triggerCounter = 0;
     playerDieChecker =  GameObject.Find("Player").GetComponent<CharacterState>();
    }
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
