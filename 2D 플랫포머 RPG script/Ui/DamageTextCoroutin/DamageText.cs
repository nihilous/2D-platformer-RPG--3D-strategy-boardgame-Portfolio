using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DamageText : MonoBehaviour {

    public IEnumerator AttackDamageShow(Image dImage, Text dText, float damageFrom)
    {
        dImage.enabled = true;
        dText.enabled = true;

        dText.text = damageFrom.ToString();

        yield return new WaitForSeconds(0.3f);
        dImage.enabled = false;
        dText.enabled = false;


        StopCoroutine("AttackDamageShow");
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
