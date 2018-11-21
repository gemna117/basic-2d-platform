using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerFall : MonoBehaviour {

    public float fallDelay;

    private Rigidbody2D rb2d;
	// Use this for initialization
	void awake ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player"))
            rb2d.isKinematic = false;
    }
}
