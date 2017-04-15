using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortionFxGen : MonoBehaviour {

    public GameObject[] portionFx;
    Transform buffPosition;

   public void PortionFxGener(int fxNum)
    {

       GameObject fx = Instantiate(portionFx[fxNum], buffPosition.position, Quaternion.identity);
        fx.transform.parent = GameObject.Find("PlayerBuffPosition").GetComponent<Transform>();
    }

	// Use this for initialization
	void Start () {
        buffPosition = GameObject.Find("PlayerBuffPosition").GetComponent<Transform>();
        buffPosition.position += new Vector3(0f, 2f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
