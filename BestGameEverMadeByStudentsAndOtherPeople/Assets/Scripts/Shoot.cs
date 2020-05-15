using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    Vector2 startPos, endPos, direction; // Стартовая свайпа. Конечная. Направление свайпа.
    float touchTimeStart, touchTimeFinish, TimeInterval; //Рассчет времени свайпа
    private Vector3 target;
    public GameObject player;
    public GameObject bulletPrefab;
    public float bulletSpeed = 50f;

    bool check = false;

    public float coolDown;
    private float coolDownTimer = 0;


    private void Update()
    {
        #region PC


        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (Mathf.Sqrt(Mathf.Pow(Input.mousePosition.x - startPos.x, 2) + Mathf.Pow(Input.mousePosition.y - startPos.y, 2)) < 75f)
            {
                target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
                Vector3 difference = target - player.transform.position;
                float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                direction.Normalize();

                if (Time.time > coolDownTimer)
                    fireBullet(direction, rotationZ);

            }

        }
        #endregion

        #region Android
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, transform.position.z));
            Vector3 differenceAndroid = target - player.transform.position;
            float rotationZAndroid = Mathf.Atan2(differenceAndroid.y, differenceAndroid.x) * Mathf.Rad2Deg;
            float distance = differenceAndroid.magnitude;
            Vector2 direction = differenceAndroid / distance;
            direction.Normalize();

           
            if(Time.time>coolDownTimer)
                fireBullet(direction, rotationZAndroid);

        }
        #endregion
    }

    void fireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = player.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        coolDownTimer = Time.time + coolDown;
    }


    

}

