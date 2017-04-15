using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    // 떨굼 아이템 목록
    public GameObject _goldPrefab;


    public GameObject[] _dropItemPrefabs;

    // static int 변수 만들어놓고
    // 이하 메소드콜때마다 ++ 해주면  생성된거 이름 넘버링으로 제어가능함
    public void GoldDrop()  // 애니메이션에서 불러오고있는데.. GoldDrop이랑 Drop을 같이실행하는 아이템드랍을 호출하면  골드도 아이템도 떨구는거로 만들수있음
    {

        GameObject nameChecker = Instantiate(_goldPrefab, transform.position, Quaternion.identity);

        nameChecker.name = _goldPrefab.gameObject.name; // 여기에 스태틱 인수 붙이면 스트링이 우선됨
    }

    public void Drop()
    {
        // 확률로 아이템을 선택함
        int index = Random.Range(0, _dropItemPrefabs.Length);

        // 아이템을 생성함
        GameObject nameChecker = Instantiate(_dropItemPrefabs[index], transform.position, Quaternion.identity);
        nameChecker.name = _dropItemPrefabs[index].gameObject.name;

        // 이름에서 clone 제외하고  아이템에 콜라이드시  게임오브젝트 네임으로 프로퍼티 넣어서 숫자도 +1 해주면됨
    }
}