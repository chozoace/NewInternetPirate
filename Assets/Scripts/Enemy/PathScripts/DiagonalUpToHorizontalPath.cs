using UnityEngine;
using System.Collections;

public class DiagonalUpToHorizontalPath : EnemyPath
{
    float _speedModifier = .1f;
    Vector2 _currentSpeed;
    float _maxXSpeed = 4;
    //Fly to this point then stop y movement
    float _yPosLimit;

    void Start()
    {
        _pathName = "DiagonalUpToHorizontalPath";
        _speedModifier = (_moveSpeed * .1f) * -1;
    }

    public override void StartPath()
    {
        _yPosLimit = _enemyRef.transform.position.y + 7;
        if (_enemyRef)
        {
            Vector2 speedVector;
            speedVector = _enemyRef.rigidbody2D.velocity;
            speedVector.x = _moveSpeed - 2f;
            speedVector.y = (_moveSpeed - 6) * -1;
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

    void StopVerticalMovement()
    {
        Vector2 speedVector;
        speedVector = _enemyRef.rigidbody2D.velocity;
        speedVector.y = 2f;
        speedVector.x = _moveSpeed - 4f;
        if (_startingXDirection == -1)
        {
            speedVector.x *= -1;
        }
        //speedVector.y = CameraScript.Instance().CameraMoveSpeed;
        _enemyRef.rigidbody2D.velocity = speedVector;
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
            if (_enemyRef.transform.position.y >= _yPosLimit)
            {
                StopVerticalMovement();
            }
        }
    }
}