using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;

    public bool horizontal;
    public bool hasStarted; 
    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo/60f;
    }

    // Update is called once per frame
    void Update()
    {
        //hacemos que las flechas caigan 
        if (horizontal)
        {
            transform.position -= new Vector3(beatTempo * Time.deltaTime, 0f, 0f);
        }
        else
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
  
        //if (hasStarted)
        //{
           
        //    /* if (Input.anyKeyDown)
        //     {
        //         hasStarted = true;
        //     }*/
        //}
        //else
        //{
        
        //}
    }
}
