using UnityEngine;
using System.Collections;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class PlayerCar : MonoBehaviour {
    public static int goalCornets;

    public int playerNumber;
    public int nombreCornets;
    public float speed = 3f;
    public float turnAxis = 0;
    public float rotationSpeed = 3f;
    public bool gameStarted = false;

    private Rigidbody2D myRB2D;
	// Use this for initialization
	void Start () {
        nombreCornets = 0;
        myRB2D = GetComponent<Rigidbody2D>();
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
        AirConsole.instance.onDisconnect += OnDisconnect;
    }

    void OnMessage(int device_id, JToken data)
    {
        int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber(device_id);
        if (active_player != -1)
        {
            if (active_player == 0)
            {
                turnAxis = -(float)data["move"];
            }
            /*if (active_player == 1)
            {
                this.racketRight.velocity = Vector3.up * (float)data["move"];
            }*/
        }
    }

    void OnConnect(int device_id)
    {
        AirConsole.instance.Message(device_id, "blue");
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
        if (gameStarted)
            myRB2D.velocity = transform.up * speed;
        else
            myRB2D.velocity = transform.up *  0f;

        if (turnAxis != 0)
        {
            transform.Rotate(new Vector3(0, 0, -turnAxis * rotationSpeed));
        }
	}

    void OnCollisionEnter2D()
    {
        transform.Rotate(new Vector3(0, 0, 180));
        myRB2D.angularVelocity = 0;
    }

    void GagnerPoint()
    {
        nombreCornets++;
        //if (nombreCornets == goalCornets)
             //VICTOIRE 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Collectible")
        {
            Destroy(other.gameObject);
            GagnerPoint();
            RandomIceCream.SpawnIceCreamStatic();
        }
    }
}
