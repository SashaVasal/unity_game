using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeOpen : MonoBehaviour {
    int i;
    public inventary inv;
    public GameObject hero;

    void OnGUI()
    {
        
    }
    void Start()
    {
        var inv = gameObject.GetComponent<inventary>();
        i = -1;
    }
    void Update()
    {
        if (i == 1)
        {
            //Debug.Log(i);
            inv.enabled = false;
            hero.gameObject.SetActive(false);
        }
        else
        {
            inv.enabled = true;
            hero.gameObject.SetActive(true);


        }
    }
    public void CloseOpen()
    {
        i = -1 * i;
        //Debug.Log(i);
        
        

    }
    
}
