using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour 
{
    Texture _playButtonTex = null;
    Texture _quitButtonTex = null;
    float _nativeWidth = 480;
    float _nativeHeight = 640;
	
	void Start ()
    {
	    if(!_playButtonTex)
        {
            _playButtonTex = (Texture)(Resources.Load("TempSprites/PlayButton"));
            _quitButtonTex = (Texture)(Resources.Load("TempSprites/QuitButton"));
        }
	}

    void OnGUI()
    {
        float rx = Screen.width / _nativeWidth;
        float ry = Screen.height / _nativeHeight;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1));

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
