using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMagicItem : WeaponItem
{


    // 이부분은 플레이어가 가지고있어야하는듯
  //  public bool MagicGet;

    protected override  void OnTriggerEnter2D(Collider2D col)
    {

        base.OnTriggerEnter2D(col);
        methodCaller.WhatIsInBag();

    }

    protected override void ChangeItemBool()
    {
        weaponBool.MagicGet = true;


    }

    protected override void Awake()
    {
        base.Awake();
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}