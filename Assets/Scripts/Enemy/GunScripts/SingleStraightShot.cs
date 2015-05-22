using UnityEngine;
using System.Collections;

public class SingleStraightShot : EnemyGun
{

    protected override void Start()
    {
        _gunName = "SingleStraightShot";
        Invoke("Reload", _fireRate);
    }

    public override void Shoot()
    {
        base.Shoot();
        Vector2 bulletPosition = this.gameObject.transform.position;
        GameObject bulletPrefab;
        Bullet bulletScript;
        bool createBullet = true;

        if(_bulletList.Count > 0)
        {
            foreach(GameObject theBulletPrefab in _bulletList)
            {
                bulletScript = theBulletPrefab.GetComponent<Bullet>();
                if(!bulletScript.Exists)
                {
                    Debug.Log("Reused");
                    createBullet = false;
                    Vector2 bulletSpeedVector = new Vector2(0, (_bulletSpeed + CameraScript.Instance().CameraMoveSpeed) * -1);
                    bulletScript.ReuseBullet(bulletPosition, _damage, bulletSpeedVector);
                    break;
                }
            }
        }
        if(createBullet)
        {
            Debug.Log("New");
            bulletPrefab = (GameObject)(Instantiate(Resources.Load("Bullet"), bulletPosition, Quaternion.identity));
            bulletScript = bulletPrefab.GetComponent<Bullet>();
            Vector2 bulletSpeedVector = new Vector2(0, (_bulletSpeed + CameraScript.Instance().CameraMoveSpeed) * -1);
            bulletScript.InitializeStats(_damage, bulletSpeedVector);
            _bulletList.Add(bulletPrefab);
        }
    }
}
