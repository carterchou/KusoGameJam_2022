using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseMode : MonoBehaviour
{
	public static chooseMode intance;
	public static int SelectCharaIdx = -1;
	public static int firstIn = 1;

	public GameObject block;
	public AudioSource BGMPlayer;
	public Text[] selectCharaName;
	public Text[] selectCharaInfo;
	public GameObject[] selectCharaList; // 0 - 7 為角色、8為未選擇顯示用

	public chooseChara[] allChara;

	public static string[] charaNames = {
		"平平子" ,
		"露恰露恰",
		"歐貝爾",
		"15號石虎",
		"祈菈．貝希毛絲",
		"阿爾姿",
		"海唧",
		"歐妲",
		"請選擇一名夥伴"
	};

	public static string[] charaInfos = {
		"沒有我，我看你要怎麼辦!\n哼!" ,
		"人類好，我是瀕臨絕種團Rescute的露恰露恰\n請多多指教！",
		"歐嗨歐貝\n我是瀕臨絕種團的隊長\n歐─────貝爾！",
		"人類安安\n我是瀕臨絕種團的十五號\n今天也是還行的一天！",
		"我是祈菈．貝希毛絲\n等著被我的尾巴掃到桌下!",
		"人類，你給我跪下!",
		"我是海唧！\n最兇惡獸襲來！！",
		"我是歐妲！\n偉大的歐德姆布拉",
		"夥伴會給予你初始的額外能力\n幫助你旗開得勝\n祝你武運昌隆"
	};

	private void Awake() {
		intance = this;
		block.SetActive(true);
		init();
	}

	private void Start() {
		if (firstIn == 0) {
			Fungus.Flowchart.BroadcastFungusMessage("intro");
		}
		else if(firstIn == 1) {
			int index = Random.Range(1, 4);
			Fungus.Flowchart.BroadcastFungusMessage("SecondChance" + index);
		}
		else {
			IntroStoryCallback();
		}
		
	}

	public void IntroStoryCallback() {
		BGMPlayer.Play();
		block.SetActive(false);
	}

	void init() {
		if (SelectCharaIdx < 0 || SelectCharaIdx > 7) {
			SelectCharaIdx = -1;
			SetSelectCharaUI(8);
		}
		else {
			SelectChara(SelectCharaIdx);
		}
	}

	public void SelectChara(int index) {
		if(index == -1) {
			return;
		}
		SelectCharaIdx = index;
		SetSelectCharaUI(SelectCharaIdx);
	}

	void SetSelectCharaUI(int index) {
		foreach (GameObject obj in selectCharaList) {
			obj.SetActive(false);
		}
		foreach(chooseChara chara in allChara) {
			chara.GetComponent<QuickEffect>().jumpEffect = false;
		}

		if (index >= 0 && index <= 7) {
			selectCharaList[index].SetActive(true);
			allChara[index].GetComponent<QuickEffect>().jumpEffect = true;
		}
		
	  
		foreach (Text name in selectCharaName) {
			name.text = charaNames[index].Replace("\\n","\n");
		}
		foreach (Text info in selectCharaInfo) {
			info.text = charaInfos[index].Replace("\\n", "\n");
		}
	}
}
