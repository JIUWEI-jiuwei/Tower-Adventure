using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;

/// <summary>
/// ����camera���ϣ�ֻ��һ���Ϳ�����
/// ���⣺֮ǰ���˶���ű�������stonespace����ֵ�����������
/// ʵ�֣��������Ļ������ʯͷ��������Ʒ��ʯͷ����
/// </summary>
public class CreateStone : MonoBehaviour
{

	/// <summary>������ʯͷԤ���� </summary>
	public GameObject stonePrefabs;
	public bool isPlaying=false;
	public AudioSource source;   //���붨��AudioSource���ܵ���AudioClip
	// Start is called before the first frame update
	

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		if (StoneSpaceNum.stoneSpace >= 0 && StoneSpaceNum.stoneSpace <= 2)
		{
			if (Input.GetMouseButtonUp(0))//̧����꣬��Ϊ��ֻ����һ��
			{
				RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1 << 10);
				//2D�л�ȡ�����λ�õķ���
				if (hit.collider != null && hit.collider.tag == "square")////�����⵽��ײ��
				{
					Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
					GameObject point = GameObject.Instantiate(stonePrefabs, hit.collider.gameObject.transform.position,
						hit.collider.gameObject.transform.rotation) as GameObject;//��ȡ��⵽�������λ�ú���ת����
					point.transform.localScale = new Vector3(stonePrefabs.transform.localScale.x * 0.5f,
						stonePrefabs.transform.localScale.y * 0.5f, stonePrefabs.transform.localScale.z * 0.5f);//��С������Ԥ����Ĵ�С
					StoneSpaceNum.stoneSpace++;//�ռ�ʣ��������
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
		if (isPlaying)   //����������
		{  //��������
		   
			//AudioManager.instance.Playthrowstoneclip();
			Debug.Log("isPlaying");
		}

    }
}
