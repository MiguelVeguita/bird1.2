using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bird : MonoBehaviour
{
    public float flapForce = 5f;
    public float rotationSpeed = 2f;
    private Rigidbody rig;
    private Quaternion initialRotation;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        initialRotation = transform.rotation; 
    }

    void Update()
    {
        veriposition();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.velocity = Vector3.zero;
            rig.AddForce(Vector3.up * flapForce, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rig.velocity = Vector3.zero;
            rig.AddForce(Vector3.down * flapForce, ForceMode.Impulse);
        }

       
        float angle = Mathf.Atan2(rig.velocity.y, rig.velocity.z) * Mathf.Rad2Deg;

        
       Quaternion targetRotation = Quaternion.Euler(initialRotation.eulerAngles.x + angle, initialRotation.eulerAngles.y, initialRotation.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
       
    }
    void veriposition()
    {
        Vector3 birdPosition = this.transform.position;

        if (birdPosition.x >= 17 || birdPosition.y <= -2 || birdPosition.y >= 17)
        {
            SceneManager.LoadScene("perder");
           // Debug.Log("aa");
        }
    }
}

