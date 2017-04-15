using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubdueButtonClick : MonoBehaviour {
    Summon checker;

    public TestScriptTileObj symbolOnOff;
    FinishButtonClick resourceStatUpdater;


    public void OnSubdueButtonClick()
    {
        if (!checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().hadAction)
        {

           int tempNum =  checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().nowTile;

            TileType tempTile = GameObject.Find("Tile" + tempNum).GetComponent<TileType>();

            
            tempTile.OnActionCommand();
            symbolOnOff = GameObject.Find("Tile" + tempNum).GetComponent<TestScriptTileObj>();
            switch ((int)FinishButtonClick.thisTurnPlayer)
            {
                case 0:
                    symbolOnOff.playerSymbols[1].SetActive(false);
                    symbolOnOff.playerSymbols[0].SetActive(true);
                    tempTile.thisTileOwner = TileType.TileOwnerPvP.Player1;
                    
                    break;
                case 1:

                    symbolOnOff.playerSymbols[0].SetActive(false);
                    symbolOnOff.playerSymbols[1].SetActive(true);
                    tempTile.thisTileOwner = TileType.TileOwnerPvP.Player2;
                    break;
            }
            resourceStatUpdater.ResourceStat();
            checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().hadAction = true;
            
        }

    }
    // Use this for initialization
    void Start () {
        checker = GameObject.Find("SummonButton").GetComponent<Summon>();
        resourceStatUpdater = GameObject.Find("TurnFinishButton").GetComponent<FinishButtonClick>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
