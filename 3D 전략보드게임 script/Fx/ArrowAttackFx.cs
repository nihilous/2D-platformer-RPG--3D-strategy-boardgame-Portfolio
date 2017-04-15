using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAttackFx : MonoBehaviour {

    Transform arrowTr;
    float zRot = 0.0f;
    // Use this for initialization
    void Start()
    {
        arrowTr = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        zRot++;
        zRot = zRot * 2;
        arrowTr.rotation = Quaternion.Euler(0.0f, 0.0f, zRot);
    }
}
