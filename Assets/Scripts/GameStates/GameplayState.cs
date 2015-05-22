using UnityEngine;
using System.Collections;

public class GameplayState : GameState
{
    GameObject _player = null;

	public override void Enter()
    {
        if (_stateName == "Default")
            _stateName = "Gameplay";
        
        if(!_player)
        {
            _player = (GameObject)Instantiate(Resources.Load("Player"), new Vector2(-0.3f, -2.0f), Quaternion.identity);
        }
        Time.timeScale = 1.0f;
    }

    public override void Exit()
    {
        PlayerScript.Instance().PauseControls();
    }

    public override void UpdateState()
    {
        //Debug.Log(Time.timeScale);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameController.Instance().ChangeGameState(GameState._pauseState);
        }
    }
}
