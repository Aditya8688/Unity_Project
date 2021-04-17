using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_rotation : MonoBehaviour
{
    

public float _rotationSpeed = 15f;

void Update () {

    // Rotation on y axis
    transform.Rotate (0, _rotationSpeed * Time.deltaTime, 0);
}
}
