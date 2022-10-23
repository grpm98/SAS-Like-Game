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
    [SerializeField] private float curTimer;
    [SerializeField] private Transform barrelPos;
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private float bulletSpeed;



    private void Awake()
    {
        rb = GetComponent <Rigidbody> ();
    }
    // Start is called before the first frame update
    void Start()
    {
        curTimer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        Timer();
    }


    private void FixedUpdate()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        

        if (Physics.Raycast(mouseRay,out RaycastHit hit,Mathf.Infinity))
        {
            Vector3 dir = (transform.position - hit.point).normalized;
            transform.rotation = Quaternion.LookRotation(new Vector3(dir.x,0, dir.z));
        }
        rb.velocity = new Vector3(xInput, 0, -zInput ).normalized * speed * Time.fixedDeltaTime;
    }

    private void MyInput()
    {
        zInput = Input.GetAxisRaw("Horizontal");
        xInput = Input.GetAxisRaw("Vertical");

        if (curTimer <= 0 & Input.GetButton("Fire1"))
        {
            Debug.Log("Running");
            Attack();
        }

    }

    private void Timer()
    {
        curTimer -= Time.deltaTime;
    }
    private void Attack()
    {
        Rigidbody bullet;
        bullet = Instantiate(bulletPrefab,barrelPos.position,barrelPos.rotation);
        bullet.AddForce(bullet.transform.TransformDirection(Vector3.forward * bulletSpeed));
        curTimer = cooldown;
    }
}
