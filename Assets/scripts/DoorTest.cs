using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ű�����door��
/// ʵ�ֹ��ܣ��ŵĴ򿪺͹رա���ɫ��͸���ȱ仯
/// ������Э��+OnTriggerStay2D
/// ��ǰ������
/// </summary>
public class DoorTest : MonoBehaviour
{

    //���ý����ʱ��
    /// <summary>��ɫ��ʧ��Э�̵�ʱ��_��ҹر��� </summary>
    public float timeCout;
    /// <summary>��ɫ���ֵ�Э�̵�ʱ��_��Ҵ��� </summary>
    public float timeCout2 = 0;
    /// <summary>������ŵ�Э�̵�ʱ�� </summary>
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
    //����Э�����忪ʼ����
    IEnumerator ChangeFormTime(float _timeCout)
    {
        while (_timeCout > 0)
        {
            
            _timeCout -= Time.deltaTime;//����ʱ
            if (this.GetComponent<Renderer>().material.color.a > 0)
            {
                this.gameObject.GetComponent<Renderer>().material.color = new Color(//��ȡrenderer�����color
                    this.GetComponent<Renderer>().material.color.r,
                    this.GetComponent<Renderer>().material.color.g,
                    this.GetComponent<Renderer>().material.color.b,
                    //������������ʱ����н���
                    this.GetComponent<Renderer>().material.color.a - Time.deltaTime / timeCout);//͸����alfa ����ʱ�併�͵�0
                yield return new WaitForSeconds(0.01f);//�ȴ�0.01s�󷵻�
            }
        }
        
        //this.gameObject.SetActive(false);
        this.gameObject.GetComponent<Collider2D>().isTrigger = true;//Э�̼�������ѡtrigger
        Debug.Log("Э��1����");

        //��Ȼ��͸���ĵ��ǻ�����Ⱦ��Ϊ�˼���Drawcall������
        //1.��������2.�ݻ�����3.�Ƴ���������Ĳ����ĵط�
    }
    IEnumerator ChangeFormTime2(float _timeCout)
    {
        while (_timeCout <= 0.5)
        {
            //����ʱ
            _timeCout += Time.deltaTime;
            if (this.GetComponent<Renderer>().material.color.a <= 1)
            {
                this.gameObject.GetComponent<Renderer>().material.color = new Color(
                    this.GetComponent<Renderer>().material.color.r,
                    this.GetComponent<Renderer>().material.color.g,
                    this.GetComponent<Renderer>().material.color.b,
                    //������������ʱ����н���
                    this.GetComponent<Renderer>().material.color.a + Time.deltaTime);
                //Debug.Log(this.GetComponent<Renderer>().material.color.a);
                yield return new WaitForSeconds(0.01f);
            }
        }
        //��Ȼ��͸���ĵ��ǻ�����Ⱦ��Ϊ�˼���Drawcall������
        //1.��������2.�ݻ�����3.�Ƴ���������Ĳ����ĵط�

        this.gameObject.GetComponent<Collider2D>().isTrigger = false;
        Debug.Log("Э��2����");
    }
}