using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ����
/// ��������Ԥ��������
/// </summary>
public class HeartBeat : MonoBehaviour
{
    /// <summary>�����Ķ������ </summary>
    public Animator heart;
    /// <summary>���� </summary>
    public GameObject monster;
    /// <summary>��ɫ </summary>
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        heart = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(monster.transform.position, player.transform.position) < 4f)//�������player������
        {
            //ToDo...����������ɼ���settrigger
            //Զ��Ļ��ٱ��ƽ��
            heart.SetTrigger("faster");
            if (Vector3.Distance(monster.transform.position, player.transform.position) < 1f)//�������player����֮��
            {
                //ToDo...������׷�� ʧ��
                //��Ļ��ڣ��������������������������¿�ʼ��һ��
                //freelight.gameObject.SetActive(false);
                //settrigger if ���� loadscene

                SceneManager.LoadScene(0);

            }
        }
        else
        {
            heart.SetTrigger("slower");
        }
    }
}
