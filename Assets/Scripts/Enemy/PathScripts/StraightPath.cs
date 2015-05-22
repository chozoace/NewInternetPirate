using UnityEngine;
using System.Collections;

public class StraightPath : EnemyPath
{

    void Start()
    {
        _pathName = "StraightPath";
    }

    public override void StartPath()
    {
        if (_enemyRef)
        {
            Vector2 speedVector;
            speedVector = _enemyRef.rigidbody2D.velocity;
            speedVector.y = _moveSpeed;
            _enemyRef.rigidbody2D.velocity = speedVector;
            _startedPath = true;
            //Debug.Log("MoveSpeed: " + _moveSpeed + " Velocity: " + _enemyRef.rigidbody2D.velocity);
        }
        else
        {
            throw new System.ArgumentException("_enemyRef cannot be NULL");
        }
    }

    public override void EndPath()
    {
        base.EndPath();
    }

    public override void UpdatePath()
    {
        if (_startedPath)
        {
            //Debug.Log(_enemyRef.rigidbody2D.velocity);
        }
    }
}