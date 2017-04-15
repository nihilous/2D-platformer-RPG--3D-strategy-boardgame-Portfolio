using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentsCloser : MonoBehaviour {
    public GameObject equipmentPannel;
    ForeignSound polyPlay;

   
       
    
    public void OnXbuttonClick()
    {
        polyPlay = GameObject.Find("ForeignSoundManager").GetComponent<ForeignSound>();
        polyPlay.playPoly(10);
        equipmentPannel.SetActive(false);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
