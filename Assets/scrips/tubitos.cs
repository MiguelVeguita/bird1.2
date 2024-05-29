using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tubitos : MonoBehaviour
{
    public float velo;

    void Start()
    {

    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x + (velo * Time.deltaTime), transform.position.y, transform.position.z);
        if (transform.position.x >= 23)
        {
            transform.position = new Vector3(-20, transform.position.y, transform.position.z);
        }
    }


}
