using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletDamage;
    private HealthScript health;
    private PlayerHealth Playerhealth;
    private bool enemyCheck;

    private void Start()
    {
        if (bulletPrefab.tag == "EnemyBullet")
            enemyCheck = false;
        else enemyCheck = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && enemyCheck == true)
        {
            GameObject enemy = collision.gameObject;
            health = enemy.GetComponent<HealthScript>();
            health.TakeDamage(bulletDamage);
            Destroy(bulletPrefab);
        }
        else if (collision.gameObject.tag == "Player" && enemyCheck == false)
        {
            Debug.Log("ahahah");
            GameObject player = collision.gameObject;
            Playerhealth = player.GetComponent<PlayerHealth>();
            Playerhealth.TakeDamage(bulletDamage);
            Destroy(bulletPrefab);
        }
        
        
        
       
        
    }

}
