using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour
{
    //Enemy to Spawn
    bool _canSpawn = true;
    [SerializeField] bool _enabled = true;
    [SerializeField] string _activatorType;
    [SerializeField] string _enemyType;
    [SerializeField] string _pathName;
    [SerializeField] int _xDirection;
    [SerializeField] float _moveSpeed;
    [SerializeField] string _gunName;
    [SerializeField] bool _useBaseStats = false;
    [SerializeField] float _fireRate;
    [SerializeField] float _bulletSpeed;
    [SerializeField] int _damage;

	void Start () 
    {
	    
	}
	
    public void SpawnEnemy()
    {
        if(_canSpawn)
        {
            //Sends spawn info to Object factory
            //Create x gameobject with y parameters at z position
            ObjectFactory.Instance().SpawnEnemy(transform.position, _enemyType, _pathName,
                _xDirection, _moveSpeed, _gunName, _fireRate, _bulletSpeed, _damage, _useBaseStats);
            _canSpawn = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(_canSpawn && _enabled)
        {
            if(_activatorType == collider.gameObject.tag)
            {
                SpawnEnemy();
            }
        }
    }

	void Update ()
    {
	
	}
}
