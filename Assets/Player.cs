using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController controller;
    public Camera mainCamera;
    float speed = 5f;//移動速度
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");//input水平
        float v = Input.GetAxis("Vertical");//input垂直

        if(h != 0 || v != 0)
        {
            //取得攝影機的角度
            Vector3 target = new Vector3(h, 0, v);
            float y = mainCamera.transform.rotation.eulerAngles.y;
            target = Quaternion.Euler(0, y ,0) * target;

            //面向移動方向
            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation * Quaternion.Euler(0, y ,0), 0.2f);

            //玩家移動
            controller.Move(target * Time.deltaTime * speed);
        }
    }
}
