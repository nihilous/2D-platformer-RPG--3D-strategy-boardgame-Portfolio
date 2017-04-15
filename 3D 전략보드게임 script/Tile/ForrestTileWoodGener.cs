using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForrestTileWoodGener : MonoBehaviour {

    public Transform[] woodPos;
    public GameObject[] woodPrefabs;



    public void woodGenerate()
    {
        for (int i = 0; i < woodPos.Length; i++)
        {
            int tempNum = Random.Range(0, woodPrefabs.Length);

           GameObject wood = Instantiate(woodPrefabs[tempNum], woodPos[i].position, woodPos[i].rotation);
            wood.transform.SetParent(woodPos[i]);
        }
        
    }

	// Use this for initialization
	void Start () {
        woodGenerate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
