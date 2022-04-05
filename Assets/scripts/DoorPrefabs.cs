using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ʵ����Ԥ����Ĵ��������٣����ٵ��ǿ�¡�����Ԥ���屾��
/// ���ڿ��������ϣ��ڸÿ������´����ŵĿ�¡��
/// </summary>
public class DoorPrefabs : MonoBehaviour
{
    /// <summary> ������Ԥ����-�� </summary>
    public GameObject door0;
    /// <summary> �ж��ſ��صı��� </summary>
    public bool isOpen = false;
    /// <summary> ���������¡�壬����destroy��ʱ��Ԥ����Ϳ��Բ���ɾ�� </summary>
    public  GameObject a ;
    /// <summary> �ж���ײ������ɴ����ķ�Χ </summary>
    private bool yes = false;
    /// <summary> ������δ�õ� </summary>
    public static DoorPrefabs instance;

    private void Awake()
    {
        instance = this;//������ʼ��Ҫ����awake��
    }
    // Start is called before the first frame update
    void Start()
    {
        a = Instantiate(door0, transform.position, transform.rotation);//ʵ����һ������
        
    }

    // Update is called once per frame
    void Update()
    {
        if (yes)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (isOpen == true)
                {
                    a = Instantiate(door0, transform.position, transform.rotation);//ʵ����һ������
                    a.transform.parent = this.transform;//����¡��������ŵ�����������
                    //Invoke("IsClosed", 3f);
                    isOpen = false;
                    Debug.Log("����");
                }
                else if (isOpen == false)
                {
                    Destroy(a);//ɾ�����ǿ�¡��a������Ԥ���屾����˿��Բ���ʵ�����µ�����
                    //door0.gameObject.SetActive(false);
                    //Invoke("IsOpen", 3f);
                    isOpen = true;
                    Debug.Log("����");
                }
            }
        }
    }
    /// <summary>
    /// ����д�������������������ײ���������ſ��ز���ֵ��
    /// ʵ��������������ײ�����ֻ�ж��Ƿ������Դ����ķ�Χ����Update���������İ������
    /// ��ΪOnTriggerEnter2D��ÿ��һ��ʱ��ִ�У�������ÿִ֡�еģ��е�����fixupdate
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "test")
        {
            yes = true;

        }
 
    }
    /// <summary>
    /// ����뿪�ж���Ϊ�˹��ɱջ���ʵ�ֵ�������ļ����ײ������ȫ������������������ͱ����yes
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "test")
        {
            yes = false;

        }
    }



}
