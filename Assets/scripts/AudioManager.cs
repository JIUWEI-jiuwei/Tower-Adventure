using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    // private static AudioSource audioS;
    // private static AudioClip pickstone;
    // private static AudioClip throwstone;
    public  AudioClip pick;
    public  AudioClip throwStone;
    public  AudioClip walk;
    //public  AudioClip heartbeatslow;
    private  AudioClip heartBeatFast;
    private AudioManager() { }
    public static AudioManager instance;//µ¥Àý

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       //audioS = GetComponent<AudioSource>();
       //pickstone = Resources.Load<AudioClip>("pickstone");
       //throwstone = Resources.Load<AudioClip>("throwstone");
    }

    // Update is called once per frame
    void Update()
    {

    }

   public  void Playpickstoneclip()
   {
        GetComponent<AudioSource>().clip = pick;//ÇÐ»»´ý»ú¼ô¼­

        GetComponent<AudioSource>().Play();//²¥·Å
    }
   public  void Playthrowstoneclip()
   {
        GetComponent<AudioSource>().clip = throwStone;//ÇÐ»»´ý»ú¼ô¼­

        GetComponent<AudioSource>().Play();//²¥·Å
    }
    public  void PlayerWalk()
   {
        GetComponent<AudioSource>().clip = walk;//ÇÐ»»´ý»ú¼ô¼­

        GetComponent<AudioSource>().Play();//²¥·Å
    }
    public  void HeatBeatFast()
   {
        GetComponent<AudioSource>().clip = heartBeatFast;//ÇÐ»»´ý»ú¼ô¼­

        GetComponent<AudioSource>().Play();//²¥·Å
    }
    public  void HeatBeatFastStop()
   {
        GetComponent<AudioSource>().clip = heartBeatFast;//ÇÐ»»´ý»ú¼ô¼­

        GetComponent<AudioSource>().Pause();//²¥·Å
    }
   
}
