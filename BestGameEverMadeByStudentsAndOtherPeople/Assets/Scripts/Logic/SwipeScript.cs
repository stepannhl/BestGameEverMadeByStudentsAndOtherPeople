﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeScript : MonoBehaviour
{
    public Rigidbody2D player;
    private Vector2 startPos, endPos, direction; // Стартовая свайпа. Конечная. Направление свайпа.
    private float touchTimeStart, touchTimeFinish, TimeInterval; //Рассчет времени свайпа
    [Range(0.05f, 1f)]          //слайдер "инспектора"
    private  float throwForce = 0.6f; //Контрольное значение слайдера 
    private float rotation = 50f;

    private float stopTime = 0.2f;    //Задаем ограничение свайпа

    private bool CheckGroundSwipe = false;

    private float cooldown;

    void Update()
    {

         #region Android
         //При касании экрана

             if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
             {
                 //сохраняем координаты тача. И фиксируем время.
                 touchTimeStart = Time.time;
                 startPos = Input.GetTouch(0).position;
             }

             //При конце свайпа
             if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
             {
            if (Mathf.Sqrt(Mathf.Pow(Input.GetTouch(0).position.x - startPos.x, 2) + Mathf.Pow(Input.GetTouch(0).position.y - startPos.y, 2)) < 75f)
            {
                        //Фиксируем конечное время
                         touchTimeFinish = Time.time;

                        //Считаем интервал свайпа
                        TimeInterval = touchTimeFinish - touchTimeStart;

                        //Сохраняем итоговую позицию
                        endPos = Input.GetTouch(0).position;

                        //Считаем направление свайпа
                        direction = startPos - endPos;

                //Задаем импульс для персонажа.
                if (!CheckGroundSwipe || Time.time>cooldown)
                {
                    if (TimeInterval > stopTime)
                    {
                        player.AddForce(-direction / TimeInterval * throwForce);
                        cooldown = Time.time + 2f;
                        CheckGroundSwipe = true;
                        if (direction.x > 0)
                            player.AddTorque(rotation);
                        else
                            player.AddTorque(-rotation);
                    }
                    else
                    {
                        player.AddForce(-direction / stopTime * throwForce);
                        cooldown = Time.time + 2f;
                        CheckGroundSwipe = true;
                        if (direction.x > 0)
                            player.AddTorque(rotation);
                        else
                            player.AddTorque(-rotation);
                    }
                }
            }
             }
         
         #endregion
         
        #region PC

            if (Input.GetMouseButtonDown(0))
            {
                touchTimeStart = Time.time;
                startPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
            
            if (Mathf.Sqrt(Mathf.Pow(Input.mousePosition.x - startPos.x, 2) + Mathf.Pow(Input.mousePosition.y - startPos.y, 2)) > 75f)
            {
                touchTimeFinish = Time.time;

                //Считаем интервал свайпа
                TimeInterval = touchTimeFinish - touchTimeStart;

                //Сохраняем итоговую позицию
                endPos = Input.mousePosition;

                //Считаем направление свайпа
                direction = startPos - endPos;

                //Задаем импульс для персонажа.
                if (!CheckGroundSwipe || Time.time > cooldown)
                {
                    if (TimeInterval > stopTime)
                    {
                        player.AddForce(-direction / TimeInterval * throwForce);
                        cooldown = Time.time + 2f;
                        CheckGroundSwipe = true;
                        if (direction.x > 0)
                            player.AddTorque(rotation);
                        else
                            player.AddTorque(-rotation);
                    }
                    else
                    {
                        player.AddForce(-direction / stopTime * throwForce);
                        cooldown = Time.time + 2f;
                        CheckGroundSwipe = true;
                        if (direction.x > 0)
                            player.AddTorque(rotation);
                        else
                            player.AddTorque(-rotation);
                    }
                }
            }

            }
        
        #endregion

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            CheckGroundSwipe = false;
    }



}
