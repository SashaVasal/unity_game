using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class snar : MonoBehaviour {

    public inventary inv;
    public GameObject btn;
    Image image;
    public Sprite[] sprites; 
    // Use this for initialization
    void Start () {
        image = GetComponent<Image>();
        

    }
	
	// Update is called once per frame
	void Update () {
        
        //Debug.Log(inv.sword_number);
        image.sprite = sprites[inv.sword_number];
    }
}
