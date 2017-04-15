using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestShipScript : MonoBehaviour {

    public Transform shipPos;
    public Transform[] destPos;
    public NavMeshAgent shipMover;


    public void ShippedCharacterMoving()
    {
        gameObject.transform.position = shipPos.position;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        gameObject.transform.SetParent(shipPos);
        gameObject.transform.rotation = shipPos.transform.rotation;
        int r = Random.Range(0, destPos.Length);
        shipMover.destination = destPos[r].position;
       // gameObject.transform.SetParent(null);
    }

	// Use this for initialization
	void Start () {
        InvokeRepeating("ShippedCharacterMoving",5.0f,5.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
