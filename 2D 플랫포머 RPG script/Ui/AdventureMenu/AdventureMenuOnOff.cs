using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class AdventureMenuOnOff : MonoBehaviour {
    public GameObject[] buttons;

    ForeignSound polyPlay;

    void Awake()
    {
        polyPlay = GameObject.Find("ForeignSoundManager").GetComponent<ForeignSound>();
    }


    public void OnAdventureMenuOnOffClick()      // 버튼 갯수만큼 동적생성해서 담아줬음
    {
        polyPlay.playPoly(10);
        for (int i =0; i<buttons.Length; i++)
        {
            if (buttons[i].activeSelf == false)
            {
                buttons[i].SetActive(true);
            }

           else if (buttons[i].activeSelf==true)
            {
                buttons[i].SetActive(false);
            }

        }

    }


 public    GameObject QuestImage;


    public void OnQuestButtonOnOffClick()
    {
        polyPlay.playPoly(10);
        if (QuestImage.activeSelf == false)
        { 
        QuestImage.SetActive(true);
        }
else if (QuestImage.activeSelf == true)
        {
            QuestImage.SetActive(false);
        }
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
