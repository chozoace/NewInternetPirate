using UnityEngine;
using System.Collections;

public class PauseState : GameState
{

    public override void Enter()
    {
        if (_stateName == "Default")
            _stateName = "Pause";

        Time.timeScale = 0.0f;

    }

    public override void Exit()
    {
        Time.timeScale = 1.0f;
    }

    public override void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameController.Instance().ChangeGameState(GameState._gameplayState);
        }
    }
}
