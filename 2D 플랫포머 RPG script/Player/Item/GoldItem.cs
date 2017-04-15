using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldItem : MonoBehaviour {

    // CharacterState ifHp0;
    public GameObject goldPrefab;
    public int minGold;
    public int maxGold;
    [HideInInspector]
    public int dropGold;


    public void DropGold()
    {
        Instantiate(goldPrefab, transform.position, Quaternion.identity);
    }

    


	// Use this for initialization
	void Start () {
        dropGold = Random.Range(minGold, maxGold);
        	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
