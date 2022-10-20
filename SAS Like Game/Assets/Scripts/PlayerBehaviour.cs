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
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        

        if (Physics.Raycast(mouseRay,out RaycastHit hit,Mathf.Infinity))
        {
            Vector3 dir = (transform.position - hit.point).normalized;
            transform.rotation = Quaternion.LookRotation(dir);
        }
        rb.AddForce(new Vector3(xInput * speed * Time.fixedDeltaTime, 0, -zInput * speed * Time.fixedDeltaTime),ForceMode.Force);
    }

    private void MyInput()
    {
        zInput = Input.GetAxisRaw("Horizontal");
        xInput = Input.GetAxisRaw("Vertical");
    }
}
