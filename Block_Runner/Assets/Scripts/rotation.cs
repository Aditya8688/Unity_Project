using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public float turnspeed = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        transform.Rotate(0,-0.5f,0);

        if (Input.GetKey(KeyCode.RightArrow))
        transform.Rotate(Vector3.up, turnspeed * Time.deltaTime);       
    }
}
