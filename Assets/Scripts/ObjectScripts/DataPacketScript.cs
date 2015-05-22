using UnityEngine;
using System.Collections;

public class DataPacketScript : MonoBehaviour 
{
    int _scoreValue = 10;

	void Start ()
    {
	    //Needs to be able to move
	}
	
	void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerScript.Instance().IncreaseScore(_scoreValue);
        Destroy(this.gameObject);
    }
}
