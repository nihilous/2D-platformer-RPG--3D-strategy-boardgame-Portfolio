using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkill : MonoBehaviour {
    
   

    protected CharacterState hpUp;
    protected HpGageShare hpGageUP;
    public Animator _animation;
    protected int skillContinue = 0;
    public int skillCoolDown;
    [HideInInspector]
    public float nowCoolDown;

    protected void Awake()
    {
        
        hpUp = GameObject.Find("Player").GetComponent<CharacterState>();
        hpGageUP = GameObject.Find("Player").GetComponent<HpGageShare>();

        nowCoolDown = skillCoolDown;// 생성되기전이라 전달이안됨


}
	
	// Update is called once per frame
	void Update () {
		
	}
}
