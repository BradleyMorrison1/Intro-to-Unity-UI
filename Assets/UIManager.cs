using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public Slider scoreModSlider;

    private float score;
    public float scoreModifier = 1;
    private float autoScoresPurchased = 0;

    private bool canBuyAuto; // determines if the player can buy the auto increase upgrade
    private float autoScorePrice; // price to buy auto score
    private float prevAutoScorePrice; // previous price to buy auto score
    public TMP_Text autoScorePriceText;

    public Sprite[] images;
    public Image img;
    public TMP_Dropdown imageDropdown;

    void Update()
    {
        scoreText.text = ("Score | " + Mathf.Round(score).ToString());
        autoScorePriceText.text = ("Buy Score Auto Increase (" + Mathf.Round(autoScorePrice).ToString() + " Score)");
        scoreModifier = scoreModSlider.value;

        if (score >= autoScorePrice) canBuyAuto = true;
        if (autoScorePrice <= 100f) autoScorePrice = 100f;

        if (score <= 0) score = 0;

        score += autoScoresPurchased * scoreModifier; // increases score by the amount of auto scores

        // dropdown menu code

        switch (imageDropdown.value)
        {
            case 0: img.sprite = images[0];
                break;
            case 1:
                img.sprite = images[1];
                break;
            case 2:
                img.sprite = images[2];
                break;
            case 3:
                img.sprite = images[3];
                break;
            case 4:
                img.sprite = images[4];
                break;
        }
    }

    private void Start()
    {
        autoScorePrice = 100;
    }

    public void BuyAutoScore()
    {
        if(canBuyAuto)
        {
            prevAutoScorePrice = autoScorePrice;
            autoScorePrice = (prevAutoScorePrice + score * 0.4f);
            autoScoresPurchased++;
            score -= autoScorePrice;
            canBuyAuto = false;
        }
    }

    public void IncreaseScore()
    {
        score += 1 * scoreModifier;
    }

    public void Exit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
