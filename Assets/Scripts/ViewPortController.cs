using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPortController : MonoBehaviour {

	[SerializeField]
	private float targetRatio;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		var camera = GetComponent<Camera>();
		float currentRatio = Screen.width * 1f / Screen.height;
		float ratio = targetRatio / currentRatio;
		if (ratio < 1f)
		{
			float rectX = (1f - ratio) / 2f;
			camera.rect = new Rect(rectX, 0f, ratio, 1f);
		}
		else
		{
			ratio = 1f / ratio;
			float rectY = (1f - ratio) / 2f;
			camera.rect = new Rect(0f, rectY, 1f, ratio);
		}
	}
}
