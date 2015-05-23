using UnityEngine;
using System.Collections;

public class LevelButtonScript : ButtonScript 
{
    [SerializeField] float _xPos;
    [SerializeField] float _yPos;
    [SerializeField] string _levelName;
    public string LevelName { get { return _levelName; } }

    bool _selected = false;
    public bool Selected { get { return _selected; } }
    string _unselectedImage = "Assets/Resources/TempSprites/UnselectedButton.png";
    string _selectedImage = "Assets/Resources/TempSprites/SelectedButton.png";

	void Start () 
    {
        _buttonTexture = (Texture)(Resources.LoadAssetAtPath(_unselectedImage, typeof(Texture)));
	}
	
    protected override void OnGUI()
    {
        if(GUI.Button(new Rect(_xPos, _yPos, 440, 32), _buttonTexture, GUIStyle.none))
        {
            ToggleButton();
        }
    }

    public void ToggleButton()
    {
        if(!_selected)
        {
            _selected = true;
            _buttonTexture = (Texture)(Resources.LoadAssetAtPath(_selectedImage, typeof(Texture)));
            transform.parent.GetComponent<LevelSelectScript>().UpdateDownloadButton(this);
        }
        else
        {
            _selected = false;
            _buttonTexture = (Texture)(Resources.LoadAssetAtPath(_unselectedImage, typeof(Texture)));
            transform.parent.GetComponent<LevelSelectScript>().UpdateDownloadButton(this);
        }
    }

	void Update () 
    {
	
	}
}
