using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float mouseSensitivity = 200f;//滑鼠靈敏度

    public Transform playerpos;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //取得滑鼠移動
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //以玩家為中心旋轉
        transform.RotateAround(playerpos.transform.position, transform.right, -mouseY);
        transform.RotateAround(playerpos.transform.position, Vector3.up, mouseX);
    }
}
