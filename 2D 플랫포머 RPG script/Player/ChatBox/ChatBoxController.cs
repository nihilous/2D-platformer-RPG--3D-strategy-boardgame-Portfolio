using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatBoxController : MonoBehaviour {

    public Image chatBoxImage;
    public Text chatBoxText;

    public IEnumerator ChatBoxOpener (string chatLine)
    {


        chatBoxImage.enabled = true;
        chatBoxText.enabled = true;
        chatBoxText.text = chatLine;
       
        yield return new WaitForSeconds(1.2f);
        chatBoxText.text = null;
        chatBoxImage.enabled = false;
        chatBoxText.enabled = false;
        StopCoroutine("ChatBoxOpener");
        yield break;
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
