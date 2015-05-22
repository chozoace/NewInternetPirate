using UnityEngine;
using System.Collections;

public class CArcPath : EnemyPath
{
    float _speedModifier = .1f;
    Vector2 _currentSpeed;
    float _maxXSpeed = 4;

    void Start()
    {
        _pathName = "CArcPath";
        _speedModifier = (_moveSpeed * .1f) * -1;
    }

    public override void StartPath()
    {
        if (_enemyRef)
        {
            Vector2 speedVector;
            speedVector = _enemyRef.rigidbody2D.velocity;
            speedVector.x = _moveSpeed - 4;
            speedVector.y = _moveSpeed - 3;
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
            //Increment/Decrement speeds
            _currentSpeed = _enemyRef.rigidbody2D.velocity;
            if (_currentSpeed.x <= 5 && _currentSpeed.x >= -5)
            {
                if (_startingXDirection == -1)
                    _currentSpeed.x -= _speedModifier;
                else
                    _currentSpeed.x += _speedModifier;
            }
            _enemyRef.rigidbody2D.velocity = _currentSpeed;
        }
    }
}