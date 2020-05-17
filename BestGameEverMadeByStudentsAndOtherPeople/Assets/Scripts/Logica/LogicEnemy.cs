using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicEnemy : MonoBehaviour
{
    public Rigidbody2D enemy;
    private GameObject player;

    private float Cooldown = 2f;
    private float CHeckCoolDown;
    private float CheckCooldownTouch;
    private int switcher;
    private Vector2 force;


    //public GameObject bulletPrefab;
    //public float bulletDamage;
    public float touchDamage;
    private PlayerHealth health;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        CHeckCoolDown = Time.time;
        CheckCooldownTouch = Time.time;
        enemy = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(8, 10);
        health = gameObject.GetComponent<PlayerHealth>();


    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>CHeckCoolDown)
        {
            switcher = (int)Random.Range(0,10)%5;
            switch (switcher)
            {
                case 0:
                    //Импульс вверх. 0, чтобы срабатывал 3\2 по отношению к остальным.
                    force = new Vector2(0, Random.Range(300, 325));
                    enemy.AddForce(force);
                    break;
                case 1:
                    //даем импульс влево
                    force = new Vector2(-(Random.Range(225, 300)), 0);
                    enemy.AddForce(force);
                    
                    break;
                case 2:
                    //даем импульс влево вверх
                    force = new Vector2(-(Random.Range(225, 300)), Random.Range(225, 300));
                    enemy.AddForce(force);

                    break;
                case 3:
                    //Ничего не происходит
                    break;
                case 4:
                    //даем импульс вправо вверх
                    force = new Vector2(Random.Range(225, 300), Random.Range(225, 300));
                    enemy.AddForce(force);

                    break;
                case 5:
                    //даем импульс вправо
                    force = new Vector2(Random.Range(225, 300), 0);
                    enemy.AddForce(force);

                    break;
            }


            CHeckCoolDown = Time.time + Cooldown;
        }



}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Time.time>CheckCooldownTouch)
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            health = player.GetComponent<PlayerHealth>();
            health.TakeDamage(touchDamage);
                CheckCooldownTouch = Time.time + 0.5f;
        }
    }
}
