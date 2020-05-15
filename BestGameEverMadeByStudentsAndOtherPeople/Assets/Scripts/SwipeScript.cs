
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeScript : MonoBehaviour
{
    public Rigidbody2D player;
    Vector2 startPos, endPos, direction; // Стартовая свайпа. Конечная. Направление свайпа.
    float touchTimeStart, touchTimeFinish, TimeInterval; //Рассчет времени свайпа
    [Range(0.05f, 1f)]          //слайдер "инспектора"
    public float throwForce = 0.6f; //Контрольное значение слайдера 
    float rotation = 50f;
    
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
                 //Фиксируем конечное время
                 touchTimeFinish = Time.time;

                 //Считаем интервал свайпа
                 TimeInterval = touchTimeFinish - touchTimeStart;

                 //Сохраняем итоговую позицию
                 endPos = Input.GetTouch(0).position;

                 //Считаем направление свайпа
                 direction = startPos - endPos;

                 //Задаем импульс для персонажа.
                 player.AddForce(-direction / TimeInterval * throwForce);
                 player.AddTorque(rotation);
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
                player.AddForce(-direction / TimeInterval * throwForce);
                player.AddTorque(rotation);
            }

            }
        
        #endregion

    }


    void Start()
    {
        
    }


    
}
