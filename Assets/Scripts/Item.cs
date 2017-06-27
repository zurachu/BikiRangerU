using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public event System.Action CollidedWithPlayer = delegate { };

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
		var layerName = LayerMask.LayerToName(collision.gameObject.layer);
		if(layerName == "PlayerToItem")
		{
			CollidedWithPlayer();
			Destroy(gameObject);
		}
		else if(layerName == "WallForItem")
		{
			var rigidbody = GetComponent<Rigidbody2D>();
			Vector2 velocity = rigidbody.velocity;
			velocity.y = -velocity.y;
			rigidbody.velocity = velocity;
		}
	}
}
