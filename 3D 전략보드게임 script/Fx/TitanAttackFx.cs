using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanAttackFx : MonoBehaviour {

    public Summon checker;

    // Use this for initialization
    void Start () {
        checker = GameObject.Find("SummonButton").GetComponent<Summon>();
        transform.SetParent(checker.PlayerUnits[(int)FinishButtonClick.thisTurnPlayer].Units[NextButtonClick.unitMoveIndex].GetComponent<UnitStatus>().attackFxPos);

        Vector3 target = GameManage.targetTr.position + new Vector3 (0.0f, 4.0f, 0.0f);

        gameObject.transform.LookAt(target);
	}
	
	// Update is called once per frame
	void Update () {
        if(GameManage.targetTr != null)
        { 
        float yF = Random.Range(3.8f, 4.0f);

        Vector3 target = GameManage.targetTr.position + new Vector3(0.0f, yF, 0.0f);
        gameObject.transform.LookAt(target);
        }
    }
}
