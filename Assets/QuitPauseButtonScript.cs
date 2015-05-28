using UnityEngine;
using System.Collections;

public class QuitPauseButtonScript : ButtonScript
{
    float _xPos = 0;
    float _yPos = 0;
    public float XPos { get { return _xPos; } set { _xPos = value; } }
    public float YPos { get { return _yPos; } set { _yPos = value; } }

	void Start ()
    {
        _buttonTexture = (Texture)(Resources.LoadAssetAtPath("Assets/Resources/TempSprites/QuitButton 1.png", typeof(Texture)));
	}

    public void SetupButton()
    {
        _beenPressed = false;
    }

    protected override void OnGUI()
    {
        if(!_beenPressed)
        {
            if (GUI.Button(new Rect(_xPos * 100, _yPos * 100, 80, 32), _buttonTexture, GUIStyle.none))
            {
                GameController.Instance().CurrentGameState.Exit();
                EnemyGun._bulletList.Clear();
                Turret._bulletList.Clear();
                ObjectFactory._enemyList.Clear();
                Application.LoadLevel("MainMenuScene");
            }
        }
    }

    public void RemoveButton()
    {
        _beenPressed = true;
    }
}
