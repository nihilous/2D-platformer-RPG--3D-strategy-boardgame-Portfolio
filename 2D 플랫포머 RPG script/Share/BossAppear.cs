using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAppear : MonoBehaviour {

   public static int enemyDeathCount = 0;


    public Transform bossGenPos;
    public GameObject[] bossPrefab;
    public Image bossAppearImage;
    public Text bossAppearText;
    public Animator bossAppearAleartAnim;
    public Toggle kill5EnemyQuest;
    public Toggle bossKillChecker;
    ChatBoxController chatCon;
    public void BossGen()
    {
        if (enemyDeathCount ==5)
        {
            kill5EnemyQuest.isOn = true;
            Debug.Log("보스등장");
            Vector3 GenPosition;
            Transform bossPosition = GameObject.Find("BossGenPoint").GetComponent<Transform>();
            bossPosition.position = new Vector3(bossPosition.position.x, -1f);
            GenPosition = bossPosition.position;


 GameObject golemBossMonster = Instantiate(bossPrefab[0], GenPosition, Quaternion.identity);
            golemBossMonster.name = bossPrefab[0].name;
            bossAppearImage.enabled = true;
            bossAppearText.enabled = true;
            bossAppearAleartAnim.Play("Text");
            StartCoroutine(BossAleartStop());
            StartCoroutine(chatCon.ChatBoxOpener("평야에서 기척이 느껴진다"));
        }
    }

    public void BossKilled()
        {

        //    bossKillChecker = GameObject.Find("Quest2Toggle").GetComponentInChildren<Toggle>();


        bossKillChecker.isOn = true;
        bossAppearImage.enabled = true;
        bossAppearText.enabled = true;
        bossAppearText.text = "Death From Above";
        bossAppearAleartAnim.Play("Text");
        StartCoroutine(BossAleartStop());


        Transform bossPosition = GameObject.Find("DragonGenPoint").GetComponent<Transform>();

        StartCoroutine(DragonGen(bossPosition));

        

    }

    IEnumerator DragonGen(Transform where)
    {
        yield return new WaitForSeconds(3f);
       GameObject dragonBossMonster = Instantiate(bossPrefab[1], where.position, Quaternion.identity);
        dragonBossMonster.name = bossPrefab[1].name;
        StartCoroutine(chatCon.ChatBoxOpener("위에서 무언가 느껴져"));
        StopCoroutine("DragonGen");

    }

    IEnumerator BossAleartStop()
    {
        yield return new WaitForSeconds(3f);
        bossAppearImage.enabled = false;
        bossAppearText.enabled = false;
        StopCoroutine("BossAleartStop");

    }

    void Awake()
    {
        chatCon = GameObject.Find("Player").GetComponent<ChatBoxController>();
    }
	// Use this for initialization
	void Start () {
    //    BossGen();
	}
	
	// Update is called once per frame
	void Update () {

            }
}
