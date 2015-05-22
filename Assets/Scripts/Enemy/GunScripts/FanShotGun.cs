using UnityEngine;
using System.Collections;

public class FanShotGun : EnemyGun
{
    void Start()
    {
        _gunName = "FanShot";
        Invoke("Reload", _fireRate);
    }

    public override void Shoot()
    {
        base.Shoot();
        Vector2 bulletPosition = this.gameObject.transform.position;
        int bulletCounter = 0;
        GameObject bulletPrefab1 = null;
        GameObject bulletPrefab2 = null;
        GameObject bulletPrefab3 = null;
        Bullet bulletScript;
        bool createBullet = true;

        if(_bulletList.Count > 0)
        {
             foreach(GameObject theBulletPrefab in _bulletList)
             {
                 bulletScript = theBulletPrefab.GetComponent<Bullet>();
                 if(!bulletScript.Exists)
                 {
                     bulletCounter++;
                     if(bulletCounter == 1)
                     {
                         bulletPrefab1 = theBulletPrefab;
                         bulletPrefab1.GetComponent<Bullet>().ReuseBullet(this.gameObject.transform.position, _damage, AssignSpeedAndAngle(225));
                     }
                     else if(bulletCounter == 2)
                     {
                         bulletPrefab2 = theBulletPrefab;
                         bulletPrefab2.GetComponent<Bullet>().ReuseBullet(this.gameObject.transform.position, _damage, AssignSpeedAndAngle(315));
                     }
                     else if(bulletCounter == 3)
                     {
                         createBullet = false;
                         bulletPrefab3 = theBulletPrefab;
                         //Fire the 3 bullets

                         bulletPrefab3.GetComponent<Bullet>().ReuseBullet(this.gameObject.transform.position, _damage, AssignSpeedAndAngle(270));

                         break;
                     }
                 }
             }
        }
        if(createBullet)
        {
            Bullet bulletScript1;
            Bullet bulletScript2;
            Bullet bulletScript3;
            //Before creating bullets, check if bulletPrefabs 1-3 are not null
            if(!bulletPrefab1)
            {
                //45 degree to left
                bulletPrefab1 = (GameObject)(Instantiate(Resources.Load("Bullet"), bulletPosition, Quaternion.identity));
                bulletPrefab1.GetComponent<Bullet>().InitializeStats(_damage, AssignSpeedAndAngle(225));
                _bulletList.Add(bulletPrefab1);
            }
            if(!bulletPrefab2)
            {
                //45 degree to right
                bulletPrefab2 = (GameObject)(Instantiate(Resources.Load("Bullet"), bulletPosition, Quaternion.identity));
                bulletPrefab2.GetComponent<Bullet>().InitializeStats(_damage, AssignSpeedAndAngle(315));
                _bulletList.Add(bulletPrefab2);
            }
            //straight
            bulletPrefab3 = (GameObject)(Instantiate(Resources.Load("Bullet"), bulletPosition, Quaternion.identity));
            bulletPrefab3.GetComponent<Bullet>().InitializeStats(_damage, AssignSpeedAndAngle(270));
            _bulletList.Add(bulletPrefab3);

            //create third bullets
        }
    }

    Vector2 AssignSpeedAndAngle(float theAngle)
    {
        float angle = (theAngle * Mathf.PI) / 180; //225 degrees in radians
        Vector2 bulletSpeedVector;
        bulletSpeedVector.x = Mathf.Cos(angle) * _bulletSpeed;
        bulletSpeedVector.y = Mathf.Sin(angle) * _bulletSpeed;

        return bulletSpeedVector;
    }
}

