using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameStatsScript : MonoBehaviour {
	private int score = 0;
	private int coins = 0;

	private GameObject UI;	private Text UI_Text_Coins;
	private Text UI_Text_Score;

	// Use this for initialization
	void Start () {
		this.UI_Text_Coins = GameObject.Find("UI/Text_Coins").GetComponent<Text>();
		this.UI_Text_Score = GameObject.Find("UI/Text_Score").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		this.UI_Text_Coins.text = this.coins.ToString();
		this.UI_Text_Score.text = this.score.ToString();
	}

	public void AddCoin() {
		this.coins++;
	}

	public void AddScore(int scoreNew) {
		this.score += scoreNew;
	}
}
