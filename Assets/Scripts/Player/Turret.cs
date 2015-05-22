using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : MonoBehaviour 
{
    [SerializeField] float _fireRate;
    public float FireRate { get { return _fireRate; } }
    [SerializeField] float _bulletSpeed;
    [SerializeField] int _damage;
    public static List<GameObject> _bulletList = new List<GameObject>();
    static Turret _instance = null;
    bool _canShoot = true;
    public bool CanShoot { get { return _canShoot; } set { _canShoot = value; } }

    public static Turret Instance()
    {
        if (_instance)
            return _instance;
        else
        {
            return null;
        }
    }

	void Awake() 
    {
        _instance = this;
	}

    /// <summary>
    /// Creates or re-uses bullet objects at a given position
    /// </summary>
    public virtual void Shoot(Vector2 bulletPosition)
    {
        //To have centered shooting
        bulletPosition = this.gameObject.transform.position;
        GameObject bulletPrefab;
        Bullet bulletScript;
        bool createBullet = true;
        //Check list for bullets in bullet list
        if (_bulletList.Count > 0)
        {
            foreach (GameObject theBulletPrefab in _bulletList)
            {
                bulletScript = theBulletPrefab.GetComponent<Bullet>();
                if (!bulletScript.Exists)
                {
                    //if there is a free bullet in bullet list
                    //reuse that bullet here
                    createBullet = false;
                    bulletScript.PlayerBullet = true;
                    //Get angle between points
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    float deltaY = mousePosition.y - bulletPosition.y;
                    float deltaX = mousePosition.x - bulletPosition.x;
                    float angle = Mathf.Atan2(deltaY, deltaX);
                    //change x and y speeds based on angle
                    Vector2 bulletSpeedVector;
                    bulletSpeedVector.x = Mathf.Cos(angle) * _bulletSpeed;
                    bulletSpeedVector.y = Mathf.Sin(angle) * (_bulletSpeed + CameraScript.Instance().CameraMoveSpeed);

                    bulletScript.ReuseBullet(bulletPosition, _damage, bulletSpeedVector);
                    break;
                }
            }
        }
        if(createBullet)
        {
            //if there are no free bullets in bullet list
            //Create a new bullet and add it to the list
            bulletPrefab = (GameObject)(Instantiate(Resources.Load("Bullet"), bulletPosition, Quaternion.identity));
            bulletScript = bulletPrefab.GetComponent<Bullet>();
            bulletScript.PlayerBullet = true;
            bulletScript.GetComponent<SpriteRenderer>().sprite = Resources.Load("TempBullet", typeof(Sprite)) as Sprite;
            //Get angle between points
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float deltaY = mousePosition.y - bulletPosition.y;
            float deltaX = mousePosition.x - bulletPosition.x;
            float angle = Mathf.Atan2(deltaY, deltaX);
            //change x and y speeds based on angle
            Vector2 bulletSpeedVector;
            bulletSpeedVector.x = Mathf.Cos(angle) * _bulletSpeed;
            bulletSpeedVector.y = Mathf.Sin(angle) * (_bulletSpeed + CameraScript.Instance().CameraMoveSpeed);
            bulletScript.InitializeStats(_damage, bulletSpeedVector);
            _bulletList.Add(bulletPrefab);
        }
    }

    public void Reload()
    {
        _canShoot = true;
    }
	
	public void UpdateShooting(Vector2 playerPosition)
    {
        if(_canShoot)
        {
            Shoot(playerPosition);
            _canShoot = false;
            Invoke("Reload", _fireRate);
        }
    }
}
