using UnityEngine;
using System.Collections;

public class RetryButtonScipt : ButtonScript 
{
    float _nativeWidth = 480;
    float _nativeHeight = 640;
    float _xPos = 0;
    float _yPos = 0;
    public float XPos { get { return _xPos; } set { _xPos = value; } }
    public float YPos { get { return _yPos; } set { _yPos = value; } }

	void Start () 
    {
        _buttonTexture = (Texture)(Resources.Load("TempSprites/RetryButton"));
	}

    public void SetupButton()
    {
        _beenPressed = false;
    }

    protected override void OnGUI()
    {
        if (!_beenPressed)
        {
            float rx = Screen.width / _nativeWidth;
            float ry = Screen.height / _nativeHeight;
            GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1));

            //Does not spawn in the same place depending on Resolution
            if (GUI.Button(new Rect(_xPos * 100, _yPos * 100, 80, 32), _buttonTexture, GUIStyle.none))
            {
                GameController.Instance().RestartLevel();
            }
        }
    }

    public void RemoveButton()
    {
        _beenPressed = true;
    }
}
