using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;
    private float score;
    private bool shouldCount = true;

    // Update is called once per frame
    void Update()
    {
        if (!shouldCount)
        {
            return;
        }

        score += Time.deltaTime * scoreMultiplier;

        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public int EndTimer()
    {
        shouldCount = false;
        scoreText.text = "";
        return Mathf.FloorToInt(score);
    }
}
