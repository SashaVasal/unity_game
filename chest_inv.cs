using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest_inv : MonoBehaviour {
    public int[] items;
    public int mouseSlot;
    public lab lib;
    int sign;
    public GameObject btn;
    int breaker;
    public inventary inv;
   
    // Use this for initialization
    void Start () {
        inv = btn.GetComponent<inventary>();
    }
	
	// Update is called once per frame

    void OnGUI()
    {
        if(sign == 1)
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (GUI.Button(new Rect(x * 50 + 600, y * 50, 50, 50), lib.Images[items[y * 5 + x]]))
                    {
                        if(items[y * 5 + x] != 0)
                        {
                            //inv.items[y * 5 + x] == 
                            breaker = 0;
                            for (int x1 = 0; x1 < 5; x1++)
                            {
                                for (int y1 = 0; y1 < 5; y1++)
                                {
                                    if (breaker == 1)
                                    {
                                        break;
                                    }
                                    if (inv.items[y1 * 5 + x1] == 0)
                                    {
                                        breaker = 1;
                                        inv.items[y1 * 5 + x1] = items[y * 5 + x];
                                        break;

                                    }
                                }
                            }
                            items[y * 5 + x] = 0;
                        }
                    }
                }
            }
            GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, 50, 50), lib.Images[mouseSlot]);
        }
    }
   


    
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            sign = 1;
            
        }
        
   
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            sign = 0;
           
        }
    }
}
