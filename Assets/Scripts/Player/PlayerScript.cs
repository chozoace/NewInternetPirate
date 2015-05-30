using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
    static PlayerScript _instance = null;
    [SerializeField] KeyCode _leftKey;
    [SerializeField] KeyCode _rightKey;
    [SerializeField] KeyCode _upKey;
    [SerializeField] KeyCode _downKey;
    [SerializeField] KeyCode _turretShootKey;
    [SerializeField] bool _freeRoam = false;
    [SerializeField] HPBarScript _theHpBar;
    DataBarScript _theDataBar;
    public bool IsFreeRoam { get { return _freeRoam; } }

    private bool _movingRight = false;
    private bool _movingLeft = false;
    private bool _movingUp = false;
    private bool _movingDown = false;

    [SerializeField] float _moveSpeed;
    [SerializeField] float _upMoveSpeed;
    [SerializeField] float _downMoveSpeed;
    [SerializeField] float _xMoveSpeed;
    [SerializeField] int _maxHealth;
    private int _health;
    [SerializeField] float _hitstunTime;
    enum HitStunState { Hitstun, NoHitstun };
    HitStunState _currentStunState;

    int _score = 0;
    public int Score { get { return _score;} }

    Turret _myTurret;
    bool _shooting = false;
    bool _canReload = true;

    public static PlayerScript Instance()
    {
        if(_instance)
        {
            return _instance;
        }
        else
        {
            throw new System.ArgumentException("Player instance is NULL");
        }
    }

	void Start() 
    {
	    if(!_instance)
        {
            _instance = this;
        }
        if(!_freeRoam)
        {
            Vector2 v = rigidbody2D.velocity;
            v.y = _moveSpeed;
            rigidbody2D.velocity = v;
            CameraScript.Instance().StartCameraMovement();
        }
        _myTurret = Turret.Instance();
        _theHpBar.MaxHealth = _maxHealth;
        _health = _maxHealth;
        _theDataBar = CameraScript.Instance().GetDataBar;
        _currentStunState = HitStunState.NoHitstun;
	}

    public void Initialize()
    {

    }
	
    void getKeysDown()
    {
        if(Input.GetKeyDown(_leftKey))
        {
            _movingLeft = true;
        }
        if(Input.GetKeyDown(_rightKey))
        {
            _movingRight = true;
        }
        if(Input.GetKeyDown(_downKey))
        {
            _movingDown = true;
        }
        if(Input.GetKeyDown(_upKey))
        {
            _movingUp = true;
        }
        if(Input.GetKeyDown(_turretShootKey))
        {
            //Shoot bullet from center of player ship
            Vector2 v = transform.position;
            v.x += .25f;
            
            //_myTurret.Shoot(v);
            if (_myTurret.CanShoot)
                _shooting = true;
        }
        if(Input.GetMouseButtonDown(0))
        {
            if(_myTurret.CanShoot)
                _shooting = true;
        }

    }

    void getKeysUp()
    {
        if (Input.GetKeyUp(_leftKey))
        {
            _movingLeft = false;
        }
        if (Input.GetKeyUp(_rightKey))
        {
            _movingRight = false;
        }
        if (Input.GetKeyUp(_downKey))
        {
            _movingDown = false;
        }
        if (Input.GetKeyUp(_upKey))
        {
            _movingUp = false;
        }
        if (Input.GetKeyUp(_turretShootKey))
        {
            _shooting = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _shooting = false;
        }
    }

    void UpdateMovement()
    {
        //X Movement
        if(_movingLeft && _movingRight)
        {
            Vector2 v = rigidbody2D.velocity;
            v.x = 0;
            rigidbody2D.velocity = v;
        }
        else if(_movingLeft && !_movingRight)
        {
            if (_freeRoam)
            {
                Vector2 v = rigidbody2D.velocity;
                v.x = -_moveSpeed;
                rigidbody2D.velocity = v;
            }
            else
            {
                Vector2 v = rigidbody2D.velocity;
                v.x = -_xMoveSpeed;
                rigidbody2D.velocity = v;
            }
        }
        else if(!_movingLeft && _movingRight)
        {
            if (_freeRoam)
            {
                Vector2 v = rigidbody2D.velocity;
                v.x = _moveSpeed;
                rigidbody2D.velocity = v;
            }
            else
            {
                Vector2 v = rigidbody2D.velocity;
                v.x = _xMoveSpeed;
                rigidbody2D.velocity = v;
            }
        }
        else if(!_movingLeft && !_movingRight)
        {
            Vector2 v = rigidbody2D.velocity;
            v.x = 0;
            rigidbody2D.velocity = v;
        }

        //Y Movement
        if(_movingUp && _movingDown)
        {
            if (_freeRoam)
            {
                Vector2 v = rigidbody2D.velocity;
                v.y = 0;
                rigidbody2D.velocity = v;
            }
            else
            {
                Vector2 v = rigidbody2D.velocity;
                v.y = _moveSpeed;
                rigidbody2D.velocity = v;
            }
        }
        else if(_movingUp && !_movingDown)
        {
            if (_freeRoam)
            {
                Vector2 v = rigidbody2D.velocity;
                v.y = _moveSpeed;
                rigidbody2D.velocity = v;
            }
            else
            {
                Vector2 v = rigidbody2D.velocity;
                v.y = _upMoveSpeed;
                rigidbody2D.velocity = v;
            }
        }
        else if(!_movingUp && _movingDown)
        {
            if (_freeRoam)
            {
                Vector2 v = rigidbody2D.velocity;
                v.y = -_moveSpeed;
                rigidbody2D.velocity = v;
            }
            else
            {
                Vector2 v = rigidbody2D.velocity;
                v.y = -_downMoveSpeed;
                rigidbody2D.velocity = v;
            }
        }
        else if(!_movingUp && !_movingDown)
        {
            if (_freeRoam)
            {
                Vector2 v = rigidbody2D.velocity;
                v.y = 0;
                rigidbody2D.velocity = v;
            }
            else
            {
                Vector2 v = rigidbody2D.velocity;
                v.y = _moveSpeed;
                rigidbody2D.velocity = v;
            }
        }
    }

    /// <summary>
    /// Resets all of player movement stats. Stops player completely.
    /// </summary>
    public void PauseControls()
    {
        _movingDown = false;
        _movingLeft = false;
        _movingUp = false;
        _movingRight = false;
        _shooting = false;

        Vector2 v = new Vector2(0, _moveSpeed);
        rigidbody2D.velocity = v;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            if (_currentStunState == HitStunState.NoHitstun)
            {
                InvokeRepeating("FlickerRenderer", .2f, .07f);
                _health -= damage;
                _theHpBar.ModifyHealthBar(_health);
                _currentStunState = HitStunState.Hitstun;
                Invoke("FinishHitstun", _hitstunTime);
            }
        }
    }

    void FlickerRenderer()
    {
        if (this.renderer.enabled == false)
            this.renderer.enabled = true;
        else
            this.renderer.enabled = false;
    }

    void FinishHitstun()
    {
        _currentStunState = HitStunState.NoHitstun;
        this.renderer.enabled = true;
        CancelInvoke("FlickerRenderer");
    }

    public void IncreaseScore(int scoreValue)
    {
        if (_score < 100)
        {
            _score += scoreValue;
            _theDataBar.ModifyDataValue(scoreValue);
        }
    }

    void Death()
    {
        //Death Anim plays
        GameController.Instance().ChangeGameState(GameState._playerDeathState);
    }

	void Update ()
    {
        if (GameController.Instance().CurrentGameState.StateName == "Gameplay")
        {
            getKeysDown();
            getKeysUp();
            UpdateMovement();
            if(_shooting)
                _myTurret.UpdateShooting(this.gameObject.transform.position);

            if(_health <= 0)
            {
                Death();
            }
        }
	}
}
