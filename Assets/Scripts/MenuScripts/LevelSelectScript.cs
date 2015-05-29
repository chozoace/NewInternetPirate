using UnityEngine;
using System.Collections;

public class LevelSelectScript : MonoBehaviour 
{
	void Start () 
    {
	    
	}

    public void UpdateDownloadButton(LevelButtonScript caller)
    {
        if (caller.Selected)
        {
            Component[] levelSelectButtons = GetComponentsInChildren<LevelButtonScript>();
            foreach (LevelButtonScript levelButton in levelSelectButtons)
            {
                //Change everything to false except for caller
                if (levelButton != caller && levelButton.Selected == true)
                {
                    levelButton.ToggleButton();
                }
                //check which one is true and give that name to the download button
            }
        }
        Component[] downloadButton = GetComponentsInChildren<DownloadButtonScript>();
        foreach (DownloadButtonScript theButton in downloadButton)
        {
            theButton.ChangeButtonImage(caller);
        }
    }
	
	void Update () 
    {
	
	}
}
