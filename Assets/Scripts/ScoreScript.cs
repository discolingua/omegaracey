using UnityEngine;

public class ScoreScript : MonoBehaviour {

    /// <summary>
    ///   Component to add/reduce score in the UI 
    /// </summary>

    private GameObject uiTrans;
    
    public void Start() {
        uiTrans = GameObject.Find("UICanvas");
    }
    
    public void ScoreAdd (int myScore) {
        uiTrans.GetComponent<UIScript>().scoreInt += myScore;
        uiTrans.GetComponent<UIScript>().scoreText.text = uiTrans.GetComponent<UIScript>().scoreInt.ToString("D8");
    }

}