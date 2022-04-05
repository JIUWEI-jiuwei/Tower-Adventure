using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
            targetPos += new Vector2(h * 2f, v * 2f);
            restTimer = 0;//��ʱ������Ϊ0��ʵ�ָ����ƶ��ļ����
            stand.SetTrigger("walk");
        }
        else
        {
            stand.SetTrigger("Fwalk");
        }

    }
}

