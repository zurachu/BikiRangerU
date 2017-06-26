using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	[SerializeField]
	private GameObject zavu;
	[SerializeField]
	private Transform itemStartReference;
	[SerializeField]
	private float scrollSpeed;

	// Use this for initialization
	void Start () {
		var newZavu = Instantiate(zavu);
		Vector2 leftTop = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		float startX = leftTop.x - 1;
		newZavu.GetComponent<Transform>().position = new Vector2(startX, 0);
		newZavu.GetComponent<Rigidbody2D>().AddForce(new Vector2(scrollSpeed, 0), ForceMode2D.Impulse);
	}

	// Update is called once per frame
	void Update () {

	}
}
