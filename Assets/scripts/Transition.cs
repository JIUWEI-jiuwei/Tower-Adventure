using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ��������
/// ����ʤ��ʧ�ܳ�������
/// </summary>
public class Transition : MonoBehaviour
{
    /// <summary>�������/// </summary>
    public int num;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Next",3f);
    }
    /// <summary>
    /// ���س���
    /// </summary>
    void Next()
    {
        SceneManager.LoadScene(num);
    }
}
