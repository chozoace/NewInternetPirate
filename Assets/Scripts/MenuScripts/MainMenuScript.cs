using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour 
{
    Texture _playButtonTex = null;
    Texture _quitButtonTex = null;
	
	void Start ()
    {
	    if(!_playButtonTex)
        {
            _playButtonTex = (Texture)(Resources.LoadAssetAtPath("Assets/Resources/TempSprites/PlayButton.png", typeof(Texture)));
            _quitButtonTex = (Texture)(Resources.LoadAssetAtPath("Assets/Resources/TempSprites/QuitButton.png", typeof(Texture)));
        }
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(40, 450, 150, 60), _playButtonTex, GUIStyle.none))
        {
            Application.LoadLevel("LevelSelect");
        }
        if (GUI.Button(new Rect(300, 450, 150, 60), _quitButtonTex, GUIStyle.none))
        {
            Application.Quit();
        }
    }
	
	void Update () 
    {
        
	}
}
