using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathScreenUI : MonoBehaviour
{
    [SerializeField] private TMP_Text finalScoreText;

    public void ShowWithScore(int finalScore)
    {
        gameObject.SetActive(true);

        if (finalScoreText)
            finalScoreText.text = $"{finalScore}";

    }
}