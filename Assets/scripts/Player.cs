using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// ʵ�ֹ��ܣ���ɫ���ո����ƶ�
/// ����player����
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>player��λ�� </summary>
    public Vector2 targetPos;
    /// <summary>player�ĸ��� </summary>
    private Rigidbody2D rigid;
    /// <summary>lerp��ƽ���� </summary>
    public float smoothing = 4;
    /// <summary>���ʱ�� </summary>
    public float restTime = 0.3f;
    /// <summary>��ʱ�� </summary>
    public float restTimer = 0;
    /// <summary> ��player���stand����</summary>
    public Animator stand;
    /// <summary> ��ɫ����</summary>
    public float stepSize;
    /// <summary> ��Ʒ��������ʯͷ</summary>
    public GameObject stone1;
    public GameObject stone2;
    public GameObject stone3;
    /// <summary> �������û��Կ�׵��ı� </summary>
    public Text text_TiXing;
    /// <summary> Կ������ </summary>
    public GameObject yaoshi;
    /// <summary> ��Ʒ����Կ�� </summary>
    public GameObject yaoshi_wupin;
    /// <summary> �ж��Ƿ��õ�Կ�� </summary>
    public bool isOk = false;
    /// <summary> �ж��Ƿ��õ�Կ�� </summary>
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
    private void FixedUpdate()//����fixedupdate���棬��ֹ��ͷ����
    {
        //����fixedupdate��ÿ��һ��ʱ����ã�����û�а취��������ʵʱ��Ӧ������

        //  rigidbody.MovePosition(Vector2.Lerp(transform.position, targetPos, smoothing * Time.deltaTime));//lerp��ֵ��ʹ�ƶ�ƽ��
        rigid.MovePosition(targetPos);//��lerp���ƶ���˲�ơ�

        
        restTimer += Time.fixedDeltaTime;//restTimer�᲻������deldatime��ʵ��ÿһ֡��ÿһ��update�������ã���������ʱ��
        if (restTimer < restTime)
            return;//�����Ϣʱ�䲻����������Ŀ��λ�ã�ֱ�ӷ���

        //��Ϣʱ�����֮��
        float h = Input.GetAxisRaw("Horizontal");//ֻ�ܷ���1 -1 0
        float v = Input.GetAxisRaw("Vertical");
        if (h > 0)
        {
            v = 0;
        }

        if (h != 0 || v != 0)//�������ⷽ��ļ�����ɫ�����÷����ƶ����������򲻿���ͬʱ�ƶ�
        {
            targetPos += new Vector2(h * stepSize, v * stepSize);
            restTimer = 0;//��ʱ������Ϊ0��ʵ�ָ����ƶ��ļ����
            stand.SetTrigger("walk");
        }
        else
        {
            stand.SetTrigger("Fwalk");
        }

    }

    /// <summary>
    /// ����ɫ����ʯͷ
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "stone")
        {
            if (StoneSpaceNum.stoneSpace >=0)//������Ʒ�����пռ�
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
                //������һ�� TODO������

                //text_win.text = "��" + num_layer + "��";
                //Invoke("NextLayer", 3f);
                SceneManager.LoadScene(1);

            }
            else
            {
                text_TiXing.text = "�Ȼ�ȡԿ�ף�";
                Invoke("DestroyText", 2.5f);
                Debug.Log("δȡ��Կ��");
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
                //������һ�� TODO������

                //text_win.text = "��" + num_layer + "��";
                //Invoke("NextLayer", 3f);
                SceneManager.LoadScene(5);

            }
            else
            {
                text_TiXing.text = "�Ȼ�ȡԿ�ף�";
                Invoke("DestroyText", 2.5f);
                Debug.Log("δȡ��Կ��");
            }

        }
        



    }
    void DestroyText()
    {
        Destroy(text_TiXing);
    }
    /// <summary>
    /// ��Ʒ��ʯͷ����ʾ
    /// </summary>
    void StoneSpaceNumber()
    {
        if (StoneSpaceNum.stoneSpace == 3)//��������λ
        {
            stone1.gameObject.SetActive(false);
            stone2.gameObject.SetActive(false);
            stone3.gameObject.SetActive(false);
        }
        if (StoneSpaceNum.stoneSpace == 2)//��������λ
        {
            stone1.gameObject.SetActive(true);
            stone2.gameObject.SetActive(false);
            stone3.gameObject.SetActive(false);
        }
        if (StoneSpaceNum.stoneSpace == 1)//��һ����λ
        {
            stone3.gameObject.SetActive(false);
            stone2.gameObject.SetActive(true);
            stone1.gameObject.SetActive(true);
        }
        if (StoneSpaceNum.stoneSpace == 0)//�������λ
        {
            stone3.gameObject.SetActive(true);
            stone2.gameObject.SetActive(true);
            stone1.gameObject.SetActive(true);
        }
    }
}

