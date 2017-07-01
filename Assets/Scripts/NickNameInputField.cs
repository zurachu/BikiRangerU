using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickNameInputField : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<UnityEngine.UI.InputField>().text = NickName.Value();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SaveAndExit()
	{
		string nickName = GetComponent<UnityEngine.UI.InputField>().text;
		if(nickName.Length > 0)
		{
			NickName.Apply(nickName);
			UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
		}
	}
}
