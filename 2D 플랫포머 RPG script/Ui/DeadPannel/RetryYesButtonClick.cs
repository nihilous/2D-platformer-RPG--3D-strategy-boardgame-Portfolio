using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryYesButtonClick : MonoBehaviour {

    ForeignSound polyPlay;

  // public GameObject DeadPannel;
    public void OnRetryYesButtonClick()
    {
        polyPlay.playPoly(10);
        ItemBagList.itemBagStuffList.RemoveRange(0, ItemBagList.itemBagStuffList.Count);
        BossAppear.enemyDeathCount = 0;
        SceneManager.LoadScene("Game");
    }

    public void OnRetryNoButtonClick()
    {
        polyPlay.playPoly(10);
        Application.Quit();
    }

    void Awake()
    {
        polyPlay = GameObject.Find("ForeignSoundManager").GetComponent<ForeignSound>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
