using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public bool mover;
    public float desplazar;
    public KeyCode subir;
    public KeyCode bajar;
    public ButtonController boton1;
    public ButtonController boton2;
    public ButtonController boton3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mover)
        {
            if(Input.GetKeyDown(subir)&& transform.position.y== boton1.transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, boton3.transform.position.y, 0f);
            }
            else if (Input.GetKeyDown(bajar) && transform.position.y == boton3.transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, boton1.transform.position.y, 0f);
            }else if (Input.GetKeyDown(subir))
            {
                transform.position += new Vector3(0f, desplazar , 0f);
            }else if (Input.GetKeyDown(bajar))
            {
                transform.position += new Vector3(0f, -desplazar, 0f);
            }
        }
    }
}
