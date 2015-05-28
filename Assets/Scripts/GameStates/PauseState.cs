using UnityEngine;
using System.Collections;

public class PauseState : GameState
{
    GameObject _pauseMenu = null;

    public override void Enter()
    {
        if(!_pauseMenu)
        {
            _pauseMenu = (GameObject)(Instantiate(Resources.Load("PauseMenu"), new Vector3(0, -15, 0), Quaternion.identity));
        }
        if (_stateName == "Default")
            _stateName = "Pause";

        Time.timeScale = 0.0f;
        //Create Pause Menu
        _pauseMenu.transform.position = CameraScript.Instance().CameraPosition;
        _pauseMenu.GetComponent<PauseMenuScript>().EnterPause();
    }

    public override void Exit()
    {
        //Remove PauseMenu
        _pauseMenu.transform.position = new Vector2(0, -15);
        _pauseMenu.GetComponent<PauseMenuScript>().ExitPause();
        Time.timeScale = 1.0f;
    }

    public override void UpdateState()
    {

    }
}
