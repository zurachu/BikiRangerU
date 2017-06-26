using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	[SerializeField]
	private GameObject zavu;
	[SerializeField]
	private GameObject bomb;
	[SerializeField]
	private GameObject canvas;
	[SerializeField]
	private GameObject scoreZavu;
	[SerializeField]
	private float scrollSpeed;
	[SerializeField]
	private float zavuCountMax;

	private int currentScore = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine("EmitZavu");
		StartCoroutine("EmitBomb");
		AddScore(10);
		ResetScore();
		AddScore(10);
	}

	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator EmitZavu()
	{
		while (true)
		{
			int zavuCount = GameObject.FindGameObjectsWithTag("Zavu").Length;
			if (zavuCount < zavuCountMax)
			{
				var newZavu = Instantiate(zavu);
				InitializeItem(newZavu, 1);
			}
			yield return new WaitForSeconds(0.5f);
		}
	}

	private IEnumerator EmitBomb()
	{
		while (true)
		{
			var newBomb = Instantiate(bomb);
			InitializeItem(newBomb, 5);
			yield return new WaitForSeconds(Random.Range(0.5f, 1f));
		}
	}

	private void InitializeItem(GameObject item, float forceRangeY)
	{
		Vector2 leftTop = Camera.main.ViewportToWorldPoint(new Vector2(0, 1));
		Vector2 rightBottom = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
		float startX = leftTop.x - 1;
		float topY = leftTop.y - 1;
		float bottomY = rightBottom.y + 1;

		item.GetComponent<Transform>().position = new Vector2(startX, Random.Range(bottomY, topY));
		item.GetComponent<Rigidbody2D>().AddForce(new Vector2(scrollSpeed, Random.Range(-forceRangeY, forceRangeY)), ForceMode2D.Impulse);
	}

	private void AddScore(int score)
	{
		for(int i = 0; i < score; i++)
		{
			var newScoreZavu = Instantiate(scoreZavu);
			var rectTransform = newScoreZavu.GetComponent<RectTransform>();
			rectTransform.SetParent(canvas.transform, false);
			Vector2 position = rectTransform.anchoredPosition;
			position.y -= currentScore * 2;
			rectTransform.anchoredPosition = position;
			++currentScore;
		}
	}

	private void ResetScore()
	{
		var scoreZavus = GameObject.FindGameObjectsWithTag("ScoreZavu");
		foreach(var obj in scoreZavus)
		{
			Destroy(obj);
		}
		currentScore = 0;
	}
}
