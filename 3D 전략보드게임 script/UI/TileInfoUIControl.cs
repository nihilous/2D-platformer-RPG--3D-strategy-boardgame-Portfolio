using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileInfoUIControl : MonoBehaviour {

    public string[] tileDescriptions;
    public Text[] descriptions;
    public GameObject tileInfoUI;
    TileType clickedTileType;
    RaycastHit hit;

    public void OnTileInfoPannel(RaycastHit clickedTile)
    {
        clickedTileType = clickedTile.collider.gameObject.GetComponent<TileType>();
        descriptions[0].text = clickedTileType.thisTileType + "";
        descriptions[1].text = clickedTileType.thisTileOwner + "";
        descriptions[2].text = tileDescriptions[(int)clickedTileType.thisTileType];

    }

    public void OnCloseBtnClick()
    {
        tileInfoUI.SetActive(false);
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(1))
        {



            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out hit);



            if (hit.collider.tag == "TILE")
            {
                tileInfoUI.SetActive(true);

                OnTileInfoPannel(hit);
            }

        }



    }
}
