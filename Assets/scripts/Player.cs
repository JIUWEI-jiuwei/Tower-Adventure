using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        stand = GetComponent<Animator>();
        

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
            targetPos += new Vector2(h * 2f, v * 2f);
            restTimer = 0;//将时间设置为0，实现格子移动的间隔感
            stand.SetTrigger("walk");
        }
        else
        {
            stand.SetTrigger("Fwalk");
        }

    }
}

