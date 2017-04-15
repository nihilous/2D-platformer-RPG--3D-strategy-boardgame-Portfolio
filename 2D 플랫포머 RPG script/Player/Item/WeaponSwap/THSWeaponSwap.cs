using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Anima2D;



public class THSWeaponSwap : MonoBehaviour {
    public SpriteMesh[] thSwords;


    // 원거리공격 할때는.. 어떤아이템쓰는지봐서  weapon info 에 접근해서 데미지올려주면될듯
    
    public SpriteMeshInstance twoHandSword;

    public SkinnedMeshRenderer thsOnOff;


    public SpriteMeshInstance[] magic;

    public SkinnedMeshRenderer[] magicOnOff;

    public SpriteMesh[] magics;

    public WeaponInfo damageChanger;
    public WeaponInfo magicDamageChanger;
    public Toggle thsToggle;
    public Toggle magicToggle;

    public Button thsButton;
    public Button magicButton;

    public Sprite[] ItemBagImageSwap;

    public Image[] CharacterPannelImageSwapper;



    // 스킬사진 6개랑

    // 이미지 6개로 스왑함
    public Image[] skillImages;
    public Sprite[] skillIcons;



    Animator boolChecker;

    ChatBoxController chatCon;

    void Awake()
    {
        chatCon = gameObject.GetComponent<ChatBoxController>();
        boolChecker = GetComponent<Animator>();

    }

    // 이부분을 equipment창에서 클릭시에 호출하고
    // 토글에 연결해줌
    public void OnClickWeaponTypeChange1()
    {
        
            // 버튼2개 참조해서 토글이 켜져있으면,, 상호작용 못하게 해야함
            if (boolChecker.GetBool("TwoHandSwordActiveSelf") == true ||(boolChecker.GetBool("TwoHandSwordActiveSelf") == false && boolChecker.GetBool("MagicActive") == false))
            {
            StartCoroutine(chatCon.ChatBoxOpener("배우신분..ㅎㅎ"));
            thsOnOff.enabled = false;

                thsToggle.isOn = false;
                magicToggle.isOn = true;


            int j = 3;
            int k = 0;
            for (int i = 0; i < skillImages.Length; i++)
            {

                skillImages[i].sprite = skillIcons[j];
                skillImages[i].color = new Color(1f, 1f, 1f, 1f);
                skillImages[k].color = new Color(1f, 1f, 1f, 0.3f);
             

                k++;
                j++;
                if (j == 6)
                {
                    j = 3;
                    k = 0;
                }
            }
            for (int i = 0; i < magicOnOff.Length; i++)
                {
                    magicOnOff[i].enabled = true;

                }
            
            }
            

    }



    public void OnClickWeaponTypeChange2()
    {
       

       if (boolChecker.GetBool("MagicActive") == true || (boolChecker.GetBool("TwoHandSwordActiveSelf") == false && boolChecker.GetBool("MagicActive") == false))
        {
            StartCoroutine(chatCon.ChatBoxOpener("너.. 문과지?"));

            for (int i = 0; i < magicOnOff.Length; i++)
            {
                magicOnOff[i].enabled = false;
            }
            int j = 0;
            int k = 3;
            for (int i = 0; i < skillImages.Length; i++)
            {

                skillImages[i].sprite = skillIcons[j];
                skillImages[j].color = new Color(1f, 1f, 1f, 0.3f);
                skillImages[k].color = new Color(1f, 1f, 1f, 1f);

                j++;
                k++;
                if (j == 3)
                {
                    j = 0;
                    k = 3;
                }
            }
            magicToggle.isOn = false;

            thsToggle.isOn = true;

            thsOnOff.enabled = true;




        }



    }



    // 이부분은 가방에서 무기를 클릭시에

    public Sprite SwordWeaponChange()
    {

     //   if (boolChecker.GetBool("TwoHandSwordActiveSelf") == true)
      //  {
 //           if (Input.GetKeyDown(KeyCode.C))
         //   {
                if (twoHandSword.spriteMesh == thSwords[0])
                {
                    twoHandSword.spriteMesh = thSwords[1];
                    damageChanger.minDamage = 10;

                    damageChanger.maxDamage = 20;
            CharacterPannelImageSwapper[0].sprite = ItemBagImageSwap[1];

            return ItemBagImageSwap[0];
                    
                }
                else if (twoHandSword.spriteMesh == thSwords[1])
                {
                    twoHandSword.spriteMesh = thSwords[0];

                    damageChanger.minDamage = 3;
                    damageChanger.maxDamage = 5;
            CharacterPannelImageSwapper[0].sprite = ItemBagImageSwap[0];
            return ItemBagImageSwap[1];
                }
    //        }
            return null;
    //    }

//        return null;

    }

    public Sprite MagicWeaponChange()
    {
        

   //     if (boolChecker.GetBool("MagicActive") == true)
   //     {
            //            if (Input.GetKeyDown(KeyCode.C))
         //   {
                if (magic[0].spriteMesh == magics[0])
                {
            magicDamageChanger.minDamage = 7;

            magicDamageChanger.maxDamage = 13;
            magic[0].spriteMesh = magics[2];

                    magic[1].spriteMesh = magics[3];
            CharacterPannelImageSwapper[1].sprite = ItemBagImageSwap[3];
            CharacterPannelImageSwapper[2].sprite = ItemBagImageSwap[5];

            return ItemBagImageSwap[2];

                }
                else if (magic[0].spriteMesh == magics[2])
                {
            magicDamageChanger.minDamage = 1;

            magicDamageChanger.maxDamage = 4;
            magic[0].spriteMesh = magics[0];

                    magic[1].spriteMesh = magics[1];
            CharacterPannelImageSwapper[1].sprite = ItemBagImageSwap[2];
            CharacterPannelImageSwapper[2].sprite = ItemBagImageSwap[4];
            return ItemBagImageSwap[3];

                }
            // }
            return null;
        
     //   return null;
    }



    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < skillImages.Length; i++)
        {

            skillImages[i].sprite = null;
            skillImages[i].color = new Color(1f, 1f, 1f, 0f);
        }



        /*
        Debug.Log(boolChecker.GetBool("TwoHandSwordActiveSelf"));
        Debug.Log(boolChecker.GetBool("MagicActive"));
        if (boolChecker.GetBool("TwoHandSwordActiveSelf") == true)
        {
        */

        //     thsToggle.isOn = true;

        /*
        magicToggle.isOn = false;
        }

        else if (boolChecker.GetBool("MagicActive") == true)
        {
            magicToggle.isOn = true;
            thsToggle.isOn = false;
        }
        */

    }
    // Update is called once per frame
    void Update () {
   //     OnClickWeaponTypeChange();
       //     WeaponChange();
        }
    
}

