using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownAnum : MonoBehaviour
{
    public Vector2 speed;
    public GameObject palochka;
    private Vector3 coordinate;

    private void Start()
    {

        coordinate = new Vector3(palochka.transform.position.x, 5.75f+ (palochka.transform.localScale.y / 2), 0);
    }

    void Update()
    {
        if (transform.position.y > -5.76f)
        {
            transform.Translate(speed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = coordinate;
        }
    }
}