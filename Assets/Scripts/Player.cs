using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	private float speed;

	private Vector3 previousMousePosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			previousMousePosition = Input.mousePosition;
		}
		else if(Input.GetMouseButton(0))
		{
			Vector2 direction = (Input.mousePosition - previousMousePosition).normalized;
			GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
			previousMousePosition = Input.mousePosition;
		}
	}
}
