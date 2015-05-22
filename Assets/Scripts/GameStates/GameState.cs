using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour 
{
    public static GameplayState _gameplayState = new GameplayState();
    public static LevelEndState _levelEndState = new LevelEndState();
    public static PauseState _pauseState = new PauseState();
    public static PlayerDeathState _playerDeathState = new PlayerDeathState();

    protected string _stateName = "Default";
    public virtual string StateName { get { return _stateName; } }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void UpdateState() { }
}
