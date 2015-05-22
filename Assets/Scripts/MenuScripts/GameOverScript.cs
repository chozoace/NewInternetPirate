using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] GameObject _arrowPrefab;
    GameObject _arrowObject;
    //These are not the actual positions but rather the offset
    //relative to the camera position
    Vector3 _retryPosition = new Vector3(-2.2f, 0, 0);
    Vector3 _quitPosition = new Vector3(-2.2f, -1.4f, 0);
    //TO DO: include prefabs for single digits

	void Start () 
    {
        _arrowObject = (GameObject)(Instantiate(_arrowPrefab, _retryPosition, Quaternion.identity));
        SetupMenu();
    }

    public void SetupMenu()
    {
        Vector3 cameraPosition = CameraScript.Instance().CameraPosition;
        _arrowObject.transform.position = cameraPosition + _retryPosition;
    }
	
	public void UpdateMenu()
    {
        Vector3 cameraPosition = CameraScript.Instance().CameraPosition;
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            if (_arrowObject.transform.position == cameraPosition + _retryPosition)
                _arrowObject.transform.position = cameraPosition + _quitPosition;
            else
                _arrowObject.transform.position = cameraPosition + _retryPosition;

        }
        if(Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (_arrowObject.transform.position == cameraPosition + _retryPosition)
            {
                //retry
                //Including the below line will cause the player not to shoot
                //GameController.Instance().ChangeGameState(GameState._gameplayState);
                GameController.Instance().RestartLevel();
            }
            else
            {
                //quit
                //Go to main menu
                GameController.Instance().CurrentGameState.Exit();
                EnemyGun._bulletList.Clear();
                Turret._bulletList.Clear();
                ObjectFactory._enemyList.Clear();
                Application.LoadLevel("MainMenuScene");
            }
        }
    }
}
