using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    [SerializeField] private float speed;

    private Rigidbody rb;

    float xInput;
    float zInput;

    private void Awake()
    {
        rb = GetComponent <Rigidbody> ();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
    }

  

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(xInput * speed * Time.fixedDeltaTime, 0, -zInput * speed * Time.fixedDeltaTime),ForceMode.Force);
    }

    private void MyInput()
    {
        zInput = Input.GetAxisRaw("Horizontal");
        xInput = Input.GetAxisRaw("Vertical");
    }
}
