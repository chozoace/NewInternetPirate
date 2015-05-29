using UnityEngine;
using System.Collections;

public class LevelEndMenuScript : MonoBehaviour 
{
    [SerializeField] bool _isFailMenu = false;
    GameObject _retryButton = null;
    GameObject _levelSelectButton = null;
    GameObject _quitButton = null;
    Vector2 _retryPosition = new Vector2(.7f, 3.6f);
    Vector2 _quitPosition = new Vector2(3.3f, 3.6f);

	void Start () 
    {
	    if(!_retryButton)
        {
            _levelSelectButton = (GameObject)(Instantiate(Resources.Load("TorrentListButton"), new Vector3(0, -15, 0), Quaternion.identity));
            _levelSelectButton.GetComponent<LevelSelectButtonScript>().XPos = _retryPosition.x;
            _levelSelectButton.GetComponent<LevelSelectButtonScript>().YPos = _retryPosition.y;
            _retryButton = (GameObject)(Instantiate(Resources.Load("RetryButton"), new Vector3(0, -15, 0), Quaternion.identity));
            _retryButton.GetComponent<RetryButtonScipt>().XPos = _retryPosition.x;
            _retryButton.GetComponent<RetryButtonScipt>().YPos = _retryPosition.y;
            _quitButton = (GameObject)(Instantiate(Resources.Load("QuitPauseButton"), new Vector3(0, -15, 0), Quaternion.identity));
            _quitButton.GetComponent<QuitPauseButtonScript>().XPos = _quitPosition.x;
            _quitButton.GetComponent<QuitPauseButtonScript>().YPos = _quitPosition.y;
        }
        
	}

    public void EnterMenu()
    {
        if(_retryButton)
        {
            if(_isFailMenu)
                _retryButton.GetComponent<RetryButtonScipt>().SetupButton();
            else
                _levelSelectButton.GetComponent<LevelSelectButtonScript>().SetupButton();
            _quitButton.GetComponent<QuitPauseButtonScript>().SetupButton();
        }
    }

    public void ExitMenu()
    {
        if(_retryButton)
        {
            if(_isFailMenu)
                _retryButton.GetComponent<RetryButtonScipt>().RemoveButton();
            else
                _levelSelectButton.GetComponent<LevelSelectButtonScript>().RemoveButton();
            _quitButton.GetComponent<QuitPauseButtonScript>().RemoveButton();
        }
    }

    void OnGUI()
    {
        GUI.color = Color.black;
        string killScore = GameController.Instance().KillScore.ToString();
        GUI.Label(new Rect(225, 320, 100, 20), killScore);
    }
}
