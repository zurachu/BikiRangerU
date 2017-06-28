using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	[SerializeField]
	private UnityEngine.UI.Text tapToStart;
	[SerializeField]
	private TimeCount timeCount;
	[SerializeField]
	private UnityEngine.UI.Text timeUp;

	[SerializeField]
	private UnityEngine.UI.Text score;

	[SerializeField]
	private GameObject player;
	[SerializeField]
	private GameObject zavu;
	[SerializeField]
	private GameObject ginZavu;
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
	}

	// Update is called once per frame
	void Update () {
		if(Application.platform == RuntimePlatform.Android && Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	public void StartGame()
	{
		if(tapToStart.enabled)
		{
			tapToStart.enabled = false;
			timeCount.transform.parent.gameObject.SetActive(true);
			timeCount.TimeOver += EndGame;
			player.GetComponent<Rigidbody2D>().constraints &= ~(RigidbodyConstraints2D.FreezePosition);
			StartCoroutine("EmitZavu");
			StartCoroutine("EmitGinZavu");
			StartCoroutine("EmitBomb");
		}
	}

	private void EndGame()
	{
		timeUp.enabled = true;
		var rigitBodies = GameObject.FindObjectsOfType<Rigidbody2D>();
		foreach (var rigidBody in rigitBodies)
		{
			rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
		}
		var animators = GameObject.FindObjectsOfType<Animator>();
		foreach (var animator in animators)
		{
			animator.speed = 0;
		}
		StopCoroutine("EmitZavu");
		StopCoroutine("EmitBomb");
		Invoke("StartRestartDialog", 2);
	}

	private IEnumerator EmitZavu()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.5f);
			int zavuCount = GameObject.FindGameObjectsWithTag("Zavu").Length;
			if (zavuCount < zavuCountMax)
			{
				var newZavu = Instantiate(zavu);
				InitializeItem(newZavu, 1);
				newZavu.GetComponent<Item>().CollidedWithPlayer += () => { AddScore(1); };
			}
		}
	}

	private IEnumerator EmitGinZavu()
	{
		yield return new WaitForSeconds(Random.Range(5, 25));
		var newZavu = Instantiate(ginZavu);
		InitializeItem(newZavu, 1, 2.5f);
		newZavu.GetComponent<Item>().CollidedWithPlayer += () => { AddScore(10); };
	}

	private IEnumerator EmitBomb()
	{
		while(true)
		{
			yield return new WaitForSeconds(Random.Range(0.5f, 1f));
			var newBomb = Instantiate(bomb);
			InitializeItem(newBomb, 5);
			newBomb.GetComponent<Item>().CollidedWithPlayer += ResetScore;
		}
	}

	private void InitializeItem(GameObject item, float forceRangeY, float forceX = 0)
	{
		Vector2 leftTop = Camera.main.ViewportToWorldPoint(new Vector2(0, 1));
		Vector2 rightBottom = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
		float startX = leftTop.x - 1;
		float topY = leftTop.y - 1;
		float bottomY = rightBottom.y + 1;

		item.GetComponent<Transform>().position = new Vector2(startX, Random.Range(bottomY, topY));
		item.GetComponent<Rigidbody2D>().AddForce(new Vector2(scrollSpeed + forceX, Random.Range(-forceRangeY, forceRangeY)), ForceMode2D.Impulse);
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

	private void StartRestartDialog()
	{
		score.transform.parent.gameObject.SetActive(true);
		score.text += currentScore.ToString();
	}

	public void Restart()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
