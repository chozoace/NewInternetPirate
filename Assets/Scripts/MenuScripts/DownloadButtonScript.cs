using UnityEngine;
using System.Collections;

public class DownloadButtonScript : ButtonScript 
{
    float _nativeWidth = 480;
    float _nativeHeight = 640;
    [SerializeField] float _xPos;
    [SerializeField] float _yPos;
    string _levelName;

    bool _levelSelected = false;
    public bool LevelSelected { get { return _levelSelected; } }
    string _unselectedImage = "TempSprites/DownloadButton1";
    string _selectedImage = "TempSprites/DownloadButton2";

	void Start ()
    {
        _buttonTexture = (Texture)(Resources.Load(_unselectedImage));
	}

    protected override void OnGUI()
    {
        float rx = Screen.width / _nativeWidth;
        float ry = Screen.height / _nativeHeight;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1));

        if (GUI.Button(new Rect(_xPos, _yPos, 80, 32), _buttonTexture, GUIStyle.none))
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
            _buttonTexture = (Texture)(Resources.Load(_selectedImage));
            _levelName = levelButton.LevelName;
        }
        else if(!levelButton.Selected)
        {
            _levelSelected = false;
            _buttonTexture = (Texture)(Resources.Load(_unselectedImage));
        }
    }

    void ToggleButton()
    {
        //Load Levels here
        Debug.Log("Download Toggled: " + _levelName);
        Application.LoadLevel(_levelName);
    }

	void Update () 
    {
	    
	}
}
