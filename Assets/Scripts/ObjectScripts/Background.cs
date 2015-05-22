using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour 
{

	void Start () 
    {
	    
	}
	
    void OnBecameInvisible()
    {
        Vector2 newPosition = transform.position;
        newPosition.y += 24.0f;
        this.transform.position = newPosition;
    }

	void Update () 
    {
        
	}
}
