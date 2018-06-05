
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class player : MonoBehaviour
{
    Animator anim;
    NavMeshAgent nav;
    int cdw;
    Rigidbody rb;
    float f;
    public int hp_Player = 100;
    public float Stamina = 100;
    float h;
    float v;
    public OrcWolf orcWolf;
    public troll_boss Troll;
    float cooldown;
    public int attack;
    Transform tr;
    public Image img;
    public Image img_stamina;
    public GameObject You_died;
    float startHP;
    float startStamina;
    public inventary inv;
    private AudioSource audio_attack;
    public Text mytext;
    public Text mytext2;
    public GameObject invet;
    int breaker;
    public AudioClip[] audio_player;
    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        audio_attack = GetComponent<AudioSource>();
        inv = invet.GetComponent<inventary>();


    }
    void Awake()
    {
        startHP = hp_Player;
        startStamina = Stamina;
    }
   
    void Update()
    {
        mytext.text = "HP:" + hp_Player; 
         mytext2.text = "St:" + Stamina; 

        if (hp_Player > 100)
        {
            hp_Player = 100;
        }
        if (Stamina > 100)
        {
            Stamina = 100;
        }
        if (Stamina < 0)
        {
            Stamina = 0;
        }
        if (hp_Player <= 0)
        {
            //Destroy(gameObject);
            You_died.gameObject.SetActive(true);
            inv.enabled = false;
            
        }
        //Debug.Log(hp_Player);
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        f = Input.GetAxis("Fire1");
        if (v != 0)
        {
            
            anim.SetFloat("go", 1f);
        } else {
            anim.SetFloat("go", 0);
            if(f == 0)
            {
                audio_attack.clip = audio_player[1];
                audio_attack.Play();
            }
            
        }
        cooldown = cooldown + Time.deltaTime;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 force = new Vector3 (0,0,v);
        rb.AddForce ( tr.forward * v * 800f);
        Stamina = Stamina + 0.07f;
        //rb.MovePosition(tr.position + tr.forward * v);
        Vector3 rotation = new Vector3 (0,h,0);
        tr.Rotate (rotation*3f);
        if (f != 0 && cooldown >= 1 && Stamina > 17f)
        {
            //cooldown = 0;
            anim.SetFloat("attack", 1f);
            
        }
        else
        {
            anim.SetFloat("attack", -1f);
        }

        float scaleX = hp_Player / startHP;
        img.transform.localScale = new Vector3(scaleX,1,1);

        float scaleS = Stamina / startStamina;
        img_stamina.transform.localScale = new Vector3(scaleS, 1, 1);

    }
     void OnTriggerStay(Collider col)
    {
        if (f != 0 && cooldown >= 1 && col.gameObject.tag == "orc" && Vector3.Distance(tr.position, col.transform.position) < 7f && Stamina > 17f)
        {
            orcWolf = col.gameObject.GetComponent<OrcWolf>();
            orcWolf.hp_Orc_Wolf = orcWolf.hp_Orc_Wolf - attack;


            cooldown = 0;
            cdw = 1;
            audio_attack.clip = audio_player[0];
            audio_attack.Play();
            Stamina = Stamina - 17;
        }
        else {
            orcWolf = null;
            cdw = 0;

        }
        if (f != 0 && cooldown >= 1 && col.gameObject.tag == "troll" && Vector3.Distance(tr.position, col.transform.position) < 7f && Stamina > 17f)
        {
            Troll = col.gameObject.GetComponent<troll_boss>();
            Troll.hp_Orc_Wolf = Troll.hp_Orc_Wolf - attack;


            cooldown = 0;
            cdw = 1;
            audio_attack.clip = audio_player[0];
            audio_attack.Play();
            Stamina = Stamina - 17;
        }
        else
        {
            Troll = null;
            cdw = 0;

        }

    }
    void OnCollisionStay(Collision col)
    {
          
        if(col.gameObject.tag == "heal_potion")
        {
            Destroy(col.gameObject);
            breaker = 0;
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if(breaker == 1)
                    {
                        break;
                    }
                        if(inv.items[y * 5 + x] == 0)
                        {
                            breaker = 1;
                            inv.items[y * 5 + x] = 5;
                            break;
                            
                        }
                }
            }
        }
    }

}
