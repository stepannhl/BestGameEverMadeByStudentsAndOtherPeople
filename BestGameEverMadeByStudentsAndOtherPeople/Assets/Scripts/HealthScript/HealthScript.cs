using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public GameObject Enemy;
    public float LifePoints;

    public void TakeDamage(float damage)
    {
        LifePoints -= damage;
        if (LifePoints <= 0)
            Die();
        GetComponent<Animation>().Play();

    }


    private void Die()
    {
        Destroy(Enemy);
    }


}
