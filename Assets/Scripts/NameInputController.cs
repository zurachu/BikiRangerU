using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameInputController : MonoBehaviour {
	[SerializeField]
	private GameObject backButton;

	// Use this for initialization
	void Start () {
		if(NickName.Value() == "")
		{
			backButton.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.platform == RuntimePlatform.Android && Input.GetKey(KeyCode.Escape))
		{
			if(NickName.Value() == "")
			{
				Application.Quit();
			}
			else
			{
				backButton.GetComponent<BackToTitleButton>().OnClick();
			}
		}
	}
}
