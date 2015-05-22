using UnityEngine;
using System.Collections;

public class DataSpawnerScript : MonoBehaviour 
{
    bool _canSpawn = true;
    [SerializeField] bool _enabled = true;
    [SerializeField] int _xDirection;
    [SerializeField] string _activatorType;

	void Start () 
    {
	
	}

    public void SpawnDataPacket()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (_canSpawn && _enabled)
        {
            if(_activatorType == collider.gameObject.tag)
            {
                SpawnDataPacket();
            }
        }
    }
}
