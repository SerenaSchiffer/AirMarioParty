using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class MapScript : MonoBehaviour {

    GameObject playersFolder;
    Dictionary<int, PlayerScript> players = new Dictionary<int, PlayerScript>();
    int diceResult;
    int idPlayerPlaying;
    int idPlayerActualTile;

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

        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
        AirConsole.instance.onDisconnect += OnDisconnect;
    }

    void OnMessage(int device_id, JToken data)
    {
        if (device_id != -1)
        {
            if (device_id - 1 == idPlayerPlaying)
            {
                diceResult = Random.Range(1, 7);
                GameObject uiCpt = GameObject.Find("Cpt");
                Text textCpt = uiCpt.GetComponent<Text>();

                textCpt.text = diceResult.ToString();

                PrepareMovePlayer(diceResult);
                ChangePlayer();
            }
        }

        
    }

    void OnConnect(int device_id)
    {
        switch (device_id)
        {
            case 1:
                AirConsole.instance.Message(device_id, "white");
                break;
            case 2:
                AirConsole.instance.Message(device_id, "red");
                break;
            case 3:
                AirConsole.instance.Message(device_id, "yellow");
                break;
            case 4:
                AirConsole.instance.Message(device_id, "green");
                break;
        }
    }

    void OnDisconnect(int device_id)
    {
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
        idPlayerActualTile = playerActualTile.GetComponent<TileScript>().idTile;
        
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
            Debug.Log(idPlayerActualTile);

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