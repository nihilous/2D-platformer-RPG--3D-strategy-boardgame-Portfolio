using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTile : MonoBehaviour {

    public GameObject[] bases;
    public TestScriptTileObj symbolOnOff;


    public void ActivateBase(int factionNum)
    {

        symbolOnOff = gameObject.GetComponent<TestScriptTileObj>();

        switch (factionNum)
        {
            case 0:
                bases[0].SetActive(true);
                symbolOnOff.playerSymbols[1].SetActive(false);
                symbolOnOff.playerSymbols[0].SetActive(true);
                break;
            case 1:
                bases[1].SetActive(true);
                symbolOnOff.playerSymbols[0].SetActive(false);
                symbolOnOff.playerSymbols[1].SetActive(true);
                break;
        }


    }



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
