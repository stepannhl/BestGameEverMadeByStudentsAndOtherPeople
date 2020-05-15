using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletDamage;
    private HealthScript health;
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 10);
        health = gameObject.GetComponent<HealthScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject enemy = collision.gameObject;
            health = enemy.GetComponent<HealthScript>();
            health.TakeDamage(bulletDamage);
        }
        Debug.Log(collision.collider);
        Destroy(bulletPrefab);
        
    }

}
