using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SorryToby : MonoBehaviour
{
    public void Sorry()
    {
        SceneManager.LoadScene("End Menu"); // This will load the end menu
    }
}
