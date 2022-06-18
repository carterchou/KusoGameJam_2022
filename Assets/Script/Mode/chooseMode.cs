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
	public GameObject[] selectCharaList; // 0 - 7 ������B8���������ܥ�

	public chooseChara[] allChara;

	public static string[] charaNames = {
		"�����l" ,
		"�S���S��",
		"�ڨ���",
		"15���۪�",
		"���i�D���Ƥ�",
		"������",
		"���A",
		"���H",
		"�п�ܤ@�W�٦�"
	};

	public static string[] charaInfos = {
		"�S���ڡA�ڬݧA�n����!\n��!" ,
		"�H���n�A�ڬO�x�{���ع�Rescute���S���S��\n�Цh�h���СI",
		"�ڶټڨ�\n�ڬO�x�{���عΪ�����\n�ڢw�w�w�w�w�����I",
		"�H���w�w\n�ڬO�x�{���عΪ��Q����\n���Ѥ]�O�٦檺�@�ѡI",
		"�ڬO���i�D���Ƥ�\n���۳Q�ڪ����ڱ����U!",
		"�H���A�A���ڸ��U!",
		"�ڬO���A�I\n�̥��c�~ŧ�ӡI�I",
		"�ڬO���H�I\n���j���ڼw�i����",
		"�٦�|�����A��l���B�~��O\n���U�A�X�}�o��\n���A�Z�B����"
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
