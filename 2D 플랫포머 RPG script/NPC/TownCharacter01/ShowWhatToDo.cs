using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWhatToDo : MonoBehaviour {

    public Image chatBox;
    public Text npcLine;
    public int chatCounter;

   void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player")
        {

            if (npcLine.text == "잠시 시간있어?" +'\n'+'\n'+ "부탁할게있는데")
            { 
            chatBox.enabled = true;
            npcLine.enabled = true;
            string firstLine = npcLine.text;
                
            StartCoroutine(NpcChatBoxClose(firstLine));
            }
        }

    }

    void OnTriggerExit2D (Collider2D col)
    {

    }

    IEnumerator NpcChatBoxClose(string line1)
    {
        yield return new WaitForSeconds(1.5f);
        npcLine.text = "용사님 동쪽숲을" + '\n' + '\n' + "정화해줄래?";
        yield return new WaitForSeconds(1.5f);
        npcLine.text = "부탁할게..." + '\n' + '\n' + "몸조심해!";
        yield return new WaitForSeconds(1.5f);

        npcLine.text = "숲의 보스는, 엄청나게 강하다고해";
        yield return new WaitForSeconds(1.5f);
        npcLine.text = "그렇지만 보물도 얻을수 있다고 하니까";
        yield return new WaitForSeconds(1.5f);
        npcLine.text = "퀘스트창을" + '\n' + '\n' + "확인해봐!";
        yield return new WaitForSeconds(1.5f);

        chatBox.enabled = false;
        npcLine.enabled = false;
        npcLine.text = line1;
        StopCoroutine("NpcChatBoxClose");

    }




    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
