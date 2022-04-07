using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 将脚本挂在door上
/// 实现功能：门的打开和关闭→颜色的透明度变化
/// 函数：协程+OnTriggerStay2D
/// 当前：禁用
/// </summary>
public class DoorTest : MonoBehaviour
{

    //设置渐变的时间
    /// <summary>颜色消失的协程的时间_玩家关闭门 </summary>
    public float timeCout;
    /// <summary>颜色重现的协程的时间_玩家打开门 </summary>
    public float timeCout2 = 0;
    /// <summary>怪物打开门的协程的时间 </summary>
    public float m_timeCout = 3f;

    private void Update()
    {


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "test")//player.test
        {
            
            if (this.gameObject.GetComponent<Collider2D>().isTrigger == false)//door is closed
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    StartCoroutine(ChangeFormTime(timeCout));//player open the door
                    Debug.Log("00");
                }
                

            }
            if (this.gameObject.GetComponent<Collider2D>().isTrigger == true)//door is open
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    StartCoroutine(ChangeFormTime2(timeCout2));//player close the door
                    Debug.Log("11");
                }

            }

            
        }
        
    }
    //开启协程物体开始渐变
    IEnumerator ChangeFormTime(float _timeCout)
    {
        while (_timeCout > 0)
        {
            
            _timeCout -= Time.deltaTime;//倒计时
            if (this.GetComponent<Renderer>().material.color.a > 0)
            {
                this.gameObject.GetComponent<Renderer>().material.color = new Color(//获取renderer里面的color
                    this.GetComponent<Renderer>().material.color.r,
                    this.GetComponent<Renderer>().material.color.g,
                    this.GetComponent<Renderer>().material.color.b,
                    //会根据你输入的时间进行渐变
                    this.GetComponent<Renderer>().material.color.a - Time.deltaTime / timeCout);//透明度alfa 随着时间降低到0
                yield return new WaitForSeconds(0.01f);//等待0.01s后返回
            }
        }
        
        //this.gameObject.SetActive(false);
        this.gameObject.GetComponent<Collider2D>().isTrigger = true;//协程继续，勾选trigger
        Debug.Log("协程1结束");

        //虽然是透明的但是还在渲染，为了减少Drawcall，可以
        //1.隐藏物体2.摧毁物体3.移除到摄像机拍不到的地方
    }
    IEnumerator ChangeFormTime2(float _timeCout)
    {
        while (_timeCout <= 0.5)
        {
            //倒计时
            _timeCout += Time.deltaTime;
            if (this.GetComponent<Renderer>().material.color.a <= 1)
            {
                this.gameObject.GetComponent<Renderer>().material.color = new Color(
                    this.GetComponent<Renderer>().material.color.r,
                    this.GetComponent<Renderer>().material.color.g,
                    this.GetComponent<Renderer>().material.color.b,
                    //会根据你输入的时间进行渐变
                    this.GetComponent<Renderer>().material.color.a + Time.deltaTime);
                //Debug.Log(this.GetComponent<Renderer>().material.color.a);
                yield return new WaitForSeconds(0.01f);
            }
        }
        //虽然是透明的但是还在渲染，为了减少Drawcall，可以
        //1.隐藏物体2.摧毁物体3.移除到摄像机拍不到的地方

        this.gameObject.GetComponent<Collider2D>().isTrigger = false;
        Debug.Log("协程2结束");
    }
}