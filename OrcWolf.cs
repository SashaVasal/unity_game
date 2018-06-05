using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class OrcWolf : MonoBehaviour
{
    public GameObject target;
    Transform enemy;
    NavMeshAgent nav;
    Transform tr;
    float cooldown;
    float Distance;
    Animator anim;
    int i;
    float timeDeath;
    public int hp_Orc_Wolf = 10;
    public player player;
    int attack;
    bool col_target = false;
    public GameObject hp_potion;
    public king king;
    public GameObject Mking;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        king = Mking.GetComponent<king>();
    }

  
    void Update()
    {
        if(col_target == true)
        {
            if(hp_Orc_Wolf <= 0)
        {
                timeDeath = timeDeath + Time.deltaTime;
                if (timeDeath >= 0.2f)
                {
                    
                    Destroy(gameObject);
                    Instantiate(hp_potion, tr.position , tr.rotation);
                    king.Orcs = king.Orcs - 1;
                }
                anim.SetFloat("death", 1f);
            }
            // Debug.Log(NavMeshAgent.Warp);
            if (Vector3.Distance(tr.position, target.transform.position) < 4f)
            {
                nav.Stop();
                attack = 1;
                anim.SetFloat("attack", 1f);
                anim.SetFloat("go", -1f);
            }
            else
            {
                nav.Resume();
                this.gameObject.GetComponent<NavMeshAgent>().destination = target.transform.position;
                anim.SetFloat("attack", -0.5f);
                anim.SetFloat("go", 1f);
                attack = 0;
            }

        }

        
    }
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            target = col.gameObject;
            col_target = true;
            if (attack == 1 && col.tag == "Player")
            {
                cooldown = cooldown + Time.deltaTime;
                if (cooldown >= 3f)
                {
                    //Debug.Log("a");
                   
                    player = col.gameObject.GetComponent<player>();
                    player.hp_Player = player.hp_Player - 5;
                    cooldown = 0;
                }
            }
        }
       
    }
   

}









