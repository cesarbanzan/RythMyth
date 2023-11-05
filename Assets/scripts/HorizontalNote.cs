using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HorizontalNote : MonoBehaviour
{
    public KeyCode keyPressed;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    public float normalDistance;
    public float goodDistance;
    public float perfectDistance;
    public bool canBePressed;
    public string etiqueta;
    
    public ButtonController button;
    public bool playerhit;
    public Player jugador;
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
            if (canBePressed)
            {
                gameObject.SetActive(false);
                //Destroy(gameObject);
                //GameManager.instance.NoteHit();

                if (Mathf.Abs(transform.position.x) > normalDistance)
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
                else if (Mathf.Abs(transform.position.x) > goodDistance)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);

                }
          
                else
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);

                }
            }
        }
     
   
    }
    //recibimos cuado las flechas pasen sobre los botones
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == etiqueta)
        {
            Debug.Log("jugador segun el notas" + jugador.transform.position.y);
            if (jugador.transform.position.y==button.transform.position.y)
            {
                canBePressed = true;
            }
            

        }
        if (other.tag == "Player")
        {
            playerhit = true;
           

        }
    }
    //recibimos cuado las flechas no esten sobre los botones
    private void OnTriggerExit2D(Collider2D other)

    {

        if (other.tag == "Activator")
        {
            gameObject.SetActive(false);
            Debug.Log("sale del boton");
            canBePressed = false;
        }
    }
  
}

