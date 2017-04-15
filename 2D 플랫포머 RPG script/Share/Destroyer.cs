using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    public float _destroyDelayTime; // 파괴 지연시간

    public bool _isAutoDestroy; // 자동파괴여부

    protected virtual void Awake()
    {

    }


    public virtual void Destroy()
    {
        // 지정된 파괴 시간뒤에 오브젝트를 파괴함
        Destroy(gameObject, _destroyDelayTime);

    }

    // Use this for initialization
    protected virtual void Start()
    {

        // 자동파괴 되기를 원한다면, 설정시간후에
        if (_isAutoDestroy) Destroy();  // 파괴시킴

    }

    // Update is called once per frame
    void Update()
    {

    }
}