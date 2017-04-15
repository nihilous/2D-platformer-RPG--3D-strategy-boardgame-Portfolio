using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentOpener : MonoBehaviour {

    public GameObject equipmentPanel;
    ForeignSound polyPlay;

    
    

    public void OnCharacterButtonClick()
    {
        polyPlay = GameObject.Find("ForeignSoundManager").GetComponent<ForeignSound>();

        polyPlay.playPoly(10);
        if (equipmentPanel.activeSelf==false)
        { 
        equipmentPanel.SetActive(true);
        }
        else if (equipmentPanel.activeSelf == true)
        {
            equipmentPanel.SetActive(false);
        }

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
