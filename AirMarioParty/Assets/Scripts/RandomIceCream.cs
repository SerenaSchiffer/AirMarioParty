using UnityEngine;
using System.Collections;

public class RandomIceCream : MonoBehaviour {

    public GameObject iceCream;

    BoxCollider2D spawnZone;

	// Use this for initialization
	void Start () {
        spawnZone = GetComponent<BoxCollider2D>();

        SpawnIceCream();
    }
	
	void SpawnIceCream()
    {
        float x = Random.Range(-0.5f *spawnZone.size.x, 0.5f * spawnZone.size.x);
        float y = Random.Range(-0.5f * spawnZone.size.y, 0.5f * spawnZone.size.y);
        Instantiate(iceCream, new Vector3(x, y, 0f), Quaternion.identity);
    }

    public static void SpawnIceCreamStatic()
    {
        GameObject.Find("IceCreamZone").GetComponent<RandomIceCream>().SpawnIceCream();
    }
}
