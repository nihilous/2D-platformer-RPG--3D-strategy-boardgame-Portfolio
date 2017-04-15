using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SummonList
{
    public List<GameObject> Units = new List<GameObject>();
}


[System.Serializable]   // 유닛사진 스프라이트
public class UnitSpritesArr
{
    public Sprite[] unitSprites = new Sprite[7];

}

[System.Serializable]
public class UnitPrefabC
{
    public GameObject[] unitPrefabs = new GameObject[7];

}

public class Summon : MonoBehaviour {


    public GameObject SummonPannel;

    public Image[] SummonPannelButtonsImage;
    

    public List<SummonList> PlayerUnits = new List<SummonList>();

    SummonList Player1SL = new SummonList();
    SummonList Player2SL = new SummonList();


    public UnitSpritesArr[] unitSpritesArrayClassArray;
    public UnitPrefabC[] unitPrefabCArr;


    public static bool _isSummon = false;

    public int[] manaPoint;
    public GameObject camRotPannel;

    public void FinishSummonPannelSpriteChanger(int factionNum)
    {
        Debug.Log("플레이어1 마나 = " + manaPoint[0] + "  플레이어2 마나 = " + manaPoint[1]);
        int i = 1;
        switch (factionNum)
        {
            case 0:
                foreach (Image _image in SummonPannelButtonsImage)
                {
                    _image.sprite = unitSpritesArrayClassArray[factionNum].unitSprites[i];
                    i++;
                }
                break;
            case 1:
                foreach (Image _image in SummonPannelButtonsImage)
                {
                    _image.sprite = unitSpritesArrayClassArray[factionNum].unitSprites[i];
                    i++;
                }
                break;
        }
    }
    
    // 챔피언유닛은 각팩션 플레이어가 특정 조건 달성하면 소환가능한걸로..
    public void OpenSummonPannel()
    {
        
                if (!SummonPannel.activeSelf)
                {
            camRotPannel.SetActive(false);
            SummonPannel.SetActive(true);    // 기본은 모두 false
            
                }
                else
                {
                    SummonPannel.SetActive(false);
            camRotPannel.SetActive(true);
        }
    }


    void Awake()
    {
        //      Transform tempLoc = GameObject.Find("TileGenPos6").GetComponent<Transform>();

        //      GameObject UnitTemp = Instantiate(unitPrefabCArr[(int)FinishButtonClick.thisTurnPlayer].unitPrefabs[0], tempLoc.position, Quaternion.identity);

        manaPoint = new int[] { 10, 10 };   // 기본값 1,1이었음





        PlayerUnits.Add(Player1SL);
        PlayerUnits.Add(Player2SL);

        // UnitStatus Plyaer1_Master = GameObject.Find("Player1_Master").GetComponent<UnitStatus>();

        Player1SL.Units.Add(GameObject.Find("Player1_Master"));
        Player2SL.Units.Add(GameObject.Find("Player2_Master"));

        Debug.Log("플레이어1 마나 = " + manaPoint[0] + "  플레이어2 마나 = " + manaPoint[1]);



    }

    // Use this for initialization
    void Start () {
    

    }

    // Update is called once per frame
    void Update () {
		
	}
}
