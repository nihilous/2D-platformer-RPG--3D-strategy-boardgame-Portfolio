using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotButton : MonoBehaviour {


    public void OnCamRotateButtonClick()
    {
        switch (gameObject.name)
        {
            case "RotateL":
                CameraMover.nowCamNum -= 5;
                break;
            case "RotateR":
                CameraMover.nowCamNum += 5;
                break;

        }
        
    }


}
