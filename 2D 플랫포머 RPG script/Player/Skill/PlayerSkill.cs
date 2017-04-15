using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSkill : MonoBehaviour {


    public GameObject [] SkillPrefab;

    public TwoHandSword thsChecker;
    public Magic magicChecker;
    public HpGageShare mpGageControl;
    public Animator _animator;
    public CharacterState _cState;
    ActiveSkill[] coolCounter = new ActiveSkill[6];
    public Image[] skillCoolDown;
    public Text[] skillCoolSecText;
    [HideInInspector]
    public bool MpPortionEffect;

    public WeaponInfo magidDamageUp;

    ChatBoxController chatBoxCall;
  public static int mpPortionCounter = 0;

    PlayerAudioSource polyPlay;



    [HideInInspector]
    public int nowMp;
    public int maxMp;


    public void plusMp()
    {
        if (nowMp < maxMp)
        nowMp++;
        mpGageControl.MpUp(1);
    }
    

        
    public IEnumerator MpPortionDOT()
    {
        if (mpPortionCounter != 0)
        {
            mpPortionCounter = 0;
            yield break;
        }

        
  
        while (mpPortionCounter < 10)
        {
            Debug.Log(mpPortionCounter);    
            plusMp();
            mpPortionCounter++;
  
           yield return new WaitForSeconds(1.5f);
            if (mpPortionCounter == 10)
            {

                mpPortionCounter = 0;
                StopCoroutine("MpPortionDOT");
                yield break;
            }
        }
    }

    public void SkillCoolZero(int i)
    {
         // 체력이 얼마나 올라가던 백분율을 만들어줌
        skillCoolDown[i].fillAmount = 0;           // 체력 25일때 0.04f
        coolCounter[i].nowCoolDown = 0;
        skillCoolSecText[i].enabled = true;
        skillCoolSecText[i].text = coolCounter[i].skillCoolDown.ToString() +"s";
    }



    public void SkillCoolRecharge(int prefabNum)  // value를 백분율 퍼센트로 받는게 나을듯
    {
     int coolTime =   coolCounter[prefabNum].skillCoolDown;
        StartCoroutine(CoolRunning(coolTime, prefabNum));
    }

    IEnumerator CoolRunning (int coolDownDuring, int ImageNum)
    {
float coolDownRate = 1f / coolDownDuring;

        coolCounter[ImageNum].nowCoolDown = 0f;

       while (coolCounter[ImageNum].nowCoolDown <  coolDownDuring)
        {
            coolCounter[ImageNum].nowCoolDown++;


            skillCoolDown[ImageNum].fillAmount += coolDownRate;
            skillCoolSecText[ImageNum].text = (coolCounter[ImageNum].skillCoolDown -coolCounter[ImageNum].nowCoolDown).ToString() + "s";
            if (coolCounter[ImageNum].nowCoolDown == coolCounter[ImageNum].skillCoolDown)
            {
                skillCoolSecText[ImageNum].enabled = false;
                StopCoroutine("CoolRunning");
            }
            /*     if (coolRunning == coolDownDuring)
                 {
                     StopCoroutine("CoolRunning");
                 }*/
            yield return new WaitForSeconds(1f);

        }

    }


    // 이하 스킬유즈 3개 줄여보기

    protected void SkillUse()       // 블레이드 쉴드 테스트
    {
         
        


        if (nowMp >= 2 && thsChecker.LHTwoHandSword.enabled == true && Input.GetKeyDown(KeyCode.Q) && coolCounter[0].nowCoolDown == coolCounter[0].skillCoolDown)
        {
            mpGageControl.MpDown(2);
            nowMp = nowMp - 2;


            _animator.Play("TwoHandSkillUse");

            Vector3 PrefabPosition;
            Transform buffPosition = GameObject.Find("PlayerBuffPosition").GetComponent<Transform>();
            PrefabPosition = buffPosition.position;
            buffPosition.position = new Vector3(buffPosition.position.x, 0f);
            //    buffPosition.position += new Vector3(0f, 0f);

            ////new Vector3(buffPosition.position.y, );
            //     PrefabPosition.y = -5;     // 피벗이 낮아서 플레이어는 부모없으니까 로컬이든 포지션이든 기준에서 -5 빼주고 차일드로 들어갈땐 인스펙터값 치환됨
            StartCoroutine(chatBoxCall.ChatBoxOpener("블레이드쉴드!"));


            GameObject skill = Instantiate(SkillPrefab[0], PrefabPosition, Quaternion.identity);
            PlayerAudioSource polyPlay = GameObject.Find("Player").GetComponent<PlayerAudioSource>();
            polyPlay.playPoly(6);
            skill.transform.parent = GameObject.Find("Player").GetComponent<Transform>();
            skill.transform.localPosition = new Vector3(0f, -1f);
            SkillCoolZero(0);
            SkillCoolRecharge(0);
            //스킬쓸때 x포지션 프리즈걸고 애니메이션 끝날때 프리즈 풀까 생각중
        }
        else if (nowMp < 2 && thsChecker.LHTwoHandSword.enabled == true && Input.GetKeyDown(KeyCode.Q) && coolCounter[0].nowCoolDown == coolCounter[0].skillCoolDown)
            {
            StartCoroutine(chatBoxCall.ChatBoxOpener("마나가 부족해"));
            }
        if (nowMp >= 3 && magicChecker.MagicEquipments.enabled == true && Input.GetKeyDown(KeyCode.Q) && coolCounter[3].nowCoolDown == coolCounter[3].skillCoolDown)
        {
            mpGageControl.MpDown(3);
            nowMp = nowMp - 3;

            _animator.Play("MagicSkillUse");   // skill use하니까 이상함
          
            Transform skillPosition = GameObject.Find("Player").GetComponent<Transform>();

            StartCoroutine(chatBoxCall.ChatBoxOpener("썬더필드!"));
            StartCoroutine(ThunderFieldGen(skillPosition));
            polyPlay.playPoly(2);
            //       Instantiate(SkillPrefab[3], PrefabPosition, Quaternion.identity);

            //            skill.SendMessage("MagicFlipper", _cState._isRightDir);
            SkillCoolZero(3);
            SkillCoolRecharge(3);
        }
        else if (nowMp < 3 && magicChecker.MagicEquipments.enabled == true && Input.GetKeyDown(KeyCode.Q) && coolCounter[3].nowCoolDown == coolCounter[3].skillCoolDown)
        {
            StartCoroutine(chatBoxCall.ChatBoxOpener("마나가 부족해"));
        }
    }

    IEnumerator ThunderFieldGen(Transform skillPosition)
    { int i = 0;
        while(i < 5)
        {
            Vector3 PrefabPosition;
            float xRandom = Random.Range(skillPosition.position.x - 7f, skillPosition.position.x + 7f);
            //    skillPosition.position =
            float yPos = skillPosition.position.y;
            PrefabPosition = new Vector3(xRandom, yPos);

        GameObject bullet =    Instantiate(SkillPrefab[3], PrefabPosition, Quaternion.identity);

            WeaponInfo magicDamage = bullet.GetComponent<WeaponInfo>();


            magicDamage.minDamage += magidDamageUp.minDamage/2;
            magicDamage.maxDamage += magidDamageUp.maxDamage/2;



            i++;
            if(i == 5)
            {
                Debug.Log("stop");
                StopCoroutine("ThunderFieldGen");
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    protected void SkillUse2()
    {
        if (nowMp >= 3 && thsChecker.LHTwoHandSword.enabled == true && Input.GetKeyDown(KeyCode.W) && coolCounter[1].nowCoolDown == coolCounter[1].skillCoolDown)
        {
            mpGageControl.MpDown(3);
            nowMp = nowMp - 3;

            _animator.Play("TwoHandAttack1");   // skill use하니까 이상함
            Vector3 PrefabPosition;
            Transform bulletPosition = GameObject.Find("PlayerBulletPosition").GetComponent<Transform>();

            PrefabPosition = bulletPosition.position;


            WeaponInfo weaponDam = GameObject.Find("LHTwoHandSword").GetComponent<WeaponInfo>();
            WeaponInfo skillDam = SkillPrefab[1].GetComponent<WeaponInfo>();
            float originalMin = Mathf.Round(skillDam.minDamage);
            float originalMax = Mathf.Round(skillDam.maxDamage);

            skillDam.minDamage = Mathf.Round(skillDam.minDamage) + Mathf.Round(weaponDam.minDamage/2);
            skillDam.maxDamage = Mathf.Round(skillDam.maxDamage) + Mathf.Round(weaponDam.maxDamage/2);

            

            StartCoroutine(chatBoxCall.ChatBoxOpener("바람의상처!\n는표절이죠!"));
            GameObject bullet = Instantiate(SkillPrefab[1], PrefabPosition, Quaternion.identity) as GameObject;

            bullet.SendMessage("Init", _cState._isRightDir);
            SkillCoolZero(1);
            SkillCoolRecharge(1);
            skillDam.minDamage = originalMin;
            skillDam.maxDamage = originalMax;

        }
        else if (nowMp < 3 && thsChecker.LHTwoHandSword.enabled == true && Input.GetKeyDown(KeyCode.W) && coolCounter[1].nowCoolDown == coolCounter[1].skillCoolDown)
        {
            StartCoroutine(chatBoxCall.ChatBoxOpener("마나가 부족해"));
        }

        // 쿨타임등은 조정해야함.. 배열도 
        if (nowMp >= 4 && magicChecker.MagicEquipments.enabled == true && Input.GetKeyDown(KeyCode.W) && coolCounter[4].nowCoolDown == coolCounter[4].skillCoolDown)
        {
            mpGageControl.MpDown(4);
            nowMp = nowMp - 4;

            _animator.Play("MagicSkillUse");   // skill use하니까 이상함
            Vector3 PrefabPosition;
            Transform bulletPosition = GameObject.Find("MagicStaffFxPosition").GetComponent<Transform>();

            PrefabPosition = bulletPosition.position;
            Debug.Log(PrefabPosition + "플레이어위치?");
            StartCoroutine(chatBoxCall.ChatBoxOpener("스노우브레스!"));
            polyPlay.playPoly(3);
            GameObject bullet = Instantiate(SkillPrefab[4], PrefabPosition, Quaternion.identity) as GameObject;



            WeaponInfo magicDamage = bullet.GetComponent<WeaponInfo>();

            
            magicDamage.minDamage += magidDamageUp.minDamage/2;
            magicDamage.maxDamage += magidDamageUp.maxDamage/2;

            // 스왑시에 마법봉 데미지 변경이 없어서 추가해야함
            // WeaponInfo weaponDam = GameObject.Find("LHTwoHandSword").GetComponent<WeaponInfo>();

            //  magicDamage.minDamage += 
            //    magicDamage.maxDamage +=

            bullet.SendMessage("MagicFlipper", _cState._isRightDir);
            SkillCoolZero(4);
            SkillCoolRecharge(4);
        }
        else if (nowMp < 4 && magicChecker.MagicEquipments.enabled == true && Input.GetKeyDown(KeyCode.W) && coolCounter[4].nowCoolDown == coolCounter[4].skillCoolDown)
        {
            StartCoroutine(chatBoxCall.ChatBoxOpener("마나가 부족해"));
        }


    }

    protected void SkillUse3()       // 힐
    {
        if (nowMp >= 2 && thsChecker.LHTwoHandSword.enabled == true && Input.GetKeyDown(KeyCode.E) && coolCounter[2].nowCoolDown == coolCounter[2].skillCoolDown)
        {
            mpGageControl.MpDown(2);
            nowMp = nowMp - 2;

            _animator.Play("TwoHandSkillUse");
            Vector3 PrefabPosition;
            Transform buffPosition = GameObject.Find("PlayerBuffPosition").GetComponent<Transform>();
            PrefabPosition = buffPosition.position;
            buffPosition.position = new Vector3(buffPosition.position.x, 0f);
            //  buffPosition.position += new Vector3(0f, 0f);     // 피벗이 낮아서 플레이어는 부모오브젝트가 없으니까 로컬이든 포지션이든 기준에서 -5 빼주고 차일드로 들어갈땐 인스펙터값 치환됨
            StartCoroutine(chatBoxCall.ChatBoxOpener("불굴의기사도!"));
            GameObject skill = Instantiate(SkillPrefab[2], PrefabPosition, Quaternion.identity);
            skill.transform.parent = GameObject.Find("Player").GetComponent<Transform>();
            skill.transform.localPosition = new Vector3(0f, 5f);
            //  skillUse.HealUse();

            //스킬쓸때 x포지션 프리즈걸고 애니메이션 끝날때 프리즈 풀까 생각중
            SkillCoolZero(2);
            SkillCoolRecharge(2);
        }
        else if (nowMp < 2 && thsChecker.LHTwoHandSword.enabled == true && Input.GetKeyDown(KeyCode.E) && coolCounter[2].nowCoolDown == coolCounter[2].skillCoolDown)
        {
            StartCoroutine(chatBoxCall.ChatBoxOpener("마나가 부족해"));
        }

        if (nowMp >= 2 && magicChecker.MagicEquipments.enabled == true && Input.GetKeyDown(KeyCode.E) && coolCounter[5].nowCoolDown == coolCounter[5].skillCoolDown)
        {
            mpGageControl.MpDown(2);
            nowMp = nowMp - 2;

            _animator.Play("MagicSkillUse");   // skill use하니까 이상함



            Vector2 boxSize = new Vector2(17f,6f);
            Vector2 overLapPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 2f);


            Collider2D[] colliders = Physics2D.OverlapBoxAll(overLapPosition, boxSize,0f, _cState._targetMask);
            if(colliders.Length == 0)
            {
                StartCoroutine(chatBoxCall.ChatBoxOpener("적이없는데 마나를허비했다."));
            }
            else if (colliders != null)
            {
                StartCoroutine(chatBoxCall.ChatBoxOpener("매직미사일 " + colliders.Length +"연발"));
            }
            Debug.Log(colliders.Length + "검출갯수");

            foreach (Collider2D col in colliders)
            {
                Debug.Log(col.gameObject.name);
            }

            Transform bulletPosition = GameObject.Find("MagicStaffFxPosition").GetComponent<Transform>();


            StartCoroutine(MagicMissileCounter(colliders, bulletPosition));
              
           
            SkillCoolZero(5);
            SkillCoolRecharge(5);
        }
        else if (nowMp < 2 && magicChecker.MagicEquipments.enabled == true && Input.GetKeyDown(KeyCode.E) && coolCounter[5].nowCoolDown == coolCounter[5].skillCoolDown)
        {
            StartCoroutine(chatBoxCall.ChatBoxOpener("마나가 부족해"));
        }
    }

    IEnumerator MagicMissileCounter (Collider2D [] colArray,Transform pP)
    {
        int i = 0;
        Transform enemyPos;
        Vector2 targetVector;

        foreach (Collider2D col in colArray)
        {

            if (col.tag == "Enemy" || col.tag == "BossEnemy")
            {
               

                enemyPos = col.transform;
               
                Vector3 enemy = (enemyPos.position + new Vector3(0f,1.2f)); // 적 머리쪽을향해 발사하게함
                    

                targetVector = (enemy - pP.position).normalized;


                //                    Vector3 PrefabPosition;
                
                //                  PrefabPosition = bulletPosition.position;

                GameObject mm = Instantiate(SkillPrefab[5], pP.position, pP.rotation);
                
                WeaponInfo magicDamage = mm.GetComponent<WeaponInfo>();


                magicDamage.minDamage += magidDamageUp.minDamage;
                magicDamage.maxDamage += magidDamageUp.maxDamage;

                polyPlay.playPoly(4);
                DragonBreathBullet mmBullet = mm.GetComponentInChildren<DragonBreathBullet>();
                mmBullet.Init(_cState._isRightDir, targetVector);
                i++;

                if(i == colArray.Length-1 || i == 5)
                {
                    StopCoroutine("MagicMissileCounter");
                }
                yield return new WaitForSeconds(0.2f);

            }

        }

        }

    


    void Awake()
    {
        MpPortionEffect = false;
        chatBoxCall = gameObject.GetComponent<ChatBoxController>();
        polyPlay = gameObject.GetComponent<PlayerAudioSource>();
    }

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 6; i++)
        {
            //       coolCounter[i] = SkillPrefab[i].GetComponentInChildren<ActiveSkill>();
            coolCounter[i] = SkillPrefab[i].GetComponent<ActiveSkill>();

            coolCounter[i].nowCoolDown = coolCounter[i].skillCoolDown;

        }
    }
	
	// Update is called once per frame
	void Update () {
        if (_cState._isDie!=true)
        { 
        SkillUse();
        SkillUse2();
        SkillUse3();
        }
    }
}
