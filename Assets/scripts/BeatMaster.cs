using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMaster : MonoBehaviour
{
    public GameObject[] patrones;
    public bool stop;
    public int time;
   [SerializeField] public int vueltas;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GenerarBeat");
    }

  
    // Update is called once per frame
    void Update()
    {
        

    }
    IEnumerator GenerarBeat()
    {
   
        for(int i = 0; i < vueltas; i++)
        {
            Instantiate(patrones[Random.Range(0,patrones.Length)], transform.position, Quaternion.identity).SetActive(true);
            yield return new WaitForSeconds(time);
        }
  
    }
     
}
