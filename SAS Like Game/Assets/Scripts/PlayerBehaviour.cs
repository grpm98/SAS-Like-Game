using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Movement Settings")]

    [SerializeField] private Transform playerTransform;
    [SerializeField] private float speed;
    private Rigidbody rb;
    private float xInput;
    private float zInput;

    [Header("Attack Settings")]

    [SerializeField] private float cooldown;
    [SerializeField] private Transform barrelPos;
    [SerializeField] private GameObject bullet;


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
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        

        if (Physics.Raycast(mouseRay,out RaycastHit hit,Mathf.Infinity))
        {
            Vector3 dir = (transform.position - hit.point).normalized;
            transform.rotation = Quaternion.LookRotation(new Vector3(dir.x,0, dir.z));
        }
        rb.AddForce(new Vector3(xInput * speed * Time.fixedDeltaTime, 0, -zInput * speed * Time.fixedDeltaTime),ForceMode.Force);
    }

    private void MyInput()
    {
        zInput = Input.GetAxisRaw("Horizontal");
        xInput = Input.GetAxisRaw("Vertical");

        if (cooldown <= 0 && Input.GetMouseButton(0))
        {
            Attack();
        }

    }

    private void Attack()
    {
        Instantiate(bullet,barrelPos.position,barrelPos.rotation);
    }
}
