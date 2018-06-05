using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerU : MonoBehaviour
{
    //public Transform tr1;
    Transform tr;
    float v;
    float h;
    Rigidbody rb;
    public GameObject player; // тут объект игрока
    private Vector3 offset;
    //public Transform target;
    //public float smooth= 5.0f;

    // Use this for initialization
    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        offset = transform.position - player.transform.position;
        //transform.position = Vector3.Lerp (transform.position, target.position + offset, Time.deltaTime * smooth);
    }

    // Update is called once per frame
    void Update()
    {

        tr.position = player.transform.position + offset;
        //rb.AddForce (force1*1000f );

    }
}
