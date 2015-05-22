using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyGun : MonoBehaviour 
{
    protected GameObject _enemyRef;

    protected bool _canShoot = false;
    protected float _fireRate;
    protected float _bulletSpeed;
    protected int _damage;
    protected string _gunName = "Default gun";
    public string GunName { get { return _gunName; } }
    //Static list so all enemies share the same bullets
    public static List<GameObject> _bulletList = new List<GameObject>();

    protected virtual void Start() { }

    public virtual void AssignReference(GameObject enemyRef, float fireRate, float bulletSpeed, int damage)
    {
        _enemyRef = enemyRef;
        _fireRate = fireRate;
        _bulletSpeed = bulletSpeed;
        _damage = damage;
    }

    public virtual void Shoot() { }
    protected void Reload() { _canShoot = true; }
    public virtual void UpdateShooting() 
    {
        if (_canShoot)
        {
            Shoot();
            _canShoot = false;
            Invoke("Reload", _fireRate);
        }
    }
}