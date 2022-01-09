using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public float moveSpeed;
    public GameObject pickUpEffect;
    bool movingLeft = true;

    bool firstInput = true;

    // bool stop = false;
    float speedIncrement=1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IncreaseSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            Move();
            CheckInput();
            
        }
        if (transform.position.y <= -2)
        {
            GameManager.instance.GameOver();
        }
        
        
    }

    IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(20f);
            speedIncrement+=0.05f;

        }
    }


    void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime * speedIncrement;
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
