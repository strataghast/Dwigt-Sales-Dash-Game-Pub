using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    public GameObject Panel;

    public void PanelClose() // This function will be called when the button is clicked (specifically for the 'X' button in the 'how to play' panel)
    {
        Panel.SetActive(false);
    }
}
