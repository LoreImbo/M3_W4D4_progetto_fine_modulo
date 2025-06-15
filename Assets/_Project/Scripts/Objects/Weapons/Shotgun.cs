using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField] private float spreadAngle = 15f;
    public override void Shoot()
    {
        GameObject enemy = FindNearestEnemy();
        if (enemy == null) return;

        if (Vector2.Distance(transform.position, enemy.transform.position) <= fireRange)
        {
            if (Time.time - _lastShotTime > _fireRate)
            {
                _lastShotTime = Time.time;
                Vector2 force = (enemy.transform.position - transform.position).normalized;
                Bullet b1 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Bullet b2 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Bullet b3 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

                Vector2 dirLeft = Quaternion.Euler(0, 0, spreadAngle) * force;
                Vector2 dirRight = Quaternion.Euler(0, 0, -spreadAngle) * force;

                b1.ShootBullet(transform.position, force, damage);
                b2.ShootBullet(transform.position, dirLeft, damage);
                b3.ShootBullet(transform.position, dirRight, damage);
                //b.ShootBullet(tag, _lastMoveDirection, Damage);
            }
        }
    }
    void Update()
    {
        Shoot();
    }
}