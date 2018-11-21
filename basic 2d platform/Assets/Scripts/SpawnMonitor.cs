using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonitor : MonoBehaviour {

    public int maxPlatforms = 20;
    public GameObject platform;
    public float horizontalMin = 6.5f;
    public float horizontalMax = 14f;
    public float verticalMin = -6f;
    public float verticalMax = 6f;

    private Vector2 originalPosition;
	// Use this for initialization
	void Start () {
        originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void spawn () {
		for (int i = 0; i < maxPlatforms; i++)
        {
            Vector2 randomPosition = originalPosition + new Vector2(Random.Range(horizontalMax, horizontalMin), Random.Range(verticalMax, verticalMin));
            Instantiate(platform, randomPosition, Quaternion.identity);
            originalPosition = randomPosition;
        }
	}
}
