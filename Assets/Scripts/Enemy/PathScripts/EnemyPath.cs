using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPath : MonoBehaviour
{
    public static List<EnemyPath> _pathList = new List<EnemyPath>();
    protected GameObject _enemyRef;
    protected float _moveSpeed;
    protected bool _startedPath = false;
    protected int _startingXDirection;

    protected string _pathName = "DefaultPath";
    public string PathName { get { return _pathName; } }

	void Start () 
    {
        _pathList.Add(new StraightPath());
	}
    /// <summary>
    /// Begins Path movement for referenced gameobject
    /// </summary>
    public virtual void StartPath() { }
    /// <summary>
    /// Ends path movement for referenced gameobject
    /// </summary>
    public virtual void EndPath()
    {
        _enemyRef.rigidbody2D.velocity = Vector2.zero;
        _startedPath = false;
    }
    /// <summary>
    /// Links an enemy game object with a given path
    /// </summary>
    /// <param name="enemyRef">Enemy to link to path</param>
    /// <param name="moveSpeed">Travel speed</param>
    /// <param name="startingXDirection">1 is to start flying left, -1 is to start flying right</param>
    public virtual void AssignReference(GameObject enemyRef, float moveSpeed, int startingXDirection)
    {
        _enemyRef = enemyRef;
        _moveSpeed = moveSpeed;
        _startingXDirection = startingXDirection;
    }
    /// <summary>
    /// Updates gameobject to follow path
    /// </summary>
    public virtual void UpdatePath() { }
}