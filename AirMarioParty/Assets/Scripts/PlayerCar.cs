using UnityEngine;
using System.Collections;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class PlayerCar : MonoBehaviour {
    public static int goalCornets;

    public int playerNumber;
    public int nombreCornets;
    public float speed = 3f;
    public float turnAxis = 0;
    public float rotationSpeed = 3f;
    public GameObject mySlider = null;

    private Rigidbody2D myRB2D;
	// Use this for initialization
	void Start () {
        nombreCornets = 0;
        myRB2D = GetComponent<Rigidbody2D>();
    }

    void StartGame()
    {
        AirConsole.instance.SetActivePlayers(AirConsole.instance.GetControllerDeviceIds().Count);
    }



    // Update is called once per frame
    void Update () {
        myRB2D.velocity = transform.up * speed;
        if (turnAxis != 0)
        {
            transform.Rotate(new Vector3(0, 0, -turnAxis * rotationSpeed));
        }
        mySlider.transform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
	}

    void OnCollisionEnter2D()
    {
        transform.Rotate(new Vector3(0, 0, 180));
        myRB2D.angularVelocity = 0;
    }

    void GagnerPoint()
    {
        nombreCornets++;
        mySlider.GetComponent<Slider>().value += 0.1f;
        if (nombreCornets == 10)
        {
            AirConsoleCarHelper.nombreFinis += 1;
            Destroy(mySlider);
            Destroy(this.gameObject);
        }
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
