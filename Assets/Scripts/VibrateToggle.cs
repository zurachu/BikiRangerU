using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateToggle : MonoBehaviour {

	private readonly string playerPrefsKey = "hasVibrate";
	private readonly int on = 1;

	// Use this for initialization
	void Start () {
		int val = PlayerPrefs.GetInt(playerPrefsKey, on);
		GetComponent<UnityEngine.UI.Toggle>().isOn = (val == on);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnValueChanged(bool flag)
	{
		PlayerPrefs.SetInt(playerPrefsKey, flag ? on : 0);
		PlayerPrefs.Save();
	}
}
