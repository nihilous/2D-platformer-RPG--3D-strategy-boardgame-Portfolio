using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour {

   //  public int speed;
    protected CharacterState _characterState;

    public Transform _damageTextFlipper;
    public Transform _nameTextFlipper;

    public void Flip()  // 플립이 2번도는것같음
    {
        

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
    
        transform.localScale = theScale;
        
      _characterState._isRightDir = !_characterState._isRightDir;

        TextUIFlipper();

    }

    public void TextUIFlipper()     // UI부분이 텍스트가 캐릭터가 회전할때 같이 좌우반전되서..
    {
       Vector3 flipperScale = _nameTextFlipper.localScale;
        flipperScale.x *= -1;
        _damageTextFlipper.localScale = flipperScale;
        _nameTextFlipper.localScale = flipperScale;
    }

    protected virtual void Awake()
    {
        _characterState = GetComponent<CharacterState>();
  //      _damageTextFlipper = GetComponent<RectTransform>();
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
