using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseMode : MonoBehaviour
{
	public static chooseMode intance;
	public static int SelectCharaIdx = -1;
	public static bool firstIn = true;

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
		"�|����ܨ���"
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
		""
	};

	private void Awake() {
		intance = this;
		init();
	}

	private void Start() {
		Fungus.Flowchart.BroadcastFungusMessage("FirstIN");
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
