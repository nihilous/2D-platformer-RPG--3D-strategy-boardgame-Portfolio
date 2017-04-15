using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemUIOpenClose : MonoBehaviour {

   public GameObject systemUI;
    public GameObject soundUI;

    ForeignSound polyPlay;

    void Awake()
    {
        polyPlay = GameObject.Find("ForeignSoundManager").GetComponent<ForeignSound>();
    }


    public void OnSystemButtonClick()
    {
        polyPlay.playPoly(10);
        if (systemUI.activeSelf == false)
        {
            systemUI.SetActive(true);
        }

        else if (systemUI.activeSelf == true)
        {
            systemUI.SetActive(false);
        }
    }

    public void OnSoundButtonClick()
    {
        polyPlay.playPoly(10);
        if (soundUI.activeSelf == false)
        {
            soundUI.SetActive(true);
        }

        else if (soundUI.activeSelf == true)
        {
            soundUI.SetActive(false);
        }
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
