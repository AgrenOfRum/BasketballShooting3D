using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadscenex : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    
     
    

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            obj1.SetActive(true);
            obj2.SetActive(true);
            
        }
    }


}
