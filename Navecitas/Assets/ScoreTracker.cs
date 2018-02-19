using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

    public int score = 0;

    public void AddScore(int score)
    {
        this.score += score;
        this.GetComponent<Text>().text = "Score: " + this.score;
    }
}
