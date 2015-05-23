using UnityEngine;
using System.Collections;

public class DownloadButtonScript : ButtonScript 
{
    [SerializeField] float _xPos;
    [SerializeField] float _yPos;
    string _levelName;

    bool _levelSelected = false;
    public bool LevelSelected { get { return _levelSelected; } }
    string _unselectedImage = "Assets/Resources/TempSprites/DownloadButton1.png";
    string _selectedImage = "Assets/Resources/TempSprites/DownloadButton2.png";

	void Start ()
    {
        _buttonTexture = (Texture)(Resources.LoadAssetAtPath(_unselectedImage, typeof(Texture)));
	}

    protected override void OnGUI()
    {
        if (GUI.Button(new Rect(_xPos, _yPos, 440, 32), _buttonTexture, GUIStyle.none))
        {
            if (_levelSelected)
                ToggleButton();
        }
    }

    public void ChangeButtonImage(LevelButtonScript levelButton)
    {
        if(levelButton.Selected)
        {
            _levelSelected = true;
            _buttonTexture = (Texture)(Resources.LoadAssetAtPath(_selectedImage, typeof(Texture)));
            _levelName = levelButton.LevelName;
        }
        else if(!levelButton.Selected)
        {
            _levelSelected = false;
            _buttonTexture = (Texture)(Resources.LoadAssetAtPath(_unselectedImage, typeof(Texture)));
        }
    }

    void ToggleButton()
    {
        //Load Levels here
        Debug.Log("Download Toggled: " + _levelName);
    }

	void Update () 
    {
	    
	}
}
