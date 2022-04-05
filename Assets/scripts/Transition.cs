using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景过渡
/// 挂在胜利失败场景里面
/// </summary>
public class Transition : MonoBehaviour
{
    /// <summary>场景编号/// </summary>
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
    /// 加载场景
    /// </summary>
    void Next()
    {
        SceneManager.LoadScene(num);
    }
}
