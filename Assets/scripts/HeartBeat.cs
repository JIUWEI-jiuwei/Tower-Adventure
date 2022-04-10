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
    public AudioSource die;
    public AudioSource heartBeatFast;
    public float heartBeatFaster;

    // Start is called before the first frame update
    void Start()
    {
        heart = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(monster.transform.position, player.transform.position) < heartBeatFaster)//�������player������
        {
            //����������ɼ���settrigger
            //Զ��Ļ��ٱ��ƽ��
            heart.SetBool("heartfast",true);
            
            //heartBeatFast.Play();
            if (Vector3.Distance(monster.transform.position, player.transform.position) < 0.1f)//�������player����֮��
            {
                //ToDo...������׷�� ʧ��
                //��Ļ��ڣ��������������������������¿�ʼ��һ��
                //freelight.gameObject.SetActive(false);
                //settrigger if ���� loadscene
                die.Play();
                SceneManager.LoadScene(0);
              
            }
        }
        else
        {
            heart.SetBool("heartfast", false);
            
           // heartBeatFast.Pause();
        }
    }
}
