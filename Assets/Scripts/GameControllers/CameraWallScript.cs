using UnityEngine;
using System.Collections;

public class CameraWallScript : MonoBehaviour 
{
    [SerializeField] float _moveSpeed;	

	void Start () 
    {

	}
    /// <summary>
    /// Activates movement if free roam is off
    /// </summary>
    public void Initialize()
    {
        if (!PlayerScript.Instance().IsFreeRoam)
        {
            _moveSpeed = CameraScript.Instance().CameraMoveSpeed;
            Vector2 v = rigidbody2D.velocity;
            v.y = _moveSpeed;
            rigidbody2D.velocity = v;
        }
    }

    public void PauseMovement()
    {

    }

    public void ResumeMovement()
    {

    }
	
	void Update () 
    {
	
	}
}
