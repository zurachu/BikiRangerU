using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	private float upSpeed;
	[SerializeField]
	private float sideSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		if(y < 0)
		{
			y = 0;
		}
		var force = new Vector2(x * sideSpeed, y * upSpeed);
		GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
	}
}
