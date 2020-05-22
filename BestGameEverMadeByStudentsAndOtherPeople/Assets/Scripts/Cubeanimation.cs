using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubeanimation : MonoBehaviour
{
    private Vector3 firstLocalScale;
    public GameObject layer1;
    public GameObject layer2;
    public GameObject layer3;

    private Vector3 firstLocalPosition1;
    private Vector3 firstLocalPosition2;
    private Vector3 firstLocalPosition3;

    private Vector3 firstLocalScale1;
    private Vector3 firstLocalScale2;
    private Vector3 firstLocalScale3;
    private float Cooldown;
    private float coldwn = 2.5f;

    private void Start()
    {
        firstLocalScale = transform.localScale;


        firstLocalPosition1 = layer1.transform.position;
        firstLocalPosition2 = layer2.transform.position;
        firstLocalPosition3 = layer3.transform.position;

        layer1.transform.localScale *= 0.001f;
        layer2.transform.localScale *= 0.001f;
        layer3.transform.localScale *= 0.001f;

        firstLocalScale1 = layer1.transform.localScale;
        firstLocalScale2 = layer2.transform.localScale;
        firstLocalScale3 = layer3.transform.localScale;
        Cooldown = Time.time + coldwn;
    }

    void FixedUpdate()
    {
        Debug.Log(transform.rotation.eulerAngles);

            if ((transform.rotation.eulerAngles.x > 271 || transform.rotation.eulerAngles.x < 10))
            {
                transform.Rotate(new Vector3(-30, -30, -30) * Time.deltaTime);
                transform.localScale += new Vector3(0.25f, 0.25f, 0.25f);

                // layer1.transform.position += new Vector3(0, 0, -0.05f);
                //layer2.transform.position += new Vector3(0, 0, -0.1f);
                //layer3.transform.position += new Vector3(0, 0, -0.15f);

                layer1.transform.localScale += new Vector3(0.005f, 0.005f, 0);
                layer2.transform.localScale += new Vector3(0.015f, 0.015f, 0);
                layer3.transform.localScale += new Vector3(0.03f, 0.03f, 0);

            }
            else
            {
            Debug.Log(Time.time + " " + Cooldown);
            layer1.transform.localScale += new Vector3(0.001f, 0.001f, 0);
            layer2.transform.localScale += new Vector3(0.002f, 0.002f, 0);
            layer3.transform.localScale += new Vector3(0.003f, 0.003f, 0);
            if (Time.time > Cooldown)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    transform.localScale = firstLocalScale;
                    layer1.transform.position = firstLocalPosition1;
                    layer2.transform.position = firstLocalPosition2;
                    layer3.transform.position = firstLocalPosition3;

                    layer1.transform.localScale = firstLocalScale1;
                    layer2.transform.localScale = firstLocalScale2;
                    layer3.transform.localScale = firstLocalScale3;
                    Cooldown = Time.time + coldwn;
                }
            
        }
    }
}
