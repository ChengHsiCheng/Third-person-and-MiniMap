using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    public Transform player;
    public Transform mainCamera;
    void Start()
    {
        
    }

    void Update()
    {
        //設定攝影機位置和角度
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);//玩家位置
        transform.rotation = Quaternion.Euler(90f, mainCamera.transform.eulerAngles.y, 0);//主攝影機角度
    }
}
