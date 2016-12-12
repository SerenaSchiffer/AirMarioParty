using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShakeThat : MonoBehaviour {

    public Slider slider1, slider2, slider3, slider4;

	// Use this for initialization
	void Start () {
        slider1.value = 0;
        slider2.value = 0;
        slider3.value = 0;
        slider4.value = 0;
    }
	
	// Update is called once per frame
	void Update () {
        slider1.value += 5;
        slider2.value += 6;
        slider3.value += 3;
        slider4.value += 4;

        if(slider3.value == 1000)
        {
            SceneManager.LoadScene(1);
        }
	}
}
