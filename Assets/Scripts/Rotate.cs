using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField] float LowSpeed, MiddleSpeed,FastSpeed;
    float speed = 1;
    int rnd;

    bool boost, reboost;
    float x = 0;



    // Start is called before the first frame update
    void Start()
    {
        rnd = GameObject.FindGameObjectWithTag("canvas").transform.GetComponent<KnifeHi>().Rot;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rnd <=100 && rnd >80)///////////////////////////////// вариант 1
        {
            if (speed < MiddleSpeed && !reboost)
            {
                speed *=1.05f ;
            }
            else reboost = true;


            if (speed > 0.5f && reboost)
            {
                speed /= 1.05f;
            }
            else reboost = false;
        }
        //////////////////////////////////////////////// вариант 2


        if (rnd <= 80 && rnd >64)
        {
            if (speed < MiddleSpeed && !reboost)
            {
                speed *= 1.03f;
            }
            else reboost = true;


            if (speed > 0.1f && reboost)
            {
                speed /= 1.03f;
            }
            else reboost = false;
        }
////////////////////////////////////////////////////////////////// вариант 3

        if (rnd <= 64 && rnd >48)
        {
            speed = Mathf.Sin(x)*MiddleSpeed;
            x += .03f;
        }

///////////////////////////////////////////////////////////////// вариант 4
        if (rnd <= 16)
        {
            speed = LowSpeed;
        }
///////////////////////////////////////////////////////////////// вариант 5
        if (rnd > 16 && rnd <=32)
        {
            speed = -LowSpeed;
        }

///////////////////////////////////////////////////////////////// вариант 6
        if (rnd <= 48 && rnd >32)
        {
            speed = Mathf.Pow(x,2) * MiddleSpeed;
            if (x < 1 && !reboost)
                x += .01f;
            else reboost = true;

            if (x > -1 && reboost)
                x -= .01f;
            else reboost = false;

        }







        transform.Rotate(0,0,speed);
    }
}
