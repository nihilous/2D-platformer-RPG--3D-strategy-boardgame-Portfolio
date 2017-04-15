using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButtonClick : MonoBehaviour {

   public Summon checker;
   public static int unitMoveIndex = 0;
    public DiceRoll diceControl;

    public void OnNextButtonClick()
    {

        if(checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units.Count != 1)
        { 
        ++unitMoveIndex;
        }
        
        if (unitMoveIndex == checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units.Count)
        {
            unitMoveIndex = 0;
        }
        Debug.Log(checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].name);


        Move.nowPosition = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().nowTile;
        CameraMover.nowCamNum = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().nowTile;
        diceControl.diceQuantity = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().dices;
        //     checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[unitMoveIndex];
   //     diceControl.NextUnitAndTurnEnd();




        // Debug.Log();

    }


    // Use this for initialization
    void Start () {
        checker = GameObject.Find("SummonButton").GetComponent<Summon>();
        diceControl = GameObject.Find("RollDiceButton").GetComponent<DiceRoll>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
