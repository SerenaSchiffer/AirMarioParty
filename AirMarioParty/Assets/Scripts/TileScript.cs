using UnityEngine;
using System.Collections;

public enum TileType
{
    Start,
    GainIceCream,
    LoseIceCream,
    MiniGame
}

public class TileScript : MonoBehaviour {

    public TileType tileType;
    public int idTile;

	// Use this for initialization
	void Start () {

        SpriteRenderer sp = GetComponent<SpriteRenderer>();
	    switch (tileType)
        {
            case TileType.Start:
                sp.color = Color.magenta;
                break;

            case TileType.GainIceCream:
                sp.color = Color.yellow;
                break;

            case TileType.LoseIceCream:
                sp.color = Color.red;
                break;

            case TileType.MiniGame:
                sp.color = Color.blue;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
