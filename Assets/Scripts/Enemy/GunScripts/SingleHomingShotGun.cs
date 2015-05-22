using UnityEngine;
using System.Collections;

public class SingleHomingShotGun : EnemyGun
{
    protected override void Start()
    {
        _gunName = "SingleHomingShot";
        Invoke("Reload", _fireRate);
    }

    public override void AssignReference(GameObject enemyRef, float fireRate, float bulletSpeed, int damage)
    {
        base.AssignReference(enemyRef, fireRate, bulletSpeed, damage);
    }

    public override void Shoot()
    {
        base.Shoot();
        Vector2 bulletPosition = this.gameObject.transform.position;
        GameObject bulletPrefab;
        Bullet bulletScript;
        bool createBullet = true;
        //Checks bullet list if for a free bullet
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
                    //bulletSpeed needs to be changed to accomodate gun specific parameters

                    //Get angle between enemy and player
                    Vector2 playerPosition = PlayerScript.Instance().transform.position;
                    Vector2 enemyPosition = this.gameObject.transform.position;
                    float deltaY = playerPosition.y - enemyPosition.y;
                    float deltaX = playerPosition.x - enemyPosition.x;
                    float angle = Mathf.Atan2(deltaY, deltaX);
                    //change x and y speeds based on angle
                    Vector2 bulletSpeedVector;
                    bulletSpeedVector.x = Mathf.Cos(angle) * (_bulletSpeed);
                    //Must account for camera move speed for Y direction
                    bulletSpeedVector.y = (Mathf.Sin(angle) * (_bulletSpeed) + CameraScript.Instance().CameraMoveSpeed);
                    //Send new speed to Reuse Bullet function
                    bulletScript.ReuseBullet(this.gameObject.transform.position, _damage, bulletSpeedVector);
                    break;
                }
            }
        }
        if(createBullet)
        {
            //TODO: FIGURE OUT HOW TO HAVE ENEMY SHOOT AT PLAYER
            //if there are no free bullets in bullet list
            //Create a new bullet and add it to the list
            bulletPrefab = (GameObject)(Instantiate(Resources.Load("Bullet"), bulletPosition, Quaternion.identity));
            bulletScript = bulletPrefab.GetComponent<Bullet>();
            //Get angle between enemy and player
            Vector2 playerPosition = PlayerScript.Instance().transform.position;
            Vector2 enemyPosition = this.gameObject.transform.position;
            float deltaY = playerPosition.y - enemyPosition.y;
            float deltaX = playerPosition.x - enemyPosition.x;
            float angle = Mathf.Atan2(deltaY , deltaX);
            //change x and y speeds based on angle
            Vector2 bulletSpeedVector;
            bulletSpeedVector.x = Mathf.Cos(angle) * (_bulletSpeed);
            //Must account for camera move speed for Y direction
            bulletSpeedVector.y = (Mathf.Sin(angle) * (_bulletSpeed) + CameraScript.Instance().CameraMoveSpeed);
            bulletScript.InitializeStats(_damage, bulletSpeedVector);
            _bulletList.Add(bulletPrefab);
        }
    }
}