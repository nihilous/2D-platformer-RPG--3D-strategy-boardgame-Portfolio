using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    public Transform[] genPositions;

    public GameObject[] enemyPrefabs;


    // 어떤적을 어디에 얼마후에 생성할것인가, 적캐릭터가 죽을때 호출되는걸로하고, 적캐릭터는 각각의 위치번호를 가지고있다고치면,,
    // 같은자리에 2가지의 랜덤몹이 생성될수도 있는것인데.. 죽을때 애니메이션에서 불르는데 그함수안에 이것도 넣으면됨
    public void GenerateNewEnemy(int whichGenPosition,float reGenTime)
    {
     int whichEnemy =   Random.Range(0, enemyPrefabs.Length);
        StartCoroutine(RegenCounterOn(whichEnemy, whichGenPosition,reGenTime));


    }

    IEnumerator RegenCounterOn(int enemyNum, int genPos, float reGenWait)
    {


        float startCount = 0;
        while(startCount < reGenWait)
        {
            startCount++;
            yield return new WaitForSeconds(1f);

            if(startCount == reGenWait)
            {


                GameObject enemy;
             enemy =   Instantiate(enemyPrefabs[enemyNum], genPositions[genPos].position, Quaternion.identity );   // 이부분을 차일드로 넣어야함
                enemy.name = enemyPrefabs[enemyNum].name;
                StopCoroutine("RegenCounterOn");
            }

        }
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}