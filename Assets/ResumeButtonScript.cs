using UnityEngine;
using System.Collections;

public class ResumeButtonScript : ButtonScript
{
    float _xPos = 0;
    float _yPos = 0;
    public float XPos { get { return _xPos; } set { _xPos = value; } }
    public float YPos { get { return _yPos; } set { _yPos = value; } }

	void Start () 
    {
        _buttonTexture = (Texture)(Resources.LoadAssetAtPath("Assets/Resources/TempSprites/ResumeButton.png", typeof(Texture)));
	}

    public void SetupButton()
    {
        _beenPressed = false;
    }

    protected override void OnGUI()
    {
        if (!_beenPressed)
        {
            //Does not spawn in the same place depending on Resolution
            if (GUI.Button(new Rect(_xPos * 100, _yPos * 100, 80, 32), _buttonTexture, GUIStyle.none))
            {
                GameController.Instance().ChangeGameState(GameState._gameplayState);
                RemoveButton();
            }
        }
    }

    public void RemoveButton()
    {
        _beenPressed = true;
    }
	
	void Update () 
    {
	
	}
}
