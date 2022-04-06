using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 实现功能：角色按照格子移动
/// 挂在player身上
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>player的位置 </summary>
    public Vector2 targetPos;
    /// <summary>player的刚体 </summary>
    private Rigidbody2D rigid;
    /// <summary>lerp的平滑度 </summary>
    public float smoothing = 4;
    /// <summary>间隔时间 </summary>
    public float restTime = 0.3f;
    /// <summary>计时器 </summary>
    public float restTimer = 0;
    /// <summary> 给player添加stand动画</summary>
    public Animator stand;
    /// <summary> 角色步长</summary>
    public float stepSize;
    /// <summary> 物品栏的三个石头</summary>
    public GameObject stone1;
    public GameObject stone2;
    public GameObject stone3;
    /// <summary> 提醒玩家没拿钥匙的文本 </summary>
    public Text text_TiXing;
    /// <summary> 钥匙物体 </summary>
    public GameObject yaoshi;
    /// <summary> 物品栏的钥匙 </summary>
    public GameObject yaoshi_wupin;
    /// <summary> 判断是否拿到钥匙 </summary>
    public bool isOk = false;
    /// <summary> 判断是否拿到钥匙 </summary>
    public bool isOk2 = false;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        stand = GetComponent<Animator>();

        StoneSpaceNumber();
        Debug.Log(StoneSpaceNum.stoneSpace);
    }
    private void FixedUpdate()//放在fixedupdate里面，防止镜头抖动
    {
        //但是fixedupdate是每隔一段时间调用，所以没有办法做到按键实时响应，很像

        //  rigidbody.MovePosition(Vector2.Lerp(transform.position, targetPos, smoothing * Time.deltaTime));//lerp插值，使移动平滑
        rigid.MovePosition(targetPos);//无lerp，移动是瞬移。

        
        restTimer += Time.fixedDeltaTime;//restTimer会不断增加deldatime其实是每一帧（每一次update方法调用）所经过的时间
        if (restTimer < restTime)
            return;//如果休息时间不够，不更新目标位置，直接返回

        //休息时间充足之后
        float h = Input.GetAxisRaw("Horizontal");//只能返回1 -1 0
        float v = Input.GetAxisRaw("Vertical");
        if (h > 0)
        {
            v = 0;
        }

        if (h != 0 || v != 0)//按下任意方向的键，角色就往该方向移动，两个方向不可能同时移动
        {
            targetPos += new Vector2(h * stepSize, v * stepSize);
            restTimer = 0;//将时间设置为0，实现格子移动的间隔感
            stand.SetTrigger("walk");
        }
        else
        {
            stand.SetTrigger("Fwalk");
        }

    }

    /// <summary>
    /// 当角色碰到石头
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "stone")
        {
            if (StoneSpaceNum.stoneSpace >=0)//加入物品栏还有空间
            {
                
                Destroy(collision.gameObject);
                StoneSpaceNum.stoneSpace--;
                Debug.Log("-1");

            }


        }
        if (collision.tag == "win")
        {
            if (isOk)
            {
                //进入下一关 TODO。。。

                //text_win.text = "第" + num_layer + "层";
                //Invoke("NextLayer", 3f);
                SceneManager.LoadScene(1);

            }
            else
            {
                text_TiXing.text = "先获取钥匙！";
                Invoke("DestroyText", 2.5f);
                Debug.Log("未取得钥匙");
            }

        }
        if (collision.tag == "yaoshi")
        {
            yaoshi.gameObject.SetActive(false);
            yaoshi_wupin.gameObject.SetActive(true);
            isOk = true;
            isOk2 = true;
        }
        if (collision.tag == "win2")
        {
            if (isOk2)
            {
                //进入下一关 TODO。。。

                //text_win.text = "第" + num_layer + "层";
                //Invoke("NextLayer", 3f);
                SceneManager.LoadScene(5);

            }
            else
            {
                text_TiXing.text = "先获取钥匙！";
                Invoke("DestroyText", 2.5f);
                Debug.Log("未取得钥匙");
            }

        }
        



    }
    void DestroyText()
    {
        Destroy(text_TiXing);
    }
    /// <summary>
    /// 物品栏石头的显示
    /// </summary>
    void StoneSpaceNumber()
    {
        if (StoneSpaceNum.stoneSpace == 3)//有三个空位
        {
            stone1.gameObject.SetActive(false);
            stone2.gameObject.SetActive(false);
            stone3.gameObject.SetActive(false);
        }
        if (StoneSpaceNum.stoneSpace == 2)//有两个空位
        {
            stone1.gameObject.SetActive(true);
            stone2.gameObject.SetActive(false);
            stone3.gameObject.SetActive(false);
        }
        if (StoneSpaceNum.stoneSpace == 1)//有一个空位
        {
            stone3.gameObject.SetActive(false);
            stone2.gameObject.SetActive(true);
            stone1.gameObject.SetActive(true);
        }
        if (StoneSpaceNum.stoneSpace == 0)//有零个空位
        {
            stone3.gameObject.SetActive(true);
            stone2.gameObject.SetActive(true);
            stone1.gameObject.SetActive(true);
        }
    }
}

