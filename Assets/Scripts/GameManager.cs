using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private int score;
    public UnityEngine.UI.Text scoreText;

	// Use this for initialization
	void Start () {
        score = 0;
        UpdateScoreCounter();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddToScore (int s)
    {
        score += s;
        UpdateScoreCounter();
    }

    void UpdateScoreCounter()
    {
        scoreText.text = "Score: " + score;
    }
}
