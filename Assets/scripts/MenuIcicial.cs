using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuIcicial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Nivel1()
    {
        //carga la escena 5 = nivel1
        SceneManager.LoadScene(5);
    }
    public void Nivel2()
    {
        //carga la escena 5 = nivel2
        SceneManager.LoadScene(2);
    }
    public void exit()
    {
        //cierra la aplicacion
        Debug.Log("salimos..");
        Application.Quit();
    }
}
