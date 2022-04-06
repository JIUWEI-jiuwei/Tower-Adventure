using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 挂在第二关怪物循声者身上
/// 实现功能：怪物自动进行格子移动，并且追踪player
/// 实现了怪物追踪石头落下的位置并徘徊3s然后继续追逐玩家的功能
/// </summary>
public class XunShengZhe_monster : MonoBehaviour
{
    /// <summary>player的位置 </summary>
    public Transform playerpos;
    /// <summary>触发怪物移动的门 </summary>
    //public GameObject eDoor;
    /// <summary>怪物自己的位置 </summary>
    public Vector3 enemypos;
    /// <summary>怪物是否开始追踪player </summary>
    private bool seePlayer = true;
    /// <summary>格子移动间隔时间 </summary>
    public float restTime = 1f;
    /// <summary>计时器 </summary>
    public float restTimer = 0;
    /// <summary>怪物徘徊在石头的时间 </summary>
    public float restTime2 = 3f;
    /// <summary>计时器 </summary>
    public float restTimer2 = 0;
    /// <summary>怪物初始延迟启动的时间 </summary>
    public float startMove_m = 3f;
    public GameObject player_;


    // Start is called before the first frame update
    void Start()
    {

      

    }

    // Update is called once per frame
    void Update()
    {
        //当门是用trigger来处理的时候，即与DoorTest脚本配合使用时
       //if (eDoor.GetComponent<Collider2D>().isTrigger == true)//启动门被打开，判定开启
       //{
       //    seePlayer = true;
       //}

        

    }
    private void FixedUpdate()
    {
        Invoke("MonsterrMove", startMove_m);//延迟调用怪物移动代码
    }
    /// <summary>
    /// 怪物移动方法：优先向轴距离比较大的方向移动，如果X轴距离大，就先向X轴移动
    /// 思路：得到怪物位置vector3→开启判定→获取怪物到player的向量→获取分向量X和Y→
    /// X优先时，判定X有无碰撞体，若无，则x++，若有，则转向Y→若Y无，则y++，若Y也有，则原地待命→Y轴与X轴一样
    /// 
    /// 此处将门和墙都设置在Layer 9，因此怪物无法实现开门操作，会同时被门和墙阻碍
    /// </summary>
    void MonsterrMove()
    {
        transform.position = enemypos;//将怪物的初始位置赋值给怪物的position，将position转化成vector3
        restTimer += Time.deltaTime;//restTimer会不断增加deldatime其实是每一帧（每一次update方法调用）所经过的时间
        if (restTimer < restTime)
            return;//如果休息时间不够，直接返回

        if (seePlayer)//开启判定，怪物开始追踪player
        {
            Vector2 currDir = playerpos.transform.position - transform.position; //敌人看向玩家的向量，该向量从怪物指向player
            Vector2 currDirX = new Vector2(currDir.x, 0);//向量的X轴方向
            Vector2 currDirY = new Vector2(0, currDir.y);//向量的Y轴方向

            if (StoneSpaceNum.stonePos!=null)
            {
                
                Debug.Log("开始扔石头");
                currDir = StoneSpaceNum.stonePos - transform.position;
                if (Mathf.Abs(currDir.x) >= Mathf.Abs(currDir.y))//当X轴距离大于Y轴距离，此处采用绝对值    1、X轴方向
                {
                    if (!Physics2D.Raycast(transform.position, currDirX, 1.5f, 1 << 8))//1.1 X轴无碰撞体 ，从怪物发射射线，（原点，向量方向，射线长度，碰撞检测层级），TRUE的话有碰撞体，FALSE无碰撞体
                                                                                       //注意：该函数射线判定的是碰撞体，即设置为trigger依然能够检测到，因为碰撞体依然存在
                    {

                        enemypos += new Vector3(1.5f * currDir.x / Mathf.Abs(currDir.x), 0f, 0f);//怪物向X轴移动单位距离，x++
                        restTimer = 0;

                        //Debug.DrawLine(transform.position, currDirX);
                        Debug.Log("x");
                    }

                    else//1.2 X轴有碰撞体
                    {
                        if (!Physics2D.Raycast(transform.position, currDirY, 1.5f, 1 << 8))//1.2.1 Y轴无碰撞体
                        {
                            enemypos += new Vector3(0f, 1.5f * currDir.y / Mathf.Abs(currDir.y), 0f);//y++
                            restTimer = 0;
                            Debug.Log("x001");
                        }

                        else//1.2.2 Y轴有碰撞体
                        {
                            restTimer = 0;
                            enemypos += Vector3.zero;//原地静止
                            Debug.Log("x000");
                        }
                    }

                }
                if (Mathf.Abs(currDir.y) > Mathf.Abs(currDir.x))//当X轴距离大于Y轴距离，此处采用绝对值    2、Y轴方向
                {
                    if (!Physics2D.Raycast(transform.position, currDirY, 1.5f, 1 << 8))//2.1 Y轴无碰撞体
                    {

                        Debug.Log("y");
                        enemypos += new Vector3(0f, 1.5f * currDir.y / Mathf.Abs(currDir.y), 0f);//y++
                        restTimer = 0;
                    }

                    else//2.2 Y轴有碰撞体
                    {
                        if (!Physics2D.Raycast(transform.position, currDirX, 1.5f, 1 << 8))//2.2.1 X轴无碰撞体
                        {
                            enemypos += new Vector3(1.5f * currDir.x / Mathf.Abs(currDir.x), 0f, 0f);//x++
                            restTimer = 0;
                            Debug.Log("y01");
                        }

                        else//2.2.2 X轴有碰撞体
                        {
                            restTimer = 0;
                            enemypos += Vector3.zero;//原地静止
                            Debug.Log("y000");
                        }
                    }
                }
                if(Vector3.Distance(transform.position, StoneSpaceNum.stonePos) < 0.1f)//怪物追上石头
                {
                   
                    
                    Invoke("TransformPlayer", 3.5f);
                }

            }
            else
            {
                if (Mathf.Abs(currDir.x) >= Mathf.Abs(currDir.y))//当X轴距离大于Y轴距离，此处采用绝对值    1、X轴方向
                {
                    if (!Physics2D.Raycast(transform.position, currDirX, 1.5f, 1 << 8))//1.1 X轴无碰撞体 ，从怪物发射射线，（原点，向量方向，射线长度，碰撞检测层级），TRUE的话有碰撞体，FALSE无碰撞体
                                                                                       //注意：该函数射线判定的是碰撞体，即设置为trigger依然能够检测到，因为碰撞体依然存在
                    {

                        enemypos += new Vector3(1.5f * currDir.x / Mathf.Abs(currDir.x), 0f, 0f);//怪物向X轴移动单位距离，x++
                        restTimer = 0;

                        //Debug.DrawLine(transform.position, currDirX);
                        Debug.Log("x");
                    }

                    else//1.2 X轴有碰撞体
                    {
                        if (!Physics2D.Raycast(transform.position, currDirY, 1.5f, 1 << 8))//1.2.1 Y轴无碰撞体
                        {
                            enemypos += new Vector3(0f, 1.5f * currDir.y / Mathf.Abs(currDir.y), 0f);//y++
                            restTimer = 0;
                            Debug.Log("x001");
                        }

                        else//1.2.2 Y轴有碰撞体
                        {
                            restTimer = 0;
                            enemypos += Vector3.zero;//原地静止
                            Debug.Log("x000");
                        }
                    }

                }
                if (Mathf.Abs(currDir.y) > Mathf.Abs(currDir.x))//当X轴距离大于Y轴距离，此处采用绝对值    2、Y轴方向
                {
                    if (!Physics2D.Raycast(transform.position, currDirY, 1.5f, 1 << 8))//2.1 Y轴无碰撞体
                    {

                        Debug.Log("y");
                        enemypos += new Vector3(0f, 1.5f * currDir.y / Mathf.Abs(currDir.y), 0f);//y++
                        restTimer = 0;
                    }

                    else//2.2 Y轴有碰撞体
                    {
                        if (!Physics2D.Raycast(transform.position, currDirX, 1.5f, 1 << 8))//2.2.1 X轴无碰撞体
                        {
                            enemypos += new Vector3(1.5f * currDir.x / Mathf.Abs(currDir.x), 0f, 0f);//x++
                            restTimer = 0;
                            Debug.Log("y01");
                        }

                        else//2.2.2 X轴有碰撞体
                        {
                            restTimer = 0;
                            enemypos += Vector3.zero;//原地静止
                            Debug.Log("y000");
                        }
                    }
                }
            }
            



            //Collider2D[] aa = Physics2D.OverlapCircleAll(transform.position, 1f);//检测一个圆内有几个碰撞体
            //
            //if (aa.Length == 4)//碰撞体的个数
            //{
            //    transform.position = transform.position;
            //}

            //两种方法实现怪物自动开门
            //1、设置射线检测，返回碰撞体，这种方法只能通过创建销毁预制体来进行，单纯的trigger设置不可以
            //2、启用协程，获取空物体下的所有子物体，将子物体代入协程
        }


    }
    
    void Destroy_door()
    {
        //对于静态字段，可直接用类引用
        //对于非静态字段，需要使用单例来引用
        //二者的共同点在于：字段都需要是public
        Destroy(DoorPrefabs.instance.a);
        Debug.Log("摧毁门2");
    }
    void TransformPlayer()
    {
        StoneSpaceNum.stonePos = playerpos.transform.position;

    }

}
