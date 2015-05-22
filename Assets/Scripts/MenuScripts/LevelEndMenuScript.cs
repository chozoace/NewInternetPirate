using UnityEngine;
using System.Collections;

public class LevelEndMenuScript : MonoBehaviour 
{
    [SerializeField] bool _isFailMenu = false;
	void Start () 
    {
	
	}
	
    public void SetupMenu()
    {

    }

	public void UpdateMenu()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            //Restart or load next level
            GameController.Instance().RestartLevel();
        }
    }
}
