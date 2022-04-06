using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ���ڵڶ��ع���ѭ��������
/// ʵ�ֹ��ܣ������Զ����и����ƶ�������׷��player
/// ʵ���˹���׷��ʯͷ���µ�λ�ò��ǻ�3sȻ�����׷����ҵĹ���
/// </summary>
public class XunShengZhe_monster : MonoBehaviour
{
    /// <summary>player��λ�� </summary>
    public Transform playerpos;
    /// <summary>���������ƶ����� </summary>
    //public GameObject eDoor;
    /// <summary>�����Լ���λ�� </summary>
    public Vector3 enemypos;
    /// <summary>�����Ƿ�ʼ׷��player </summary>
    private bool seePlayer = true;
    /// <summary>�����ƶ����ʱ�� </summary>
    public float restTime = 1f;
    /// <summary>��ʱ�� </summary>
    public float restTimer = 0;
    /// <summary>�����ǻ���ʯͷ��ʱ�� </summary>
    public float restTime2 = 3f;
    /// <summary>��ʱ�� </summary>
    public float restTimer2 = 0;
    /// <summary>�����ʼ�ӳ�������ʱ�� </summary>
    public float startMove_m = 3f;
    public GameObject player_;


    // Start is called before the first frame update
    void Start()
    {

      

    }

