using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
    GameState _currentGameState = null;
    public GameState CurrentGameState { get { return _currentGameState; } }
    GameState _lastState;
    static GameController _instance = null;
    int _killScore = 0;
    public int KillScore { get { return _killScore; } set { _killScore = value; } }

    public static GameController Instance()
    {
        if(_instance)
        {
            return _instance;
        }
        else
        {
            throw new System.ArgumentException("Game Controller instance is null");
        }
    }

	void Start () 
    {
        Screen.SetResolution(480, 640, false);
        _currentGameState = GameState._gameplayState;
        _currentGameState.Enter();
        _lastState = _currentGameState;

        if(!_instance)
        {
            _instance = this;
        }
	}
	
    public void ChangeGameState(GameState newState)
    {
        _currentGameState.Exit();
        _lastState = _currentGameState;
        _currentGameState = newState;
        _currentGameState.Enter();
    }
    

    public void RestartLevel()
    {
        _killScore = 0;
        EnemyGun._bulletList.Clear();
        Turret._bulletList.Clear();
        ObjectFactory._enemyList.Clear();
        Application.LoadLevel(Application.loadedLevel);
    }

	void Update () 
    {
        _currentGameState.UpdateState();
	}
}
