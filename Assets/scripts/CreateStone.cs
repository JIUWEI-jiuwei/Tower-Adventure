using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;

/// <summary>
/// 挂在camera身上，只挂一个就可以了
/// 问题：之前挂了多个脚本，导致stonespace的数值计算出问题了
/// 实现：鼠标点击屏幕，出现石头，并且物品栏石头减少
/// </summary>
public class CreateStone : MonoBehaviour
{

	/// <summary>创建的石头预制体 </summary>
	public GameObject stonePrefabs;
	public bool isPlaying=false;
	public AudioSource source;   //必须定义AudioSource才能调用AudioClip
	// Start is called before the first frame update
	

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		if (StoneSpaceNum.stoneSpace >= 0 && StoneSpaceNum.stoneSpace <= 2)
		{
			if (Input.GetMouseButtonUp(0))//抬起鼠标，是为了只调用一次
			{
				RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1 << 10);
				//2D中获取鼠标点击位置的方法
				if (hit.collider != null && hit.collider.tag == "square")////如果检测到碰撞体
				{
					Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
					GameObject point = GameObject.Instantiate(stonePrefabs, hit.collider.gameObject.transform.position,
						hit.collider.gameObject.transform.rotation) as GameObject;//获取检测到的物体的位置和旋转方向
					point.transform.localScale = new Vector3(stonePrefabs.transform.localScale.x * 0.5f,
						stonePrefabs.transform.localScale.y * 0.5f, stonePrefabs.transform.localScale.z * 0.5f);//缩小创建的预制体的大小
					StoneSpaceNum.stoneSpace++;//空间剩余量增加
					StoneSpaceNum.stonePos = point.transform.position;
					Debug.Log("StoneSpaceNum.stoneSpace:" + StoneSpaceNum.stoneSpace);

					GetComponent<AudioSource>().Play();
					isPlaying = true;
				}
				
			}
		}
		//MusicOnPlay();
	}
	void MusicOnPlay()
	{
		if (isPlaying)   //当条件触发
		{  //播放声音
		   
			//AudioManager.instance.Playthrowstoneclip();
			Debug.Log("isPlaying");
		}

    }
}
