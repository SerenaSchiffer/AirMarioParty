using UnityEngine;
using System.Collections;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class ShakeScript : MonoBehaviour {

    public bool gameStarted = false;

    // Use this for initialization
    void Start () {
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
        AirConsole.instance.onDisconnect += OnDisconnect;
    }

    void OnMessage(int device_id, JToken data)
    {
        float valeurZ = (float)data["Z"];
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

        if (AirConsole.instance.GetActivePlayerDeviceIds.Count == 0)
        {
            if (AirConsole.instance.GetControllerDeviceIds().Count >= 2)
            {
                StartGame();
            }
            /* else
             {
                 uiText.text = "NEED MORE PLAYERS";
             }*/
        }
        StartGame();
    }

    void OnDisconnect(int device_id)
    {
        int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber(device_id);
        if (active_player != -1)
        {
            if (AirConsole.instance.GetControllerDeviceIds().Count >= 2)
            {
                StartGame();
            }
            else
            {
                gameStarted = false;
                /*AirConsole.instance.SetActivePlayers(0);
                ResetBall(false);
                uiText.text = "PLAYER LEFT - NEED MORE PLAYERS";*/
            }
        }
    }

    void StartGame()
    {
        AirConsole.instance.SetActivePlayers(AirConsole.instance.GetControllerDeviceIds().Count);
        gameStarted = true;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
