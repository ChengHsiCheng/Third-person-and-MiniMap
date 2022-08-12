# 第三人稱視角 及 小地圖
## 第三人稱視角
新增一個空物件取名為PlayerPos 把Main拖曳為其子物件

![GITHUB](https://i.imgur.com/eJlvJFA.png)

MainCamera
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float mouseSensitivity = 200f;//滑鼠靈敏度
    public Transform playerpos;

    void Update()
    {
        //取得滑鼠移動
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //以PlayerPos為中心旋轉
        transform.RotateAround(playerpos.transform.position, transform.right, -mouseY);
        transform.RotateAround(playerpos.transform.position, Vector3.up, mouseX);
    }
}
```
把playerpos設定為PlayerPos

![GITHUB](https://i.imgur.com/Uu2fZHG.png)

PlayerPos
```C#
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
```
把player設定為玩家

例: ![GITHUB](https://i.imgur.com/XM9NIM4.png)

