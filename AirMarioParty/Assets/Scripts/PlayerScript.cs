using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private bool isHisTurn;
    private int idPlayer;
    private int nbIceCreamCone;

    public GameObject actualTile;

	// Use this for initialization
	void Start () {
        nbIceCreamCone = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void PlayTile()
    {
        switch(actualTile.GetComponent<TileScript>().tileType)
        {
            case TileType.GainIceCream:
                IncreaseNBIceCreamCone();
                break;

            case TileType.LoseIceCream:
                DecreaseNBIceCreamCone();
                break;

            case TileType.MiniGame:
                //TODO Transition to mini game
                break;
        }
    }

    private void IncreaseNBIceCreamCone()
    {
        nbIceCreamCone += 5;
    }

    private void DecreaseNBIceCreamCone()
    {
        nbIceCreamCone -= 5;
    }

    public void SetIsHisTurn(bool isHisTurn)
    {
        this.isHisTurn = isHisTurn;
    }

    public bool GetIsHisTurn()
    {
        return isHisTurn;
    }

    public void SetIdPlayer(int idPlayer)
    {
        this.idPlayer = idPlayer;
    }

    public int GetIdPlayer()
    {
        return idPlayer;
    }
}
