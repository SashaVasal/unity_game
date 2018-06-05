using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventary : MonoBehaviour {
    public int[] items;
    public int mouseSlot;
    public lab lib;
    public GameObject hero;
    public player player;
    int loc;
    int health;
    public int sword_number;
    public GameObject cutter;
    public GameObject epic_sword;
    public GameObject rapair;
    public GameObject sword;
    public Image blade;
    float cooldown;
    void Start()
    {
        sword_number = 0;
        player = hero.GetComponent<player>();
    }
    void Update()
    {
        cooldown = cooldown + Time.deltaTime;
        if (health == 1)
        {
            
            player.hp_Player = player.hp_Player + 20;
            health = 0;
        }
        if (sword_number == 1) {
            sword.gameObject.SetActive(true);
            rapair.gameObject.SetActive(false);
            epic_sword.gameObject.SetActive(false);
            cutter.gameObject.SetActive(false);
            player.attack = 5;
        }
        if (sword_number == 2)
        {
            sword.gameObject.SetActive(false);
            rapair.gameObject.SetActive(true);
            epic_sword.gameObject.SetActive(false);
            cutter.gameObject.SetActive(false);
            player.attack = 20;
        }
        if (sword_number == 3)
        {
            sword.gameObject.SetActive(false);
            rapair.gameObject.SetActive(false);
            epic_sword.gameObject.SetActive(false);
            cutter.gameObject.SetActive(true);
            player.attack = 1;
        }
        if (sword_number == 4)
        {
            sword.gameObject.SetActive(false);
            rapair.gameObject.SetActive(false);
            epic_sword.gameObject.SetActive(true);
            cutter.gameObject.SetActive(false);
            player.attack = 35;
        }
    }
    void OnGUI()
    {
        for (int x = 0; x < 5; x++){
            for (int y = 0; y < 5; y++)
            {
               
                    if(GUI.Button(new Rect(x*50, y*50, 50, 50), lib.Images[items[y * 5 + x]]))
                    {                                           
                        if (items[y * 5 + x] == 5)
                        {
                            items[y * 5 + x] = 0;
                            health = 1;
                            
                        }

                        if (items[y * 5 + x] == 1 && cooldown > 1f)
                        {
                            items[y * 5 + x] = sword_number;
                            sword_number = 1;
                            
                            cooldown = 0;
                         }

                        if (items[y * 5 + x] == 2 && cooldown > 1f)
                        {
                            items[y * 5 + x] = sword_number;
                            sword_number = 2;
                           
                        cooldown = 0;
                    }

                        if (items[y * 5 + x] == 3 && cooldown > 1f)
                        {
                            items[y * 5 + x] = sword_number;
                            sword_number = 3;
                            
                        cooldown = 0;
                    }

                        if (items[y * 5 + x] == 4 && cooldown > 1f)
                        {

                            items[y * 5 + x] = sword_number;
                            sword_number = 4;
                            
                        cooldown = 0;
                    }
                    }


                
                    
            }
        }
            GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, 50, 50), lib.Images[mouseSlot]);
            
        
    }
}
