using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public GameObject Panel;

    public void PanelOpen() // This function will be called when the button is clicked (specifically for the 'how to play' button)
    {
        if(Panel != null)
        {
            Panel.SetActive(true);
        }
    }

}
