using UnityEngine;
using UnityEngine.UI;


public class UIScript : MonoBehaviour {

    private int scoreInt = 0;
    private Text scoreText;

    void Awake () {
        scoreText = GetComponentInChildren<Text>();
    }
    
    void Start () {
        scoreText.text = scoreInt.ToString("D8");
    }

    public void ScoreAdd (int myScore) {
        scoreInt += myScore;
        scoreText.text = scoreInt.ToString("D8");
    }

}