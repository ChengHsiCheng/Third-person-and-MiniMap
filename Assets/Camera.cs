using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float mouseSensitivity = 200f;

    public Transform playerBody;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
         //旋轉身體的視角
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //以玩家為中心旋轉
        transform.RotateAround(playerBody.transform.position, transform.right, -mouseY);
        transform.RotateAround(playerBody.transform.position, Vector3.up, mouseX);
    }
}
