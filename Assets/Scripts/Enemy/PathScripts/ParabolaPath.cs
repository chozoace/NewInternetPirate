using UnityEngine;
using System.Collections;

public class ParabolaPath : EnemyPath
{
    float _speedModifier = .08f;
    Vector2 _currentSpeed;
    float _maxXSpeed = 4;

    void Start()
    {
        _pathName = "ParabolaPath";
        _speedModifier = (_moveSpeed * .08f) * -1;
    }

    public override void StartPath()
    {
        if (_enemyRef)
        {
            Vector2 speedVector;
            speedVector = _enemyRef.rigidbody2D.velocity;
            speedVector.x = _moveSpeed - 2;
            speedVector.y = _moveSpeed - 3;
            if (_startingXDirection == -1)
            {
                speedVector.x *= -1;
            }
            _enemyRef.rigidbody2D.velocity = speedVector;
            _startedPath = true;
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
            //Decrement speed
            _currentSpeed = _enemyRef.rigidbody2D.velocity;
            if (_currentSpeed.y < 4)
                _currentSpeed.y += _speedModifier;
            _enemyRef.rigidbody2D.velocity = _currentSpeed;
        }
    }
}