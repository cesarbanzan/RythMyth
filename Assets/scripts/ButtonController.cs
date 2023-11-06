using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // seteamos las imagenes de los botones
    private SpriteRenderer spriteRender;
    public Sprite defaultImage;
    public Sprite pushImage;
    public bool staticButton;
    private Animator animate;
    public bool animatedButton;

    public Player player;
    // le asignamos una tecla a un boton
    public KeyCode keyPressed;
    // Start is called before the first frame update
    void Start()
    {
     
        spriteRender = GetComponent<SpriteRenderer>();
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // cambiamos la imagen cuando se toca la tecla correspondiente a un boton
        if (staticButton){
            if (Input.GetKeyDown(keyPressed))
            {
                Debug.Log("jugador segun el boton" + player.transform.position.y);
                spriteRender.sprite = pushImage;
                if (animatedButton)
                {
                    animate.SetBool("explote", true);
                }
               
               
            }
            if (Input.GetKeyUp(keyPressed))
            {
                if (animatedButton)
                {
                    animate.SetBool("explote", false);
                }
                spriteRender.sprite = defaultImage;
            }
        }
      else if(transform.position.y== player.transform.position.y)
        {
            if (Input.GetKeyDown(keyPressed))
            {
              
                spriteRender.sprite = pushImage;
                  if (animatedButton)
                {
                    animate.SetBool("explote", true);
                }
            }
            if (Input.GetKeyUp(keyPressed))
            {
                if (animatedButton)
                {
                    animate.SetBool("explote", false);
                }
                spriteRender.sprite = defaultImage;
            }
        }
    }
}
