using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInfoUiControl : MonoBehaviour
{

    public GameObject infoPannel;

    public Summon check;  // 스프라이트는 unisprite array class array에 있음

    RaycastHit hit;

    public Text[] uiTexts;

    public Image[] uiImages;

    void Start()
    {


        check = GameObject.Find("SummonButton").GetComponent<Summon>();
    }

    public void OnCloseButtonClick()
    {
        infoPannel.SetActive(false);

    }

    public void ShowClickedUnitInfo (RaycastHit clickedHit)
    {


        UnitStatus clickedUS = hit.collider.gameObject.GetComponent<UnitStatus>();

        uiImages[0].sprite = check.unitSpritesArrayClassArray[(int)clickedUS.unitFaction].unitSprites[(int)clickedUS.unitType];




        for (int i = 0; i < uiTexts.Length; i++)
        {
            switch (i)
            {
                case 0:
                    uiTexts[i].text = clickedUS.unitName;   // 이름
                    break;
                case 1:
                    uiTexts[i].text = clickedUS.lifePointProp + "/" + clickedUS.maxLifePoint;   // HP
                    break;
                case 2:
                    uiTexts[i].text = clickedUS.dices.ToString(); // 다이스갯수
                    break;
                case 3:
                    uiTexts[i].text = clickedUS.atkPoint.ToString();    //공격력
                    break;
                case 4:
                    uiTexts[i].text = clickedUS.defPoint.ToString(); // 방어력
                    break;
                case 5:
                    if (clickedUS.isRange) // 레인지 유닛일때
                    {
                        uiImages[2].enabled = false;
                        uiImages[1].enabled = true;

                        // 레인지아이콘
                    }
                    else
                    {
                        uiImages[1].enabled = false;
                        uiImages[2].enabled = true;
                        // 밀리아이콘
                    }
                    uiTexts[i].text = clickedUS.AttackRange.ToString();

                    break;
                case 6:
                    if (clickedUS.maxManaPoint == 0)
                    {
                        uiTexts[i].text = "N/A";
                    }
                    else
                    {
                        uiTexts[i].text = clickedUS.manaPointProp + "/" + clickedUS.maxManaPoint;   // 마나
                    }
                    break;
                case 7:
                    if (clickedUS.nowSkillCool >= 1)
                    {
                        uiTexts[i].text = clickedUS.nowSkillCool + "턴";    // 스킬쿨타임 남은거
                    }
                    else
                    {
                        uiTexts[i].text = "대기중";
                    }
                    break;
            }
        }


        
        float lifeGagePercent = (float)clickedUS.lifePointProp / (float)clickedUS.maxLifePoint;

        uiImages[3].fillAmount = lifeGagePercent;




    }




    // Update is called once per frame
    void Update()
    {



        // 이부분을 공격 당하는 입장에서만 호출한다면?
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out hit);
            
            if (hit.collider.tag == "UNIT")
            {
                infoPannel.SetActive(true);

                ShowClickedUnitInfo(hit);
            }

        }

        if (infoPannel.activeSelf == true)
        {
            ShowClickedUnitInfo(hit);
        }



    }
}
