using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class AirConsoleCarHelper : MonoBehaviour {
    static public int nombreFinis = 0;
	// Use this for initialization
	void Start ()
    {
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
        AirConsole.instance.onDisconnect += OnDisconnect;

    }

    void Update()
    {
        if (nombreFinis == 3)
            SceneManager.LoadScene(0);
    }

    void OnMessage(int device_id, JToken data)
    {
        //int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber(device_id);
        if (device_id != -1)
        {
            Debug.Log(device_id);
            GameObject.Find(device_id.ToString()).GetComponent<PlayerCar>().turnAxis = -(float)data["move"];
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

    }
