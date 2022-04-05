using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 实现了预制体的创建和销毁，销毁的是克隆体而非预制体本身
/// 挂在空物体身上，在该空物体下创建门的克隆体
/// </summary>
public class DoorPrefabs : MonoBehaviour
{
    /// <summary> 创建的预制体-门 </summary>
    public GameObject door0;
    /// <summary> 判断门开关的变量 </summary>
    public bool isOpen = false;
    /// <summary> 用来储存克隆体，这样destroy的时候预制体就可以不被删掉 </summary>
    public  GameObject a ;
    /// <summary> 判断碰撞检测进入可触发的范围 </summary>
    private bool yes = false;
    /// <summary> 单例，未用到 </summary>
    public static DoorPrefabs instance;

    private void Awake()
    {
        instance = this;//单例初始化要放在awake中
    }
    // Start is called before the first frame update
    void Start()
    {
        a = Instantiate(door0, transform.position, transform.rotation);//实例化一个物体
        
    }

    // Update is called once per frame
    void Update()
    {
        if (yes)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (isOpen == true)
                {
                    a = Instantiate(door0, transform.position, transform.rotation);//实例化一个物体
                    a.transform.parent = this.transform;//将克隆出的物体放到父物体下面
                    //Invoke("IsClosed", 3f);
                    isOpen = false;
                    Debug.Log("关门");
                }
                else if (isOpen == false)
                {
                    Destroy(a);//删除的是克隆体a而不是预制体本身，因此可以不断实例化新的物体
                    //door0.gameObject.SetActive(false);
                    //Invoke("IsOpen", 3f);
                    isOpen = true;
                    Debug.Log("开门");
                }
            }
        }
    }
    /// <summary>
    /// 换个写法，本来我想的是在碰撞检测里控制门开关布尔值。
    /// 实际你可以在这个碰撞检测里只判断是否进入可以触发的范围，在Update里做真正的按键检测
    /// 因为OnTriggerEnter2D是每隔一定时间执行，而不是每帧执行的，有点类似fixupdate
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "test")
        {
            yes = true;

        }
 
    }
    /// <summary>
    /// 这个离开判定是为了构成闭环，实现单个物体的检测碰撞，否则全部带有这个代码的物体就变成了yes
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "test")
        {
            yes = false;

        }
    }



}
