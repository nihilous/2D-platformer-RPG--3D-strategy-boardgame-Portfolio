using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {

    Transform cameraTr;
    Transform destinationRot;


    public static int nowCamNum = 0;
    public float rotSpeed;
    public Summon checker;
    private float camZoom;
    public Camera mainCamFOV;
    public void CameraRotChanger()
    {
                
        cameraTr.rotation = Quaternion.Lerp(cameraTr.rotation, Quaternion.Euler(0, nowCamNum * -7.5f, 0), Time.deltaTime * rotSpeed);

    }

    // Use this for initialization
    void Start () {
        //   checker = GameObject.Find("SummonButton").GetComponent<Summon>();

        cameraTr = GetComponent<Transform>();


    }
	
	// Update is called once per frame
	void Update () {
    CameraRotChanger();
        camZoom = Input.GetAxis("Mouse ScrollWheel");
        mainCamFOV.fieldOfView = mainCamFOV.fieldOfView + camZoom;  // 인풋에서 sensitivity 0.1 을 1로 바꿨음
       
    }
}
