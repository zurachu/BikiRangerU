using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zavu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float endX = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x + 1;
		if(endX < transform.position.x)
		{
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(LayerMask.LayerToName(collision.gameObject.layer) == "PlayerToItem")
		{
			Destroy(gameObject);
		}
	}
}
