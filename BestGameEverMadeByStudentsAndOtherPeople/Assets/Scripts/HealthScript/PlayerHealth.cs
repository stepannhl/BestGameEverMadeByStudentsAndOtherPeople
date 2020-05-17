using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private GameObject player;
    public float LifePoints;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void TakeDamage(float damage)
    {
        LifePoints -= damage;
        if (LifePoints <= 0)
            Die();

    }


    private void Die()
    {
        SceneManager.LoadScene("Menu");
    }
}
