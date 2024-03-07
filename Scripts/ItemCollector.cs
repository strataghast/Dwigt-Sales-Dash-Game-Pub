using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public GameObject score;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private AudioSource collectionSFX;

    IEnumerator Respawn(Collider2D collision, int time) // This will respawn the paper after a certain amount of time
    {
        yield return new WaitForSeconds(time); // Wait for the specified amount of time
        collision.gameObject.SetActive(true); // "Reactivate" the paper
    }

    public void Start()
    {
        scoreText = score.GetComponent<TextMeshProUGUI>();
        PlayerPrefs.SetString("currentScore", "0"); // Save the score
    }

    public void OnTriggerEnter2D(Collider2D collision) // This will be called when the player collides with a paper
    {
        
        if (collision.gameObject.CompareTag("Paper"))
        {
            collectionSFX.Play(); // Play the collection sound effect
            collision.gameObject.SetActive(false); // "Deactivate" the paper when it is collected
            scoreText.text = System.Convert.ToString(System.Convert.ToInt32(scoreText.text) + 1); // Increase the score by 1
            PlayerPrefs.SetString("currentScore", scoreText.text); // Save the score
            StartCoroutine(Respawn(collision, 6)); // Respawn the paper after 6 seconds
        }
    }
}
