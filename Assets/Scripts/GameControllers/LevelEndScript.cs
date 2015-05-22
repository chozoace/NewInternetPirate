using UnityEngine;
using System.Collections;

public class LevelEndScript : MonoBehaviour 
{
    [SerializeField] bool enabled = true;

	void Start () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (enabled)
        {
            if (other.tag == "Player")
            {
                //Should Restart Game
                GameController.Instance().ChangeGameState(GameState._levelEndState);
            }
        }
    }
	
	void Update () 
    {
	
	}
}
