using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followChild : MonoBehaviour
{

    [SerializeField] Transform playerMesh;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = playerMesh.position;
    }
}
