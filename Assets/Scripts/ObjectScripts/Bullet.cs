using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
    float _speed;
    int _damage;

    private bool _exists;
    public bool Exists { get { return _exists; } }
    private bool _playerBullet = false;
    public bool PlayerBullet { get { return _playerBullet; } set { _playerBullet = value; } }
    
	void Awake() 
    {
        _exists = true;
	}
    /// <summary>
    /// Sets initial bullet stats
    /// </summary>
    public void InitializeStats(int damage, Vector2 speedVector)
    {
        _damage = damage;
        rigidbody2D.velocity = speedVector;
    }

    /// <summary>
    /// Repositions bullets with new stats
    /// </summary>
    public void ReuseBullet(Vector2 newPosition, int damage, Vector2 speedVector)
    {
        _exists = true;
        renderer.enabled = true;
        transform.position = newPosition;
        this.gameObject.layer = 12;
        InitializeStats(damage, speedVector);
    }
	
	void Update () 
    {
	    if(_exists && GameController.Instance().CurrentGameState.StateName == "Gameplay")
        {

        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(_exists)
        {
            if(_playerBullet && collider.gameObject.tag != "Player")
            {
                if(collider.gameObject.tag == "Enemy")
                {
                    collider.GetComponent<MalwareScript>().TakeDamage(_damage);
                }
                DisableBullet();
            }
            else if(!_playerBullet && collider.gameObject.tag != "Enemy")
            {
                if(collider.gameObject.tag == "Player")
                {
                    PlayerScript.Instance().TakeDamage(_damage);
                }
                DisableBullet();
            }
        }
    }

    /// <summary>
    /// Call this to turn off bullets for reuse
    /// </summary>
    void DisableBullet()
    {
        _exists = false;
        renderer.enabled = false;
        rigidbody2D.velocity = Vector2.zero;
        this.gameObject.layer = 14;
    }

    void OnBecameInvisible()
    {
        DisableBullet();
    }
}
