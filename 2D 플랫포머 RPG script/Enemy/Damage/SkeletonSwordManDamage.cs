using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSwordManDamage : EnemyDamage {

    protected override void RangeCounterAttack()
    {
              _animator.SetTrigger("RangeCounterTrigger");
        StartCoroutine(ColliderOnOffCoroutin());
    }

    IEnumerator ColliderOnOffCoroutin()
    {
        onOffCollider.enabled = false;
        yield return new WaitForSeconds(0.8f);
        StopCoroutine("ColliderOnOffCoroutin");
        onOffCollider.enabled = true;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
