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

在玩家上增加CharacterController

![GITHUB](https://i.imgur.com/A86mBtb.png)

Player
```C#
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

```


## 小地圖
在Hierarchy新增一個Camera取名為MiniMapCamera

![GITHUB](https://i.imgur.com/GI5YbCx.png)

在Project新增一個Render Texture取名為MiniMapTex

![GITHUB](https://i.imgur.com/nVvk4HK.png)

在Hierarchy新增一個Raw Image取名為MiniMap
![GITHUB](https://i.imgur.com/J1JT7pZ.png)

把MiniMap設定到合適的大小和位置

![GITHUB](https://i.imgur.com/4AXcnEF.png)

![GITHUB](https://i.imgur.com/DY1MdB4.png)

把MinimapTex設定到合適的大小

![GITHUB](https://i.imgur.com/CrvZoZf.png)

把MiniMapCamera的Target Texture設定為MiniMapTex

![GITHUB](https://i.imgur.com/YSu85L7.png)

把MiniMap的Texture設定為MiniMapTex

![GITHUB](https://i.imgur.com/BOU5u9w.png)

MiniMapCamera
```C#
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

```
把player設定為玩家 把mainCamera設定為Main Camera

![GITHUB](https://i.imgur.com/mbTIav8.png)



