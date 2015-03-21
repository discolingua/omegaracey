using UnityEngine;
using UnityEngine.UI;


public class UIScript : MonoBehaviour {

    public int scoreInt = 0;
    public Text scoreText;

    void Awake () {
        scoreText = GetComponentInChildren<Text>();
    }
    
    void Start () {
        scoreText.text = scoreInt.ToString("D8");
    }
}