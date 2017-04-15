using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubFxDestroyer : MonoBehaviour {

    public float destroyAfterTime;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, destroyAfterTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
