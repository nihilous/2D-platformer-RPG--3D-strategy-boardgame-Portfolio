using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : MonoBehaviour {
    [HideInInspector]
    public float damage;

    public float minDamage;
    public float maxDamage;

    // 데미지 전달하는부분의 1을 무기데미지 참조해서 전달할것임
    
	// Use this for initialization
	void Start () {
  //      damage = Random.Range(minDamage, maxDamage + 1);	

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
