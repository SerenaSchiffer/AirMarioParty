using UnityEngine;
using System.Collections;

public class CharacterSelectionCamera : MonoBehaviour {

    int idPos;
    int idColor;

	// Use this for initialization
	void Start () {
        idPos = 1;
        idColor = 1;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            IncreaseIdPos();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            DecreaseIdPos();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            IncreaseIdColor();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DecreaseIdColor();
        }

        UpdateCameraPosition();
        UpdateColor();
	}

    private void IncreaseIdPos()
    {
        if (idPos == 4)
            idPos = 1;
        else
            idPos++;
    }

    private void DecreaseIdPos()
    {
        if (idPos == 1)
            idPos = 4;
        else
            idPos--;
    }

    private void IncreaseIdColor()
    {
        if (idColor == 4)
            idColor = 1;
        else
            idColor++;
    }

    private void DecreaseIdColor()
    {
        if (idColor == 1)
            idColor = 4;
        else
            idColor--;
    }

    private void UpdateColor()
    {
        switch (idColor)
        {
            case 1:
                ChangeAnimalsColor(Color.white);
                break;

            case 2:
                ChangeAnimalsColor(Color.red);
                break;

            case 3:
                ChangeAnimalsColor(Color.yellow);
                break;

            case 4:
                ChangeAnimalsColor(Color.green);
                break;
        }
    }

    private void ChangeAnimalsColor(Color newColor)
    {
        GameObject polarBear = GameObject.Find("OursPolaire");
        polarBear.GetComponent<SpriteRenderer>().color = newColor;

        GameObject brownBear = GameObject.Find("OursBrun");
        brownBear.GetComponent<SpriteRenderer>().color = newColor;

        GameObject camel = GameObject.Find("Chameau");
        camel.GetComponent<SpriteRenderer>().color = newColor;

        GameObject elephant = GameObject.Find("Elephant");
        elephant.GetComponent<SpriteRenderer>().color = newColor;
    }

    private void UpdateCameraPosition()
    {
        switch (idPos)
        {
            case 1:
                transform.position = new Vector3(0, 0, -10);
                break;

            case 2:
                transform.position = new Vector3(20, 0, -10);
                break;

            case 3:
                transform.position = new Vector3(40, 0, -10);
                break;

            case 4:
                transform.position = new Vector3(60, 0, -10);
                break;
        }
    }
}
