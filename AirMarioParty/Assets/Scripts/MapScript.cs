using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MapScript : MonoBehaviour {

    GameObject playersFolder;
    Dictionary<int, PlayerScript> players = new Dictionary<int, PlayerScript>();
    int diceResult;
    int idPlayerPlaying;

	// Use this for initialization
	void Start () {
        int cpt = 0;
        idPlayerPlaying = 0;
        playersFolder = GameObject.Find("Players");
        
        foreach (Transform player in playersFolder.transform)
        {
            players.Add(cpt, player.GetComponent<PlayerScript>());
            players[cpt].SetIdPlayer(cpt);
            cpt++;
        }

        players[0].SetIsHisTurn(true);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown("space"))
        {
            diceResult = Random.Range(1, 7);
            GameObject uiCpt = GameObject.Find("Cpt");
            Text textCpt = uiCpt.GetComponent<Text>();

            textCpt.text = diceResult.ToString();

            PrepareMovePlayer(diceResult);
            ChangePlayer();
        }
	}

    public Dictionary<int, PlayerScript> GetPlayers()
    {
        return players;
    }

    private void PrepareMovePlayer(int movement)
    {
        PlayerScript pScript = players[idPlayerPlaying];
        GameObject playerActualTile = pScript.actualTile;
        int idPlayerActualTile = playerActualTile.GetComponent<TileScript>().idTile;

        MovePlayer(idPlayerActualTile, movement, playerActualTile, pScript.GetComponentInParent<Transform>());
        pScript.PlayTile();
    }

    private void MovePlayer(int idPlayerActualTile, int movement, GameObject actualTile, Transform player)
    {
        int idNextTile;
        Vector3 diff;
        GameObject nextTile;
        for (int i = 1; i <= movement; i++)
        {
            idNextTile = GetIdNextTile(i, idPlayerActualTile);

            nextTile = GameObject.Find("tile (" + (idNextTile) + ")");

            diff = nextTile.transform.position - actualTile.transform.position;
            actualTile = nextTile;
            
            player.Translate(diff);
        }

        player.GetComponent<PlayerScript>().actualTile = actualTile;
    }

    private int GetIdNextTile(int i, int idPlayerActualTile)
    {
        if (idPlayerActualTile + i > 41)
            return (idPlayerActualTile + i) - 41;
        else
            return idPlayerActualTile + i;
    }

    private void ChangePlayer()
    {
        if (idPlayerPlaying == 3)
            idPlayerPlaying = 0;
        else
            idPlayerPlaying++;
    }
}