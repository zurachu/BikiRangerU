using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	[SerializeField]
	private GameObject zavu;
	[SerializeField]
	private GameObject bomb;
	[SerializeField]
	private float scrollSpeed;

	// Use this for initialization
	void Start () {
		Vector2 leftTop = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		float startX = leftTop.x - 1;

		var newZavu = Instantiate(zavu);
		newZavu.GetComponent<Transform>().position = new Vector2(startX, 0);
		newZavu.GetComponent<Rigidbody2D>().AddForce(new Vector2(scrollSpeed, 0), ForceMode2D.Impulse);

		var newBomb = Instantiate(bomb);
		newBomb.GetComponent<Transform>().position = new Vector2(startX, 0);
		newBomb.GetComponent<Rigidbody2D>().AddForce(new Vector2(scrollSpeed, scrollSpeed), ForceMode2D.Impulse);
	}

	// Update is called once per frame
	void Update () {

	}
}
