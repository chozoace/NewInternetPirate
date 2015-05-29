using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour
{
    GameObject _retryButton = null;
    GameObject _quitButton = null;
    Vector2 _retryPosition = new Vector2(.7f, 3.6f);
    Vector2 _quitPosition = new Vector2(3.3f, 3.6f);

	void Start () 
    {
        if(!_retryButton)
        {
            _retryButton = (GameObject)(Instantiate(Resources.Load("RetryButton"), new Vector3(0, -15, 0), Quaternion.identity));
            _retryButton.GetComponent<RetryButtonScipt>().XPos = _retryPosition.x;
            _retryButton.GetComponent<RetryButtonScipt>().YPos = _retryPosition.y;
            _quitButton = (GameObject)(Instantiate(Resources.Load("QuitPauseButton"), new Vector3(0, -15, 0), Quaternion.identity));
            _quitButton.GetComponent<QuitPauseButtonScript>().XPos = _quitPosition.x;
            _quitButton.GetComponent<QuitPauseButtonScript>().YPos = _quitPosition.y;
        }
    }

    public void EnterPlayerDeath()
    {
        if (_retryButton)
        {
            _retryButton.GetComponent<RetryButtonScipt>().SetupButton();
            _quitButton.GetComponent<QuitPauseButtonScript>().SetupButton();
        }
    }

    public void ExitPlayerDeath()
    {
        if(_retryButton)
        {
            _retryButton.GetComponent<RetryButtonScipt>().RemoveButton();
            _quitButton.GetComponent<QuitPauseButtonScript>().RemoveButton();
        }
    }
}
