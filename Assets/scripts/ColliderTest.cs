using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <summary>
/// ����player.test����Ľű�
/// �ƶ�test��λ��
/// ����ͬ�ķ��������test��λ���Ƶ���ͬ�ķ��򣬱��ڼ���ŵĴ���
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
            GetComponent<Transform>().localPosition = new Vector2(3.3f,-2.5f);//�ı��������λ��
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
//ԭ����ʵ�ַ����Լ����о��Ĵ��룺��ת
//������ת��ŷ������ת
//��Ԫ��
//
//
//
//
//
//
//