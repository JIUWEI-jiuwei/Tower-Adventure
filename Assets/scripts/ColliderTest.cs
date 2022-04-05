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
    /// <summary> �������û��Կ�׵��ı� </summary>
    public Text text_TiXing;
    /// <summary> Կ������ </summary>
    public GameObject yaoshi;
    /// <summary> ��Ʒ����Կ�� </summary>
    public GameObject yaoshi_wupin;
    /// <summary> �ж��Ƿ��õ�Կ�� </summary>
    public bool isOk=false;
    

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
        }
    }
    void DestroyText()
    {
        Destroy(text_TiXing);
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