using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public GameObject currentScore;
    private TextMeshProUGUI currentScoreText;

    List<HighScoreElement> highScoreList = new List<HighScoreElement>(); // Create a list of high scores
    [SerializeField] int maxHighScores = 6; // Set the maximum number of high scores listed in the high score list
    [SerializeField] string filename;

    public delegate void OnHighscoreListChanged(List<HighScoreElement> list); 
    public static event OnHighscoreListChanged onHighscoreListChanged;

    void Start()
    {
        LoadHighScores();
        currentScoreText = currentScore.GetComponent<TextMeshProUGUI>(); 
        currentScoreText.text = PlayerPrefs.GetString("currentScore"); // Load the score
        AddHighScoreIfPossible(new HighScoreElement(PlayerPrefs.GetString("playerName"), Int32.Parse(currentScoreText.text))); // Add the score to the high score list


    }
    private void LoadHighScores() // Load the high scores
    {
        highScoreList = FileHandler.ReadListFromJSON<HighScoreElement>(filename); // Read the high scores from the file

        while (highScoreList.Count > maxHighScores) // Remove the last element if the list is too long
        {
            highScoreList.RemoveAt(maxHighScores); // Remove the last element
        }
        if (onHighscoreListChanged != null)
        {
            onHighscoreListChanged.Invoke(highScoreList); 
        }
    }
    private void SaveHighScores()
    {
        FileHandler.SaveToJSON<HighScoreElement> (highScoreList, filename); // Save the high scores
    }

    public void AddHighScoreIfPossible(HighScoreElement element)
    {
        for(int i = 0; i < maxHighScores; i++) // Loop through the high scores
        {
            if(i >= highScoreList.Count || element.score > highScoreList[i].score ) // If the score is higher than the current score
            {
                highScoreList.Insert(i, element);

                while(highScoreList.Count > maxHighScores) // Remove the last element if the list is too long
                {
                    highScoreList.RemoveAt(maxHighScores); 
                }
                SaveHighScores(); // Save the high scores

                if (onHighscoreListChanged != null) 
                {
                    onHighscoreListChanged.Invoke(highScoreList); 
                }

                break;
            }
        }
    }
}

