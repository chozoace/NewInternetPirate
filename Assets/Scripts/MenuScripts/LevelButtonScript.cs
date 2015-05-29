using UnityEngine;
using System.Collections;

public class LevelButtonScript : ButtonScript 
{
    float _nativeWidth = 480;
    float _nativeHeight = 640;
    [SerializeField] float _xPos;
    [SerializeField] float _yPos;
    [SerializeField] string _levelName;
    public string LevelName { get { return _levelName; } }

    bool _selected = false;
    public bool Selected { get { return _selected; } }
    string _unselectedImage = "TempSprites/UnselectedButton";
    string _selectedImage = "TempSprites/SelectedButton";

	void Start () 
    {
        _buttonTexture = (Texture)(Resources.Load(_unselectedImage));
	}
	
    protected override void OnGUI()
    {
        float rx = Screen.width / _nativeWidth;
        float ry = Screen.height / _nativeHeight;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1));

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
            _buttonTexture = (Texture)(Resources.Load(_selectedImage));
            transform.parent.GetComponent<LevelSelectScript>().UpdateDownloadButton(this);
        }
        else
        {
            _selected = false;
            _buttonTexture = (Texture)(Resources.Load(_unselectedImage));
            transform.parent.GetComponent<LevelSelectScript>().UpdateDownloadButton(this);
        }
    }

	void Update () 
    {
	
	}
}
