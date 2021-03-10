using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public Slider scoreModSlider;

    public float score;
    public float scoreModifier = 1;

    void Update()
    {
        scoreText.text = ("Score | " + Mathf.Round(score).ToString());
        scoreModifier = scoreModSlider.value;
    }


    public void IncreaseScore()
    {
        score += 1 * scoreModifier;
    }
}
