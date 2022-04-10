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
    public static AudioManager instance;//����

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
        GetComponent<AudioSource>().clip = pick;//�л���������

        GetComponent<AudioSource>().Play();//����
    }
   public  void Playthrowstoneclip()
   {
        GetComponent<AudioSource>().clip = throwStone;//�л���������

        GetComponent<AudioSource>().Play();//����
    }
    public  void PlayerWalk()
   {
        GetComponent<AudioSource>().clip = walk;//�л���������

        GetComponent<AudioSource>().Play();//����
    }
    public  void HeatBeatFast()
   {
        GetComponent<AudioSource>().clip = heartBeatFast;//�л���������

        GetComponent<AudioSource>().Play();//����
    }
    public  void HeatBeatFastStop()
   {
        GetComponent<AudioSource>().clip = heartBeatFast;//�л���������

        GetComponent<AudioSource>().Pause();//����
    }
   
}
