using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public KeyCode keyPressed;

    public GameObject hitEffect,goodEffect,perfectEffect,missEffect;

   
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
                //Destroy(gameObject);
                //GameManager.instance.NoteHit();

                if (Mathf.Abs(transform.position.y) > 0.25f)
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
                else if (Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);

                }
                else if(Mathf.Abs(transform.position.y)== 0)
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);

                }
            }
        }
        if (!canBePressed)
        {
            if (transform.position.y < 0)
            {
                gameObject.SetActive(false);
                GameManager.instance.NoteMissed();
                Instantiate(missEffect, new Vector3(transform.position.x,0f,0f), missEffect.transform.rotation);
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
            if(canBePressed)
            {
                canBePressed = false;
                Debug.Log("Missed");
            
            }
        }
    }
}
