using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 心跳
/// 挂在心跳预制体上面
/// </summary>
public class HeartBeat : MonoBehaviour
{
    /// <summary>心跳的动画组件 </summary>
    public Animator heart;
    /// <summary>怪物 </summary>
    public GameObject monster;
    /// <summary>角色 </summary>
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
        
        if (Vector3.Distance(monster.transform.position, player.transform.position) < heartBeatFaster)//当怪物和player距离变近
        {
            //心跳动画变成急速settrigger
            //远离的话再变回平缓
            heart.SetBool("heartfast",true);
            
            //heartBeatFast.Play();
            if (Vector3.Distance(monster.transform.position, player.transform.position) < 0.1f)//当怪物和player相遇之后
            {
                //ToDo...被怪物追上 失败
                //屏幕变黑，播放心跳死亡动画，并且重新开始这一关
                //freelight.gameObject.SetActive(false);
                //settrigger if 结束 loadscene
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
