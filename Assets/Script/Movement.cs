using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Touch touch;
    bool _swipe;
    public float speed;
    public Transform Target;
    public Transform CurrentPos;
    public Transform Ball;
    public Transform fail;
    Rigidbody rb;
    public int chance;
    
    
    float T = 0;
    private bool Shootingg = false;
    private bool FailShootingg = false;
    void Start()
    {
        speed = 0.0008f;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
        }

        if (touch.phase == TouchPhase.Moved)
        {
            transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed, transform.position.y, transform.position.z + touch.deltaPosition.y * speed);
            
        }

        if (Shootingg)
        {
            T += Time.deltaTime;
            float duration = 0.8f;
            float t01 = T / duration;

            Vector3 A = CurrentPos.position;
            Vector3 B = Target.position;
            Vector3 pos = Vector3.Lerp(A, B, t01);
            Vector3 arc = Vector3.up * 1 * Mathf.Sin(t01 * 3.14f);
            Ball.position = pos + arc;



        }

        if (FailShootingg)
        {
            T += Time.deltaTime;
            float duration = 0.8f;
            float t01 = T / duration;

            Vector3 A = CurrentPos.position;
            Vector3 B = fail.position;
            Vector3 pos = Vector3.Lerp(A, B, t01);
            Vector3 arc = Vector3.up * 1 * Mathf.Sin(t01 * 3.14f);
            Ball.position = pos + arc;



        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shooting"))
        {
            if (Input.touchCount>0)
            {
                Touch parmak = Input.GetTouch(0);
                if (parmak.deltaPosition.y>50.0f)
                {
                    T = 0;
                    Shootingg = true;
                }
            }
                             
        }

        if (other.gameObject.CompareTag("Shooting2"))
        {
            if (Input.touchCount > 0)
            {
                Touch parmak = Input.GetTouch(0);
                if (parmak.deltaPosition.y > 50.0f)
                {
                    T = 0;

                    chance = Random.Range(0, 101);

                    if (chance <= 70)
                    {
                        Shootingg = true;
                    }
                    else
                    {
                        FailShootingg = true;
                    }
                    
                }
            }

        }



        if (other.gameObject.CompareTag("Target"))
        {
            
            Shootingg = false;
        }

        if (other.gameObject.CompareTag("Target2"))
        {
            
            FailShootingg = false;
        }

    }


}
