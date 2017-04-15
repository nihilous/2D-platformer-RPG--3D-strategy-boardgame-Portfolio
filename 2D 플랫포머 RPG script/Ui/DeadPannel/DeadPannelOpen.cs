using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPannelOpen : MonoBehaviour {

   public GameObject DeadPannel;

   public void DeathPannelOpen()
    {
        DeadPannel.SetActive(true);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
