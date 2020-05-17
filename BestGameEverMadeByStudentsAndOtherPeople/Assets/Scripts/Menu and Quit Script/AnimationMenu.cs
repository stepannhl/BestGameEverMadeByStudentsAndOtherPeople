using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMenu : MonoBehaviour
{
    public Vector2 speed;
    public GameObject palochka;
    private Vector3 coordinate;

    private void Start()
    {
        
        coordinate = new Vector3(palochka.transform.position.x, -5.76f-(palochka.transform.localScale.y / 2));
    }

    void FixedUpdate()
    {

        if (transform.position.y < 5.7f)
        {
            transform.Translate(speed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = coordinate;
        }
    }
}
