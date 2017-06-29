﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToTitleButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Application.platform == RuntimePlatform.Android && Input.GetKey(KeyCode.Escape))
		{
			OnClick();
		}
	}

	public void OnClick()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
	}
}
