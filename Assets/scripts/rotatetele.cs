﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class rotatetele : MonoBehaviour


{
	public float speed = 10f;
    void Update()
    {
        // Rotate the object around its local X axis at 1 degree per second
        transform.Rotate(Vector3.right * Time.deltaTime * speed);

        // ...also rotate around the World's Y axis
       // transform.Rotate(Vector3.up * Time.deltaTime, Space.World);
    }
}