using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemy;
    private GameObject player;
    public GameObject bulletPrefub;
    private float rotationZ;
    private Vector2 difference, direction;

    private float BulletSpeed = 50f;
    private float coolDown;
    private float speed = 1f;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        coolDown = Time.time + 2f;
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.time>coolDown)
        {
            difference = player.transform.position - enemy.transform.position;
            rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            coolDown = Time.time + speed;
            GameObject b = Instantiate(bulletPrefub) as GameObject;
            b.transform.position = enemy.transform.position;
            b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            distance = difference.magnitude;
            direction = difference / distance;
            direction.Normalize();
            b.GetComponent<Rigidbody2D>().velocity = direction* BulletSpeed;
        }

    }
}
