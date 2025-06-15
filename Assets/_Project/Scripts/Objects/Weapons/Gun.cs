using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] protected Bullet bulletPrefab;
    [SerializeField] protected float fireRange = 10;
    [SerializeField] protected int damage = 10;
    protected float _fireRate = 0.5f;
    protected float _lastShotTime;
    private Vector2 _lastMoveDirection = Vector2.right;

    public void UpdateDirection(Vector2 moveDirection)
    {
        if (moveDirection != Vector2.zero)
        {
            _lastMoveDirection = moveDirection;
        }
    }

    public GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy == null)
        {
            return null;
        }
        return nearestEnemy;
    }
    public virtual void Shoot()
    {
        GameObject enemy = FindNearestEnemy();
        if (enemy == null) return;

        if (Vector2.Distance(transform.position, enemy.transform.position) <= fireRange)
        {
            if (Time.time - _lastShotTime > _fireRate)
            {
                _lastShotTime = Time.time;
                Vector2 force = enemy.transform.position - transform.position;
                float angle = Mathf.Atan2(force.y, force.x) * Mathf.Rad2Deg;
                Bullet b = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle));
                b.ShootBullet(transform.position, force.normalized, damage);
                //b.ShootBullet(tag, _lastMoveDirection, Damage);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
}
