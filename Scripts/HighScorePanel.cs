using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScorePanel : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject HighScoreElementPrefab;
    [SerializeField] Transform HighScoreElementParent;

    List<GameObject> uiElements = new List<GameObject>(); // List of UI elements

    private void OnEnable()
    {
        ScoreHandler.onHighscoreListChanged += UpdateUI; 
    }
    private void OnDisable()
    {
        ScoreHandler.onHighscoreListChanged -= UpdateUI;
    }

    public void UpdateUI(List<HighScoreElement> list) // This function will be called when the highscore list is changed
    {
        for(int i = 0; i < list.Count; i++)
        {
            HighScoreElement element = list[i];

            if (element.score > 0)
            { 
                if (i >= uiElements.Count)
                {
                    //instantiate new entry
                    var inst = Instantiate(HighScoreElementPrefab, Vector3.zero, Quaternion.identity); 
                    inst.transform.SetParent(HighScoreElementParent, false); 

                    uiElements.Add(inst); 
                }

                var texts = uiElements[i].GetComponentsInChildren<TextMeshProUGUI>();
                texts[0].text = element.playerName;
                texts[1].text = element.score.ToString();
            }
        }
    }
}
