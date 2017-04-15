using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerAttackFx : MonoBehaviour {

    Transform daggerTr;
    float zRot = 0.0f;
	// Use this for initialization
	void Start () {
        daggerTr = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
        zRot--;
        zRot = zRot * 2;
        daggerTr.rotation = Quaternion.Euler(0.0f, -90.0f, zRot);
	}
}
