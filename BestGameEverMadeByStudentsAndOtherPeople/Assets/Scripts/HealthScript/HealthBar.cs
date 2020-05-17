using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image bar;
    public float fill;
    private PlayerHealth health;

    // Start is called before the first frame update
    void Start()
    {
        fill = 1f;
        health = gameObject.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.LifePoints > 0)
            bar.fillAmount = health.LifePoints / 10;
        else bar.fillAmount = 0;
    }
}
