using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ���ڹ�������
/// ʵ�ֹ��ܣ������Զ����и����ƶ�������׷��player
/// ʵ���˹����Զ����ŵĹ���
/// </summary>
public class MonsterMove : MonoBehaviour
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
    /// <summary>�ݻ��ŵļ��ʱ�� </summary>
    public float restTime2 = 3f;
    /// <summary>��ʱ�� </summary>
    public float restTimer = 0;
    /// <summary>��ʱ�� </summary>
    public float restTimer2 = 0;
    /// <summary>�����ʼ�ӳ�������ʱ�� </summary>
    public float startMove_m = 3f;
  


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

          

            if (Mathf.Abs(currDir.x) >= Mathf.Abs(currDir.y))//��X��������Y����룬�˴����þ���ֵ    1��X�᷽��
            {
                if (!Physics2D.Raycast(transform.position, currDirX, 1.5f,1<<8|1<<7))//1.1 X������ײ�� ���ӹ��﷢�����ߣ���ԭ�㣬�����������߳��ȣ���ײ���㼶����TRUE�Ļ�����ײ�壬FALSE����ײ��
                //ע�⣺�ú��������ж�������ײ�壬������Ϊtrigger��Ȼ�ܹ���⵽����Ϊ��ײ����Ȼ����
                {

                    enemypos += new Vector3(1.5f * currDir.x / Mathf.Abs(currDir.x), 0f, 0f);//������X���ƶ���λ���룬x++
                    restTimer = 0;

                    //Debug.DrawLine(transform.position, currDirX);
                    Debug.Log("x");
                }
                //ʵ�ֹ����Զ����ŵĹ���
                else if(!Physics2D.Raycast(transform.position, currDirX, 1.5f, 1 << 8)&& //��7�����ţ���8�����ϰ���
                    (Physics2D.Raycast(transform.position, currDirX, 1.5f, 1 << 7))){

                    RaycastHit2D hitX = Physics2D.Raycast(transform.position, currDirX, 1.5f, 1 << 7);//��ȡ�����߼�⵽�����塪����
                    restTimer2 += Time.deltaTime;//�趨�������ٵ�ʱ�䣬3s��3s֮�������٣���������ƶ������򷵻�
                    if (restTimer2 < restTime2)
                        return;
                    if (hitX.collider != null)Destroy(hitX.collider.gameObject);//������ţ��ͽ�������
                    enemypos += new Vector3(1.5f * currDir.x / Mathf.Abs(currDir.x), 0f, 0f);//������X���ƶ���λ���룬x++
                    restTimer2 = 0;
                    restTimer = 0;
                    Debug.Log("�ݻ���");
                }
                else//1.2 X������ײ��
                {
                    if (!Physics2D.Raycast(transform.position, currDirY, 1.5f, 1 << 8|1<<7))//1.2.1 Y������ײ��
                    {//����
                        enemypos += new Vector3(0f, 1.5f * currDir.y / Mathf.Abs(currDir.y), 0f);//y++
                        restTimer = 0;
                        Debug.Log("x001");
                    } 
                    else if (!Physics2D.Raycast(transform.position, currDirY, 1.5f, 1 << 8) &&
                    (Physics2D.Raycast(transform.position, currDirY, 1.5f, 1 << 7)))
                    {
                        RaycastHit2D hitY = Physics2D.Raycast(transform.position, currDirY, 1.5f, 1 << 7);
                        restTimer2 += Time.deltaTime;
                        if (restTimer2 < restTime2)
                            return;
                        if (hitY.collider != null) Destroy(hitY.collider.gameObject);
                        enemypos += new Vector3(0f, 1.5f * currDir.y / Mathf.Abs(currDir.y), 0f);//y++
                        restTimer2 = 0;
                        restTimer = 0;
                        Debug.Log("�ݻ���");
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
                if (!Physics2D.Raycast(transform.position, currDirY, 1.5f, 1 << 8 | 1 << 7))//2.1 Y������ײ��
                {

                    Debug.Log("y");
                    enemypos += new Vector3(0f, 1.5f * currDir.y / Mathf.Abs(currDir.y), 0f);//y++
                    restTimer = 0;
                }
                else if (!Physics2D.Raycast(transform.position, currDirY, 1.5f, 1 << 8) &&
                    (Physics2D.Raycast(transform.position, currDirY, 1.5f, 1 << 7)))
                {
                    RaycastHit2D hitY = Physics2D.Raycast(transform.position, currDirY, 1.5f, 1 << 7);
                    restTimer2 += Time.deltaTime;
                    if (restTimer2 < restTime2)
                        return;
                    if (hitY.collider != null) Destroy(hitY.collider.gameObject);
                    enemypos += new Vector3(0f, 1.5f * currDir.y / Mathf.Abs(currDir.y), 0f);//y++
                    restTimer2 = 0;
                    restTimer = 0;
                    Debug.Log("�ݻ���");
                }
                else//2.2 Y������ײ��
                {
                    if (!Physics2D.Raycast(transform.position, currDirX, 1.5f, 1 << 8 | 1 << 7))//2.2.1 X������ײ��
                    {
                        enemypos += new Vector3(1.5f * currDir.x / Mathf.Abs(currDir.x), 0f, 0f);//x++
                        restTimer = 0;
                        Debug.Log("y01");
                    }
                    else if (!Physics2D.Raycast(transform.position, currDirX, 1.5f, 1 << 8) &&
                    (Physics2D.Raycast(transform.position, currDirX, 1.5f, 1 << 7)))
                    {
                        RaycastHit2D hitX = Physics2D.Raycast(transform.position, currDirX, 1.5f, 1 << 7);

                        restTimer2 += Time.deltaTime;
                        if (restTimer2 < restTime2)
                            return;
                        if (hitX.collider != null) Destroy(hitX.collider.gameObject);
                        enemypos += new Vector3(1.5f * currDir.x / Mathf.Abs(currDir.x), 0f, 0f);//������X���ƶ���λ���룬x++
                        restTimer2 = 0;
                        restTimer = 0;
                        Debug.Log("�ݻ���");
                    }
                    else//2.2.2 X������ײ��
                    {
                        restTimer = 0;
                        enemypos += Vector3.zero;//ԭ�ؾ�ֹ
                        Debug.Log("y000");
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


}
/*

 //��ȡ���߼�⵽����ײ��
 RaycastHit2D hitX = Physics2D.Raycast(transform.position, currDirX, 1.5f, 1 << 7);
                    if (hitX.collider != null)
                    {

                        if (hitX.collider.GetComponent<Collider2D>().isTrigger == false)
                        {
                            //hitX.collider.GetComponent<Collider2D>().isTrigger = true;
                            hitX.collider.GetComponent<Renderer>().material.color = new Color(
                                hitX.collider.GetComponent<Renderer>().material.color.r,
                                hitX.collider.GetComponent<Renderer>().material.color.g,
                                hitX.collider.GetComponent<Renderer>().material.color.b,
                                hitX.collider.GetComponent<Renderer>().material.color.a - Time.deltaTime / timeCout

                                );
                        }
                    }

                    RaycastHit2D hitY = Physics2D.Raycast(transform.position, currDirY, 1.5f, 1 << 7);
                    if (hitY.collider != null)
                    {
                        if (hitY.collider.GetComponent<Collider2D>().isTrigger == false)
                        {
                            //hitY.collider.GetComponent<Collider2D>().isTrigger = true;
                            hitY.collider.GetComponent<Renderer>().material.color = new Color(
                                hitY.collider.GetComponent<Renderer>().material.color.r,
                                hitY.collider.GetComponent<Renderer>().material.color.g,
                                hitY.collider.GetComponent<Renderer>().material.color.b,
                                hitY.collider.GetComponent<Renderer>().material.color.a - Time.deltaTime / timeCout

                                );
                        }
                    }
 
 
 
 
 
 
 
 
 */