using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColorChanger : MonoBehaviour
{
    private Camera cam;
    private float cycleSeconds = 100f;

    void Awake() 
    {
        cam = GetComponent<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cam.backgroundColor = Color.HSVToRGB(
             Mathf.Repeat(Time.time / cycleSeconds, 1f),
             .5f,     // set to a pleasing value. 0f to 1f
             1f      // set to a pleasing value. 0f to 1f
         );     
    }
}
