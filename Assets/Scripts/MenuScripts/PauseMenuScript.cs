using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour 
{
    GameObject _resumeButton = null;
    GameObject _quitButton = null;
    Vector2 _resumeButtonPosition = new Vector2(.7f, 3.6f);
    Vector2 _quitButtonPosition = new Vector2(3.3f, 3.6f);

	void Start () 
    {
	    if(!_resumeButton)
        {
            _resumeButton = (GameObject)(Instantiate(Resources.Load("ResumeButton"), new Vector3(0, -15, 0), Quaternion.identity));
            _resumeButton.GetComponent<ResumeButtonScript>().XPos =  _resumeButtonPosition.x;
            _resumeButton.GetComponent<ResumeButtonScript>().YPos =  _resumeButtonPosition.y;
            _quitButton = (GameObject)(Instantiate(Resources.Load("QuitPauseButton"), new Vector3(0, -15, 0), Quaternion.identity));
            _quitButton.GetComponent<QuitPauseButtonScript>().XPos = _quitButtonPosition.x;
            _quitButton.GetComponent<QuitPauseButtonScript>().YPos = _quitButtonPosition.y;
        }
	}

    public void EnterPause()
    {
        if (_resumeButton)
        {
            _resumeButton.GetComponent<ResumeButtonScript>().SetupButton();
            _quitButton.GetComponent<QuitPauseButtonScript>().SetupButton();
        }
    }

    public void ExitPause()
    {
        if(_resumeButton)
        {
            _resumeButton.GetComponent<ResumeButtonScript>().RemoveButton();
            _quitButton.GetComponent<QuitPauseButtonScript>().RemoveButton();
        }
    }
}
