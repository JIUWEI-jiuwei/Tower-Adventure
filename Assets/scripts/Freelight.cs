using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����Freelight����
/// ���ݰ�����ת����
/// ʵ��Ч�������ֻ�ܿ���������������
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
            //freelight.gameObject.transform.Rotate(new Vector3(0, 0, -90));//rotateʵ�ֵ�����ת�Ķ���
            transform.rotation = Quaternion.Euler(0, 0, -90);//rotationʵ�ֵ�����ת��λ��
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
