using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        //跟隨玩家
        transform.position = player.position;
    }
}
