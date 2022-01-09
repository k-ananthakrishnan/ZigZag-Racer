using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject diamond;



    // Start is called before the first frame update
    void Start()
    {
        int randDiamond = Random.Range(0, 20);
        Vector3 diamondPos = transform.position;
        diamondPos.y += 1.2f;

        if (randDiamond == 10)
        {
            GameObject diamondInstance = Instantiate(diamond, diamondPos, diamond.transform.rotation);
            diamondInstance.transform.SetParent(gameObject.transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        Invoke("Fall", 0.2f);
        }
    }

    void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 0.5f);
    }
}
