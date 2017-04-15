using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmo : MonoBehaviour {

    public Color _color = Color.yellow;
    public float _radius = 0.1f;

    void OnDrawGizmos()
    {
        Gizmos.color = _color;      // 노란색으로 생성
        Gizmos.DrawSphere(transform.position, _radius); // 스크립트가 붙어있는 오브젝트자리에 반지름만큼
    }

}
