using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] InputField nameInput;
    [SerializeField] string filename;
    

    List<InputEntry> inputEntries = new List<InputEntry>(); // This is the list of entries that will be saved to the file

    private void Start()
    {
        inputEntries = FileHandler.ReadListFromJSON<InputEntry>(filename); // This will read the list of entries from the file
    }

    public void AddNameToList () // This function will be called when the player clicks the "Play" button
    {
        PlayerPrefs.SetString("currentScore", "0");
        inputEntries.Add(new InputEntry(nameInput.text, Convert.ToInt32(PlayerPrefs.GetString("currentScore")))); // This will add the player's name and score to the list
        PlayerPrefs.SetString("playerName", nameInput.text);
    }
}
