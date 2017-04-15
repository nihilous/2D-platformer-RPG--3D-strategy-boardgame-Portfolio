using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneLoader : MonoBehaviour {

   public IEnumerator EndSceneLoaderCoroutine()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("End");



    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