    // Update is called once per frame
    void Update()
    {
        //��������trigger�������ʱ�򣬼���DoorTest�ű����ʹ��ʱ
       //if (eDoor.GetComponent<Collider2D>().isTrigger == true)//�����ű��򿪣��ж�����
       //{
       //    seePlayer = true;
       //}

        

    }
    private void FixedUpdate()
    {
        Invoke("MonsterrMove", startMove_m);//�ӳٵ��ù����ƶ�����
    }
    /// <summary>
    /// �����ƶ������������������Ƚϴ�ķ����ƶ������X�����󣬾�����X���ƶ�
    /// ˼·���õ�����λ��vector3�������ж�����ȡ���ﵽplayer����������ȡ������X��Y��
    /// X����ʱ���ж�X������ײ�壬���ޣ���x++�����У���ת��Y����Y�ޣ���y++����YҲ�У���ԭ�ش�����Y����X��һ��
    /// 
    /// �˴����ź�ǽ��������Layer 9����˹����޷�ʵ�ֿ��Ų�������ͬʱ���ź�ǽ�谭
    /// </summary>
    void MonsterrMove()
    {
        transform.position = enemypos;//������ĳ�ʼλ�ø�ֵ�������position����positionת����vector3
        restTimer += Time.deltaTime;//restTimer�᲻������deldatime��ʵ��ÿһ֡��ÿһ��update�������ã���������ʱ��
        if (restTimer < restTime)
            return;//�����Ϣʱ�䲻����ֱ�ӷ���

        if (seePlayer)//�����ж������￪ʼ׷��player
        {
            Vector2 currDir = playerpos.transform.position - transform.position; //���˿�����ҵ��������������ӹ���ָ��player
            Vector2 currDirX = new Vector2(currDir.x, 0);//������X�᷽��
            Vector2 currDirY = new Vector2(0, currDir.y);//������Y�᷽��

            if (StoneSpaceNum.stonePos!=null)
            {
                
                Debug.Log("��ʼ��ʯͷ");
                currDir = StoneSpaceNum.stonePos - transform.position;
                if (Mathf.Abs(currDir.x) >= Mathf.Abs(currDir.y))//��X��������Y����룬�˴����þ���ֵ    1��X�᷽��
                {
                    if (!Physics2D.Raycast(transform.position, currDirX, 1.5f, 1 << 8))//1.1 X������ײ�� ���ӹ��﷢�����ߣ���ԭ�㣬�����������߳��ȣ���ײ���㼶����TRUE�Ļ�����ײ�壬FALSE����ײ��
                                                                                       //ע�⣺�ú��������ж�������ײ�壬������Ϊtrigger��Ȼ�ܹ���⵽����Ϊ��ײ����Ȼ����
                    {

                        enemypos += new Vector3(1.5f * currDir.x / Mathf.Abs(currDir.x), 0f, 0f);//������X���ƶ���λ���룬x++
                        restTimer = 0;

                        //Debug.DrawLine(transform.position, currDirX);
                        Debug.Log("x");
                    }

                    else//1.2 X������ײ��
                    {
                        if (!Physics2D.Raycast(transform.position, currDirY, 1.5f, 1 << 8))//1.2.1 Y������ײ��
                        {
                            enemypos += new Vector3(0f, 1.5f * currDir.y / Mathf.Abs(currDir.y), 0f);//y++
                            restTimer = 0;
                            Debug.Log("x001");
                        }

                        else//1.2.2 Y������ײ��
                        {
                            restTimer = 0;
                            enemypos += Vector3.zero;//ԭ�ؾ�ֹ
                            Debug.Log("x000");
                        }
                    }

                }
                if (Mathf.Abs(currDir.y) > Mathf.Abs(currDir.x))//��X��������Y����룬�˴����þ���ֵ    2��Y�᷽��
                {
                    if (!Physics2D.Raycast(transform.position, currDirY, 1.5f, 1 << 8))//2.1 Y������ײ��
                    {

                        Debug.Log("y");
                        enemypos += new Vector3(0f, 1.5f * currDir.y / Mathf.Abs(currDir.y), 0f);//y++
                        restTimer = 0;
                    }

                    else//2.2 Y������ײ��
                    {
                        if (!Physics2D.Raycast(transform.position, currDirX, 1.5f, 1 << 8))//2.2.1 X������ײ��
                        {
                            enemypos += new Vector3(1.5f * currDir.x / Mathf.Abs(currDir.x), 0f, 0f);//x++
                            restTimer = 0;
                            Debug.Log("y01");
                        }

                        else//2.2.2 X������ײ��
                        {
                            restTimer = 0;
                            enemypos += Vector3.zero;//ԭ�ؾ�ֹ
                            Debug.Log("y000");
                        }
                    }
                }
                if(Vector3.Distance(transform.position, StoneSpaceNum.stonePos) < 0.1f)//����׷��ʯͷ
                {
                   
                    
                    Invoke("TransformPlayer", 3.5f);
                }

            }
            else
            {
                if (Mathf.Abs(currDir.x) >= Mathf.Abs(currDir.y))//��X��������Y����룬�˴����þ���ֵ    1��X�᷽��
                {
                    if (!Physics2D.Raycast(transform.position, currDirX, 1.5f, 1 << 8))//1.1 X������ײ�� ���ӹ��﷢�����ߣ���ԭ�㣬�����������߳��ȣ���ײ���㼶����TRUE�Ļ�����ײ�壬FALSE����ײ��
                                                                                       //ע�⣺�ú��������ж�������ײ�壬������Ϊtrigger��Ȼ�ܹ���⵽����Ϊ��ײ����Ȼ����
                    {

                        enemypos += new Vector3(1.5f * currDir.x / Mathf.Abs(currDir.x), 0f, 0f);//������X���ƶ���λ���룬x++
                        restTimer = 0;

                        //Debug.DrawLine(transform.position, currDirX);
                        Debug.Log("x");
                    }

                    else//1.2 X������ײ��
                    {
                        if (!Physics2D.Raycast(transform.position, currDirY, 1.5f, 1 << 8))//1.2.1 Y������ײ��
                        {
                            enemypos += new Vector3(0f, 1.5f * currDir.y / Mathf.Abs(currDir.y), 0f);//y++
                            restTimer = 0;
                            Debug.Log("x001");
                        }

                        else//1.2.2 Y������ײ��
                        {
                            restTimer = 0;
                            enemypos += Vector3.zero;//ԭ�ؾ�ֹ
                            Debug.Log("x000");
                        }
                    }

                }
                if (Mathf.Abs(currDir.y) > Mathf.Abs(currDir.x))//��X��������Y����룬�˴����þ���ֵ    2��Y�᷽��
                {
                    if (!Physics2D.Raycast(transform.position, currDirY, 1.5f, 1 << 8))//2.1 Y������ײ��
                    {

                        Debug.Log("y");
                        enemypos += new Vector3(0f, 1.5f * currDir.y / Mathf.Abs(currDir.y), 0f);//y++
                        restTimer = 0;
                    }

                    else//2.2 Y������ײ��
                    {
                        if (!Physics2D.Raycast(transform.position, currDirX, 1.5f, 1 << 8))//2.2.1 X������ײ��
                        {
                            enemypos += new Vector3(1.5f * currDir.x / Mathf.Abs(currDir.x), 0f, 0f);//x++
                            restTimer = 0;
                            Debug.Log("y01");
                        }

                        else//2.2.2 X������ײ��
                        {
                            restTimer = 0;
                            enemypos += Vector3.zero;//ԭ�ؾ�ֹ
                            Debug.Log("y000");
                        }
                    }
                }
            }
            



            //Collider2D[] aa = Physics2D.OverlapCircleAll(transform.position, 1f);//���һ��Բ���м�����ײ��
            //
            //if (aa.Length == 4)//��ײ��ĸ���
            //{
            //    transform.position = transform.position;
            //}

            //���ַ���ʵ�ֹ����Զ�����
            //1���������߼�⣬������ײ�壬���ַ���ֻ��ͨ����������Ԥ���������У�������trigger���ò�����
            //2������Э�̣���ȡ�������µ����������壬�����������Э��
        }


    }
    
    void Destroy_door()
    {
        //���ھ�̬�ֶΣ���ֱ����������
        //���ڷǾ�̬�ֶΣ���Ҫʹ�õ���������
        //���ߵĹ�ͬ�����ڣ��ֶζ���Ҫ��public
        Destroy(DoorPrefabs.instance.a);
        Debug.Log("�ݻ���2");
    }
    void TransformPlayer()
    {
        StoneSpaceNum.stonePos = playerpos.transform.position;

    }

}
