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
        SceneManager.LoadScene(1);
    }
    public void Nivel2()
    {
        SceneManager.LoadScene(2);
    }
    public void exit()
    {
        Debug.Log("salimos..");
        Application.Quit();
    }
}
