using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour {

    public static List<int> diceValues = new List<int>();
    public int diceQuantity;    // 유닛 스테이터스에서 다이스 갯수가져오면됨
    public Text DiceQttText;
//    public Text Dice1ValueText;
//    public Text Dice2ValueText;
//    public Text Dice3ValueText;
    public Text TotalValue;
    public Image[] buttonImages;
    public Button[] buttons;
    public Text[] texts;
    public GameObject actionUI;
    public Summon checker;
    public Camera diceCam;
    public GameObject[] dices;
    public Transform[] diceGenPos;
    public static List<GameObject> rolledDiceList = new List<GameObject>();
    // 다이스 퀀티티는... 넥스트유닛버튼 누를때마다 , 턴종료시마다 스태틱 인트값 변화주면서
    // 소환된 유닛이 저장되어있는(정확히는 unitstatus)를 뽑아와서 다이스갯수 데이터를사용
    // 지금같은경우 diceQuantity 를  넥스트유닛 버튼클릭부분에서 매번 유닛 다이스갯수 뽑아와서 바꿔줌  diceQuantity 는 static으로 써도될듯함

    public void RollDice(int howManyDices)
    {
        checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().isDefence = false;
        checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().hadRollDice = true;
        switch (howManyDices)
        {

            case 1:
                if (diceValues.Count != 0)
                {
                    diceValues.Clear();
                }
                DiceQttText.text = "주사위 갯수 = " + diceQuantity;
                int diceOne = Random.Range(1, 7);

                diceValues.Add(diceOne);

                diceCam.enabled = true;
               GameObject rolledDice1 = Instantiate(dices[diceOne - 1], diceGenPos[0].position, dices[diceOne - 1].transform.rotation);
                rolledDiceList.Add(rolledDice1);
            //    Dice1ValueText.text = "값1 " + diceValues[0].ToString();
                TotalValue.text = "총합 " + diceValues[0].ToString();
                //    diceValues.Remove(diceValues[0]);
              
                break;
            case 2:
                if (diceValues.Count != 0)
                {
                    diceValues.Clear();
                }
                DiceQttText.text = "주사위 갯수 = " + diceQuantity;
                int diceTwo = Random.Range(1, 7);
                int diceTwo2 = Random.Range(1, 7);
                diceValues.Add(diceTwo);
       //         Dice1ValueText.text = "값1 " + diceValues[0].ToString();
                diceValues.Add(diceTwo2);

                diceCam.enabled = true;
                GameObject rolledDice2_1 = Instantiate(dices[diceTwo - 1], diceGenPos[1].position, dices[diceTwo - 1].transform.rotation);
                rolledDiceList.Add(rolledDice2_1);
                GameObject rolledDice2_2 = Instantiate(dices[diceTwo2 - 1], diceGenPos[2].position, dices[diceTwo2 - 1].transform.rotation);
                rolledDiceList.Add(rolledDice2_2);

     //           Dice2ValueText.text = "값2 " + diceValues[1].ToString();
                TotalValue.text = "총합 " + (diceValues[0] + diceValues[1]).ToString();
                //    diceValues.Remove(diceValues[0]);
                //      diceValues.Remove(diceValues[1]);
            
                break;
            case 3:
                if (diceValues.Count != 0)
                {
                    diceValues.Clear();
                }
                DiceQttText.text = "주사위 갯수 = " + diceQuantity;
                int diceThree = Random.Range(1, 7);
                int diceThree2 = Random.Range(1, 7);
                int diceThree3 = Random.Range(1, 7);
                diceValues.Add(diceThree);
           //     Dice1ValueText.text = "값1 " + diceValues[0].ToString();
                diceValues.Add(diceThree2);
            //    Dice2ValueText.text = "값2 " + diceValues[1].ToString();
                diceValues.Add(diceThree3);
         //       Dice3ValueText.text = "값3 " + diceValues[2].ToString();

                diceCam.enabled = true;
                GameObject rolledDice3_1 = Instantiate(dices[diceThree - 1], diceGenPos[0].position, dices[diceThree - 1].transform.rotation);
                rolledDiceList.Add(rolledDice3_1);
                GameObject rolledDice3_2 = Instantiate(dices[diceThree2 - 1], diceGenPos[1].position, dices[diceThree2 - 1].transform.rotation);
                rolledDiceList.Add(rolledDice3_2);
                GameObject rolledDice3_3 = Instantiate(dices[diceThree3 - 1], diceGenPos[2].position, dices[diceThree3 - 1].transform.rotation);
                rolledDiceList.Add(rolledDice3_3);


                TotalValue.text = "총합 " + (diceValues[0] + diceValues[1] + diceValues[2]).ToString();
                //      diceValues.Remove(diceValues[0]);
                //     diceValues.Remove(diceValues[1]);
                //     diceValues.Remove(diceValues[2]);
        
                break;
            case 4:
                if (diceValues.Count != 0)
                {
                    diceValues.Clear();
                }
                DiceQttText.text = "주사위 갯수 = " + diceQuantity;
                int diceFour = Random.Range(1, 7);
                int diceFour2 = Random.Range(1, 7);
                int diceFour3 = Random.Range(1, 7);
                int diceFour4 = Random.Range(1, 7);

                diceValues.Add(diceFour);
                //     Dice1ValueText.text = "값1 " + diceValues[0].ToString();
                diceValues.Add(diceFour2);
                //    Dice2ValueText.text = "값2 " + diceValues[1].ToString();
                diceValues.Add(diceFour3);
                //       Dice3ValueText.text = "값3 " + diceValues[2].ToString();
                diceValues.Add(diceFour4);
                diceCam.enabled = true;
                GameObject rolledDice4_1 = Instantiate(dices[diceFour - 1], diceGenPos[0].position, dices[diceFour - 1].transform.rotation);
                rolledDiceList.Add(rolledDice4_1);
                GameObject rolledDice4_2 = Instantiate(dices[diceFour2 - 1], diceGenPos[1].position, dices[diceFour2 - 1].transform.rotation);
                rolledDiceList.Add(rolledDice4_2);
                GameObject rolledDice4_3 = Instantiate(dices[diceFour3 - 1], diceGenPos[2].position, dices[diceFour3 - 1].transform.rotation);
                rolledDiceList.Add(rolledDice4_3);
                GameObject rolledDice4_4 = Instantiate(dices[diceFour4 - 1], diceGenPos[3].position, dices[diceFour4 - 1].transform.rotation);
                rolledDiceList.Add(rolledDice4_4);

                TotalValue.text = "총합 " + (diceValues[0] + diceValues[1] + diceValues[2] + diceValues[3]).ToString();
                //      diceValues.Remove(diceValues[0]);
                //     diceValues.Remove(diceValues[1]);
                //     diceValues.Remove(diceValues[2]);

                break;

        }
    }

    public void RollDiceButtonClick()
    {
        if (!checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().hadRollDice)
        { 
        RollDice(diceQuantity);
            for (int i = 0; i < 2; i++)
            {

                buttonImages[i].enabled = true;
                buttons[i].enabled = true;
                texts[i].enabled = true;
            }
            actionUI.SetActive(false);
        }
    }

    /*
    public void NextUnitAndTurnEnd()   // 다음유닛이랑 턴종료때 메소드콜있었는데 그부분도 주석처리해둠
    {
        Dice1ValueText.text = "값1 ";
        Dice2ValueText.text = "값2 ";
        Dice3ValueText.text = "값3 ";
    }
    */

    // Use this for initialization
    void Start () {
        checker = GameObject.Find("SummonButton").GetComponent<Summon>();
        diceQuantity = checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().dices;
        diceCam.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
