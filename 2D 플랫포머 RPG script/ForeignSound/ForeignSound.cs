using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeignSound : MonoBehaviour {

    public AudioSource[] polies;

   public void playPoly (int i)
    {
        polies[i].Play();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
