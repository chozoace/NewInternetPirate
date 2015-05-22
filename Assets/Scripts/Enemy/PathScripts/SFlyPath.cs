using UnityEngine;
using System.Collections;

public class SFlyPath : EnemyPath
{
    float _speedModifier = .3f;
    Vector2 _currentSpeed;
    float _maxXSpeed = 4;

    void Start()
    {
        _pathName = "SFlyPath";
        _speedModifier = (_moveSpeed * .3f) * -1;
    }

    public override void StartPath()
    {
        if (_enemyRef)
        {
            Vector2 speedVector;
            speedVector = _enemyRef.rigidbody2D.velocity;
            speedVector.x = _moveSpeed;
            speedVector.y = _moveSpeed;
            if (_startingXDirection == -1)
            {
                speedVector.x *= -1;
                _speedModifier *= -1;
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
            _currentSpeed.x -= _speedModifier;
            _enemyRef.rigidbody2D.velocity = _currentSpeed;
            //Change directions
            if (_currentSpeed.x <= -10 || _currentSpeed.x >= 10)
            {
                _speedModifier *= -1;
            }
        }
    }
}