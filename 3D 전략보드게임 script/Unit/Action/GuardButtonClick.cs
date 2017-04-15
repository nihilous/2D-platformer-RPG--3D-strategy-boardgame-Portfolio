using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardButtonClick : MonoBehaviour {

    public Summon checker;


    public void OnGuardButtonClick()
    {
        checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().isDefence = true;
        Animator[] defendController = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponentsInChildren<Animator>();


        for (int j = 0; j < defendController.Length; j++)
        {

            defendController[j].Play("Defend", 0);
            Debug.Log("가드애니메이션");
        }
    }


    // Use this for initialization
    void Start () {
        checker = GameObject.Find("SummonButton").GetComponent<Summon>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
