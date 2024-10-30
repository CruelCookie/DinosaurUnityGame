using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreLabel;
    private int lastMilestone = 0;
    private bool IsBlinking = false;

    [SerializeField] TextMeshProUGUI BestScoreLabel;
    private const string BestScoreKey = "BestScore";

    void Start()
    {
        BestScoreLabel.gameObject.SetActive(false);
    }

    void Update()
    {
        Global.score += Global.gameSpeed * Time.deltaTime;
        int currentScore = Mathf.FloorToInt(Global.score);
        scoreLabel.text = currentScore.ToString("D5");

        if(currentScore >= lastMilestone + 100)
        {
            lastMilestone += 100;
            if(!IsBlinking)
            {
                StartCoroutine(BlinkScore());
            }
        }
    }

    IEnumerator BlinkScore()
    {
        IsBlinking = true;
        for (int i = 0; i < 6; i++)
        {
            scoreLabel.enabled = !scoreLabel.enabled;
            yield return new WaitForSeconds(0.2f);
        }
        scoreLabel.enabled = true;
        IsBlinking = false;
    }

        public void UpdateBestScoreDisplay()
    {
        int BestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        if (BestScore > 0){
            BestScoreLabel.gameObject.SetActive(true);
            BestScoreLabel.text = "HI " + BestScore.ToString("D5");
        }
    }
}