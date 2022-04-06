using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <summary>
/// 挂在player.test上面的脚本
/// 移动test的位置
/// 按不同的方向键，将test的位置移到不同的方向，便于检测门的存在
/// </summary>
public class ColliderTest : MonoBehaviour
{
   
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Transform>().localPosition = new Vector2(3.3f,-2.5f);//改变子物体的位置
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Transform>().localPosition = new Vector2(0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Transform>().localPosition = new Vector2(0f, -5.8f);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Transform>().localPosition = new Vector2(-2.8f,-2.5f);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        
        
        
    }
    
   
    
}
//原本的实现方法以及待研究的代码：旋转
//矩阵旋转、欧拉角旋转
//四元数
//
//
//
//
//
//
//