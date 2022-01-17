using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public float moveSpeed;
    float currentSpeed = 0f;
    private float accelerationTime = 300;   
    float maxSpeed = 20;
    public GameObject pickUpEffect;
    bool movingLeft = true;

    bool firstInput = true;

    private float time;
    private float minSpeed ;
    // bool stop = false;

    bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        minSpeed = moveSpeed; 
        time = 0 ;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            Move();
            CheckInput();
            
            
        }
        if (transform.position.y <= -2 )
        {
            if (!gameOver)
            {
            gameOver=true;
            GameManager.instance.GameOver();
            }
        }
        
        
    }


    void Move()
    {
         currentSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, time / accelerationTime );
         transform.position += transform.forward * currentSpeed * Time.deltaTime;
         time += Time.deltaTime ;
    }


    void CheckInput()
    {
        // first input then ignore it
        if (firstInput)
        {
            firstInput = false;
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.instance.GameOver();
                Debug.Log("RELOAD");
            }
    }

    void ChangeDirection()
    {
        if(movingLeft)
        {
            movingLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            movingLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Diamond")
        {
            GameManager.instance.IncrimentScore();

            Instantiate(pickUpEffect, other.transform.position, pickUpEffect.transform.rotation);

            other.gameObject.SetActive(false);
        }
    }
}
