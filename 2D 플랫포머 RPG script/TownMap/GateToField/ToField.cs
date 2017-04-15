using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToField : MonoBehaviour {


   void OnTriggerEnter2D (Collider2D col)
    {
        if(col.tag == "Player")
        {
            // 나중에는 UI사용해서  어디로 이동할건지 말건지 물어보지만 일단은... 씬로딩만
            SceneManager.LoadScene("Game");
        }

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
