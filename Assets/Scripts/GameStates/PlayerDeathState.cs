using UnityEngine;
using System.Collections;

public class PlayerDeathState : GameState
{
    GameObject _gameOverPrefab = null;

    public override void Enter()
    {
        if (!_gameOverPrefab)
            _gameOverPrefab = (GameObject)(Instantiate(Resources.Load("GameOver"), new Vector3(0, -15, 0), Quaternion.identity));
        if (_stateName == "Default")
            _stateName = "PlayerDeath";

        //Pause all enemies, dim everything
        Time.timeScale = 0.0f;
        //Show Menu then listen to input
        _gameOverPrefab.transform.position = CameraScript.Instance().CameraPosition;
    }

    public override void Exit()
    {
        //Restart level
        Debug.Log("Exited Player Death");
        Time.timeScale = 1.0f;
        _gameOverPrefab.transform.position = new Vector2(0, -15);
    }

    public override void UpdateState()
    {
        //Listen to input, if continue, restart level, else back to main
        //Update gameOverPrefab
        _gameOverPrefab.GetComponent<GameOverScript>().UpdateMenu();
    }
}
