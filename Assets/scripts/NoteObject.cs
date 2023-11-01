using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public KeyCode keyPressed;

    public bool canBePressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // desactivamos las felchas caundo tocamos la tecla del boton sobre el cual estan pasando
        if (Input.GetKeyDown(keyPressed))
        {
            if(canBePressed)
            {
                gameObject.SetActive(false);
            }
        }
    }
    //recibimos cuado las flechas pasen sobre los botones
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
        canBePressed=true;

        }
    }
    //recibimos cuado las flechas no esten sobre los botones
    private void OnTriggerExit2D(Collider2D other)
    
    {

        if (other.tag == "Activator")
        {
            canBePressed = false;

        }
    }
}
