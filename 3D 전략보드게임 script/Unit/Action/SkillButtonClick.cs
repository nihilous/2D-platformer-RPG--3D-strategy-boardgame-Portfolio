using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SkillSpriteArray
{
    public Sprite[] Sprites;
}

public class SkillButtonClick : MonoBehaviour {

    UnitStatus thisUnit;
    public string playerWho; // 다음유닛 버튼 누를때 이부분이 자동으로 변함
    public int unitNumber;
    public delegate void UnitSkillUsing(string unitName, int tileNum);  
    public static event UnitSkillUsing SkillUse;
    public Image skillImage;
    public SkillSpriteArray[] skillSprites;

    public void OnSkillButtonClick()
    {


        thisUnit = GameObject.Find("플레이어번호" + "유닛번호리스트").GetComponent<UnitStatus>();
        skillImage.sprite = skillSprites[(int)thisUnit.unitFaction].Sprites[(int)thisUnit.unitType];
        // 스킬패널 켜주고 그안에 이미지 버튼은 다차원배열로 팩션번호, 유닛번호로하면될듯
        
        
        /*
        switch (thisUnit.unitFaction)
        {



            case UnitStatus.Faction.Academy:
                switch (thisUnit.unitType)
                {
                    // 이부분을  델리게이트 연산해서 스킬쓰게할것
                    case UnitStatus.UnitType.Master:    
                        break;
                    case UnitStatus.UnitType.BasicMelee:
                        break;
                    case UnitStatus.UnitType.BasicRange:
                        break;
                    case UnitStatus.UnitType.BasicMagic:
                        break;
                    case UnitStatus.UnitType.EliteMelee:
                        break;
                    case UnitStatus.UnitType.EliteRange:
                        break;
                    case UnitStatus.UnitType.EliteMagic:
                        break;
                    case UnitStatus.UnitType.Champion:
                        break;
                }
                break;
            case UnitStatus.Faction.Stronghold:
                switch (thisUnit.unitType)
                {
                    case UnitStatus.UnitType.Master:
                        break;
                    case UnitStatus.UnitType.BasicMelee:
                        break;
                    case UnitStatus.UnitType.BasicRange:
                        break;
                    case UnitStatus.UnitType.BasicMagic:
                        break;
                    case UnitStatus.UnitType.EliteMelee:
                        break;
                    case UnitStatus.UnitType.EliteRange:
                        break;
                    case UnitStatus.UnitType.EliteMagic:
                        break;
                    case UnitStatus.UnitType.Champion:
                        break;
                }
                break;
        }
        */


    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
