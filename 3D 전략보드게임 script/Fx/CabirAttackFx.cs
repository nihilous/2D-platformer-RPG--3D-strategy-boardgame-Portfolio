using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabirAttackFx : MonoBehaviour {

    public Rigidbody fxRigid;

    public float Force;

    public GameObject subFxOnCollide;

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject == GameManage.targetTr.gameObject)
        {
            // 이부분에 폭발 이펙트

            Instantiate(subFxOnCollide, gameObject.transform.position, gameObject.transform.rotation);

            Destroy(gameObject,0.1f);
        }
    }

	// Use this for initialization
	void Start () {
        fxRigid = GetComponent<Rigidbody>();
        Vector3 temp = GameManage.targetTr.position + new Vector3(0.0f, 4.0f, 0.0f);
        Vector3 dir = temp - gameObject.transform.position;   //GameManage.targetTr.position - gameObject.transform.position;   // 

        //  gameObject.transform.LookAt(GameManage.targetTr.position + new Vector3(0.0f, 1.0f, 0.0f));

        fxRigid.AddForce(dir.normalized * Force);

        Destroy(gameObject, 2.5f);    
	}
	
	// Update is called once per frame
	void Update () {
		


	}
}
