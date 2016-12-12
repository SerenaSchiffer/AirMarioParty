using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    private bool isHisTurn;
    private int idPlayer;
    private int nbIceCreamCone;

    public GameObject actualTile;
    public Text txt;

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
        txt.text = "x " + nbIceCreamCone;
    }

    private void DecreaseNBIceCreamCone()
    {
        nbIceCreamCone -= 5;
        if (nbIceCreamCone < 0)
            nbIceCreamCone = 0;

        txt.text = "x " + nbIceCreamCone;
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
