using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class troll_boss : MonoBehaviour
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
    public int hp_Orc_Wolf = 150;
    public player player;
    int attack;
    bool col_target = false;
 
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
        if (col_target == true)
        {
            if (hp_Orc_Wolf <= 0)
            {
                timeDeath = timeDeath + Time.deltaTime;
                if (timeDeath >= 0.2f)
                {

                    Destroy(gameObject);
                    //Instantiate(hp_potion, tr.position, tr.rotation);
                    king.Troll = king.Troll - 1;
                }
                anim.SetFloat("death", 1f);
            }
            // Debug.Log(NavMeshAgent.Warp);
            if (Vector3.Distance(tr.position, target.transform.position) < 7f)
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
                if (cooldown >= 6f)
                {
                    //Debug.Log("a");

                    player = col.gameObject.GetComponent<player>();
                    player.hp_Player = player.hp_Player - 20;
                    cooldown = 0;
                }
            }
        }

    }


}









