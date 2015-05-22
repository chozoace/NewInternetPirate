using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectFactory : MonoBehaviour 
{
    static ObjectFactory _instance;
    public static List<GameObject> _enemyList = new List<GameObject>();

    public static ObjectFactory Instance()
    {
        if(_instance)
        {
            return _instance;
        }
        else
        {
            throw new System.ArgumentException("Object Factory instance is NULL");
        }
    }

	void Start () 
    {
        _instance = this;
	}

    public void SpawnEnemy(Vector2 position, string enemyType, string pathName,
        int xDirection, float moveSpeed, string gunName, float fireRate, float bulletSpeed, int damage, bool useBaseStats)
    {
        GameObject enemyPrefab;
        EnemyScript enemyScript;
        bool createObject = true;

        if(_enemyList.Count > 0)
        {
            foreach(GameObject theEnemyPrefab in _enemyList)
            {
                enemyScript = theEnemyPrefab.GetComponent<EnemyScript>();
                if(!enemyScript.Exists)
                {
                    createObject = false;
                    //reuse enemy
                    enemyScript.ReactivateEnemy(position);
                    enemyScript.AssignPath(pathName, xDirection, moveSpeed);
                    enemyScript.AssignGun(gunName, fireRate, bulletSpeed, damage, useBaseStats);
                    break;
                }
            }
        }
        if(createObject)
        {
            //Create new enemy and add it to list
            enemyPrefab = (GameObject)(Instantiate(Resources.Load(enemyType), position, Quaternion.identity));
            enemyScript = enemyPrefab.GetComponent<EnemyScript>();
            enemyScript.AssignPath(pathName, xDirection, moveSpeed);
            enemyScript.AssignGun(gunName, fireRate, bulletSpeed, damage, useBaseStats);
            _enemyList.Add(enemyPrefab);
        }
    }
	
	void Update () 
    {
	    
	}
}
