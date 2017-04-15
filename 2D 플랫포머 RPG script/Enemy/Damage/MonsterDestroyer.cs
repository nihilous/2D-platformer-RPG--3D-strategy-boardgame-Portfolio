using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDestroyer : Destroyer {

    public int minGenPosition;

    public int maxGenPosition;

    public float genTime;


    // 파괴이펙트
    public GameObject _destroyEffectPrefab;

    EnemyGenerator genMethodCaller;


    // 몬스터의경우 몬스터데미지에서 디스트로이를 불러주지만  화살같은경우는 오토디스트로이해야함
    public override void Destroy()
    {
        if (_destroyEffectPrefab != null)
        {
            // 오브젝트 파괴 이펙트 생성
            Instantiate(_destroyEffectPrefab, transform.position, Quaternion.identity);
        }

 int whereToGen =        Random.Range(minGenPosition, maxGenPosition);

        genMethodCaller.GenerateNewEnemy(whereToGen,genTime);   

        base.Destroy();
    }

   protected override void  Awake()
    {
        base.Awake();
        genMethodCaller =  GameObject.Find("EnemyGenerator").GetComponent<EnemyGenerator>();
    }

    protected override void Start()
    {
        base.Start();

    }




    // Update is called once per frame
    void Update()
    {

    }
}
