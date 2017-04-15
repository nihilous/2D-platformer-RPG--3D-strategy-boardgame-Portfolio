using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapweaponSphereSpinner : MonoBehaviour {

    Transform sphereTr;
    float yRot = 0.0f;
    // Use this for initialization
    void Start()
    {
        sphereTr = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        yRot--;


        sphereTr.rotation = Quaternion.Euler(0.0f, yRot,0.0f );
    }
}
