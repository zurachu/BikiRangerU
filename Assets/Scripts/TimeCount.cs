using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCount : MonoBehaviour {

	[SerializeField]
	private float initialTime;
	[SerializeField]
	private float onlyFewTime;
	[SerializeField]
	private Color colorOfOnlyFewTime;

	private float restTime;

	// Use this for initialization
	void Start () {
		restTime = initialTime;
		UpdateText();
	}
	
	// Update is called once per frame
	void Update () {
		if(restTime > 0)
		{
			restTime -= Time.deltaTime;
			UpdateText();
		}
	}

	private void UpdateText()
	{
		float displayTime = (restTime > 0) ? restTime : 0;
		int integerPart = (int)displayTime;
		int fractionalPart = (int)(displayTime * 100) % 100;
		var uiText = GetComponent<UnityEngine.UI.Text>();
		uiText.text = integerPart.ToString("00") + "\"" + fractionalPart.ToString("00");
		if(restTime < onlyFewTime)
		{
			uiText.color = colorOfOnlyFewTime;
		}
	}
}
