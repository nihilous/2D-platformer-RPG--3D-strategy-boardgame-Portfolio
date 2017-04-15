using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSwapButtonLock : MonoBehaviour {

    public Button thsB;
    public Button magicB;

    public Toggle thsT;
    public Toggle magicT;
    THSWeaponSwap swapper;

    

    void Awake()
    {
        swapper = GameObject.Find("Player").GetComponent<THSWeaponSwap>();
    }


   public void SwapButtonLocker()
    {
        if(thsT.isOn ==true)
        {
            Debug.Log("투핸드트루");
            // 잘못짰음  어쨌든 기능은 실행됨
            
            swapper.OnClickWeaponTypeChange1();

            thsB.interactable = true;
            magicB.interactable = false;

        }

        else if (magicT.isOn == true)
        {
            Debug.Log("매직트루");

            swapper.OnClickWeaponTypeChange2();


            magicB.interactable = true;
            thsB.interactable = false;
        }
        
        else if (thsT.isOn == false && magicT.isOn == false)
        {
           Button gameObject = GetComponent<Button>();


            if (gameObject == thsB)
            {

                swapper.OnClickWeaponTypeChange2();

                magicB.interactable = true;
                thsB.interactable = false;
            

            }
            else if (gameObject == magicB)
            {

                swapper.OnClickWeaponTypeChange1();

                thsB.interactable = true;
                magicB.interactable = false;



            }

        }
    }

	// Use this for initialization
	void Start () {

        /*
        if (thsT.isOn == true)
        {
            thsB.interactable = false;
            magicB.interactable = true;
        }
        else if (magicT.isOn == true)
        {
            magicB.interactable = false;
            thsB.interactable = true;
        }
        */
    }

    // Update is called once per frame
    void Update () {
		
	}
}
