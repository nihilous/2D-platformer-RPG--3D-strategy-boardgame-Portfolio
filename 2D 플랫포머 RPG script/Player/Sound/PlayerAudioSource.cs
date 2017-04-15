using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioSource : MonoBehaviour {
    public AudioSource[] playerPolySounds;

    public void playPoly(int i)
    {

        playerPolySounds[i].Play();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
