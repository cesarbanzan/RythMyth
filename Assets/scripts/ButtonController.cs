using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // seteamos las imagenes de los botones
    private SpriteRenderer spriteRender;
    public Sprite defaultImage;
    public Sprite pushImage;
    // le asignamos una tecla a un boton
    public KeyCode keyPressed;
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        // cambiamos la imagen cuando se toca la tecla correspondiente a un boton
        if (Input.GetKeyDown(keyPressed)) 
        {
            spriteRender.sprite = pushImage;
        }
        if(Input.GetKeyUp(keyPressed))
        {
            spriteRender.sprite = defaultImage;
        }
    }
}
