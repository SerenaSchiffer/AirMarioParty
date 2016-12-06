using UnityEngine;
using System.Collections;

public class PlayerCar : MonoBehaviour {
    public static int goalCornets;

    public int playerNumber;
    public int nombreCornets;
    public float speed = 3f;
    public float rotationSpeed = 3f;

    private Rigidbody2D myRB2D;
	// Use this for initialization
	void Start () {
        nombreCornets = 0;
        playerNumber = 1;
        myRB2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        myRB2D.velocity = transform.up * speed;

        if(Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(new Vector3(0, 0, Input.GetAxis("Horizontal") * rotationSpeed));
        }
	}
}
