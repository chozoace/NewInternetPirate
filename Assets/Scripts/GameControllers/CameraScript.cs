using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{
    static CameraScript _instance = null;
    [SerializeField] float _cameraMoveSpeed;
    [SerializeField] DataBarScript _camerasDataBar;
    public DataBarScript GetDataBar { get { return _camerasDataBar; } }
    public float CameraMoveSpeed { get { return _cameraMoveSpeed; } set { _cameraMoveSpeed = value; } }
    public Vector2 CameraPosition { get { return new Vector2(transform.position.x, transform.position.y); } }

    public static CameraScript Instance()
    {
        if(_instance)
        {
            return _instance;
        }
        else
        {
            return null;
        }
    }

    public void StartCameraMovement()
    {
        Vector2 v = rigidbody2D.velocity;
        v.y = _cameraMoveSpeed;
        rigidbody2D.velocity = v;

        Component[] childrensComponents = GetComponentsInChildren<CameraWallScript>();
        foreach(CameraWallScript wallScript in childrensComponents)
        {
            wallScript.Initialize();
        }
    }

    public void PauseCameraMovement()
    {

    }

    public void ResumeCameraMovement()
    {

    }

	void Start () 
    {
	    if(!_instance)
        {
            _instance = this;
        }
	}
	
	void Update () 
    {

	}
}
