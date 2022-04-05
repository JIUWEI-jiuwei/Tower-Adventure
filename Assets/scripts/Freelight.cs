using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 挂在Freelight身上
/// 根据按键旋转方向
/// 实现效果：玩家只能看到相邻两个格子
/// </summary>
public class Freelight : MonoBehaviour
{
    //public GameObject freelight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //freelight.gameObject.transform.Rotate(new Vector3(0, 0, -90));//rotate实现的是旋转的动作
            transform.rotation = Quaternion.Euler(0, 0, -90);//rotation实现的是旋转的位置
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //freelight.gameObject.transform.Rotate(new Vector3(0, 0, 0));
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //freelight.gameObject.transform.Rotate(new Vector3(0, 0, 180));
            transform.rotation = Quaternion.Euler(0, 0, 180);

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //freelight.gameObject.transform.Rotate(new Vector3(0, 0, 90));
            transform.rotation = Quaternion.Euler(0, 0, 90);

        }
    }
}
