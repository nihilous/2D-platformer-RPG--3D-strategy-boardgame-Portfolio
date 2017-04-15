using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpGageShare : MonoBehaviour {
    CharacterState hPState;
    PlayerStat expStat;
   public PlayerSkill mpStat;

    float hP;

    [HideInInspector]
    public float maxhP;

    [HideInInspector]
    public float expNow;
    [HideInInspector]
    public float expGageMax;

    public Image _hpProgress; // 체력바
    public Text _hpText; // 체력바위에 숫자
    float hpGageRate;
    float mpGageRate;
    float expGageRate;

    public Image _mpProgress; // 마나바
    public Text _mpText; // 마나바위에 숫자

    public Image _expProgress; // 경험치바
    public Text _expText; // 경험치바위에 숫자

    


    void Awake ()
    {
        hPState = GetComponent<CharacterState>();
    //    mpStat = GetComponent<PlayerSkill>();
        expStat = GetComponent<PlayerStat>(); 

        //      hP = hPState._hp;           // 레벨업 한다는 가정하에.. 이부분을 레벨업하면서 호출하거나 업데이트에서 새로 교체해줄 필요가있을듯함 maxhp라는 스텟을 따로만들어서 public hideinspector로
        //     maxhP = hPState._MaxHp;
        _hpText.text = hPState._hp.ToString() + " / " + hPState._MaxHp.ToString();
        _mpText.text = mpStat.nowMp.ToString() + " / " + mpStat.maxMp.ToString();
        _expText.text = expStat.exp.ToString() + " / " + expStat.maxExp.ToString();
    }

    public  void HpDown(float damage)
    {
        hpGageRate = 1f / hPState._MaxHp;
        // 체력이 얼마나 올라가던 백분율을 만들어줌
        _hpProgress.fillAmount -= (damage* hpGageRate);           // 체력 25일때 0.04f

        _hpText.text = (hPState._hp- damage).ToString() + " / " + hPState._MaxHp.ToString();
        //     return base.HpDown(damage);
        if (hPState._hp < damage)        // 힐마법 쓰다 죽는상황등에..수치 깔끔히
        {
            hPState._hp = 0;
            _hpText.text = hPState._hp.ToString() + " / " + hPState._MaxHp.ToString();
        }
    }



    public  void HpUp(float value)  // value를 백분율 퍼센트로 받는게 나을듯
    {
        //      base.HpUp(value);

        hpGageRate = 1f / hPState._MaxHp;

        _hpProgress.fillAmount += (value);    //* hpGageRate);      // value * 0.01f 가 원래내용
        
        _hpText.text = hPState._hp.ToString() + " / " + hPState._MaxHp.ToString();

        if (hPState._hp + value > hPState._MaxHp)
        {
            hPState._hp = hPState._MaxHp;
            _hpText.text = hPState._hp.ToString() + " / " + hPState._MaxHp.ToString();

        }

    }
    public void MpUp(float value)
    {
        //      base.HpUp(value);

        mpGageRate = 1f / mpStat.maxMp;

        
        _mpProgress.fillAmount += mpGageRate * value;      // 0.2f;//(value * mpGageRate);      // mpGageRate; //(value * GageRate);      // value * 0.01f 가 원래내용


        _mpText.text = mpStat.nowMp.ToString() + " / " + mpStat.maxMp.ToString();

        if (mpStat.nowMp + value > mpStat.maxMp)
        {
            mpStat.nowMp = mpStat.maxMp;
            _mpText.text = mpStat.nowMp.ToString() + " / " + mpStat.maxMp.ToString();

        }

    }

    public void MpDown(int consumedMp)
    {
        mpGageRate = 1f / mpStat.maxMp;
        // 체력이 얼마나 올라가던 백분율을 만들어줌
        _mpProgress.fillAmount -= (consumedMp * mpGageRate);           // 체력 25일때 0.04f

        _mpText.text = (mpStat.nowMp - consumedMp).ToString() + " / " + mpStat.maxMp.ToString();
        //     return base.HpDown(damage);
        if (mpStat.nowMp < consumedMp)        // 힐마법 쓰다 죽는상황등에..수치 깔끔히
        {
            mpStat.nowMp = 0;
            _mpText.text = mpStat.nowMp.ToString() + " / " + mpStat.maxMp.ToString();
        }
    }



    

    public void ExpUp(float expValue)
    {
        expGageRate = 1f / expStat.maxExp;

        _expProgress.fillAmount += (expValue * expGageRate);      // value * 0.01f 가 원래내용

        _expText.text = expStat.exp.ToString() + " / " + expStat.maxExp.ToString();

    }

    public void LvUpExpZero()
    {   _expProgress.fillAmount = 0;


    }


    // Use this for initialization
    void Start () {
    //    _hpText.text = hP.ToString() + " / " + maxhP.ToString();
    }
	
	// Update is called once per frame
	void Update () {
 //      maxhP = hPState._MaxHp;
       
  //     hP = hPState._hp;           // 레벨업 한다는 가정하에.. 이부분을 레벨업하면서 호출하거나 업데이트에서 새로 교체해줄 필요가있을듯함 maxhp라는 스텟을 따로만들어서 public hideinspector로

    }
}
