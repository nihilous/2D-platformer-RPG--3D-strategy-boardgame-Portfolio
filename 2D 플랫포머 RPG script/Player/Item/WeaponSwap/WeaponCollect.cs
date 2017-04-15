using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollect : MonoBehaviour {

    [HideInInspector]
    public bool UTHSwordGet;
    [HideInInspector]
    public bool MagicGet;


    void Awake()
    {
        UTHSwordGet = false;

        MagicGet = false;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
