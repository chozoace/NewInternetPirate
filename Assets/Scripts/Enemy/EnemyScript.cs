using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour 
{
    [SerializeField] protected int _maxHealth;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected int _damage;
    [SerializeField] protected float _fireRate;
    [SerializeField] protected float _bulletSpeed;
    protected bool _useBaseStats = true;
    protected int _health;
    protected EnemyPath _myPath;

    protected bool _exists;
    public bool Exists { get { return _exists; } }
    protected string _enemyName;
    public string EnemyName { get { return _enemyName; } }

    protected EnemyGun _myGun;

    protected void Awake() 
    {
        _health = _maxHealth;
        _enemyName = "Default";
        _exists = false;
	}

    public void AssignPath(string pathName, int xDirection, float moveSpeed)
    {
        _moveSpeed = moveSpeed;
        _myPath = gameObject.AddComponent(pathName) as EnemyPath;
        _myPath.AssignReference(this.gameObject, _moveSpeed, xDirection);
        _myPath.StartPath();
        _exists = true;
    }

    public void AssignGun(string gunName, float fireRate, float bulletSpeed, int damage, bool useBaseStats)
    {
        _useBaseStats = useBaseStats;
        _myGun = gameObject.AddComponent(gunName) as EnemyGun;

        if(!_useBaseStats)
            _myGun.AssignReference(this.gameObject, fireRate, bulletSpeed, damage);
        else if(_useBaseStats)
            _myGun.AssignReference(this.gameObject, _fireRate, _bulletSpeed, _damage);
    }
    /// <summary>
    /// Activates select inactive enemy and repositions it
    /// </summary>
    /// <param name="newPosition"></param>
    public virtual void ReactivateEnemy(Vector2 newPosition)
    {
        this.gameObject.layer = 10;
        _exists = true;
        renderer.enabled = true;
        transform.position = newPosition;
        _health = _maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        _health -= damage;
    }

    protected virtual void Death(bool deathViaBullet = true)
    {
        _exists = false;
        renderer.enabled = false;
        _myPath.EndPath();
        this.gameObject.layer = 14;
        if (deathViaBullet && GameController.Instance().CurrentGameState.StateName == "Gameplay")
        {
            Debug.Log("via bullet");
            GameController.Instance().KillScore = GameController.Instance().KillScore + 1;
        }
    }

	protected virtual void Update () 
    {
	    
	}

    void OnBecameInvisible()
    {
        if (_health > 0)
        {
            Death(false);
        }
    }
}
