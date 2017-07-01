using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreController : MonoBehaviour {

	[SerializeField]
	private UnityEngine.UI.Text[] nameText;
	[SerializeField]
	private UnityEngine.UI.Text[] scoreText;

	// Use this for initialization
	void Start () {
		StartCoroutine("SetText");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator SetText()
	{
		var coroutine = HighScore.List(nameText.Length);
		yield return StartCoroutine(coroutine);
		var entries = (List<HighScore.Entry>)coroutine.Current;
		for(int i = 0; i < entries.Count; i++)
		{
			nameText[i].text = entries[i].name;
			scoreText[i].text = entries[i].score.ToString();
		}
	}
}
