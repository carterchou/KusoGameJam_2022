using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickTake : MonoBehaviour
{
    public GameObject[] supportChara;
    public Player player;

    void Update()
    {

    }

	private void Start() {
        //chooseMode.SelectCharaIdx = 0;
        if (supportChara != null && supportChara.Length > 0 && chooseMode.SelectCharaIdx >= 0 && chooseMode.SelectCharaIdx <= 7) {
            foreach (GameObject chara in supportChara) {
                chara.SetActive(false);
            }
            supportChara[chooseMode.SelectCharaIdx].SetActive(true);
            //player.SetInitAttack(chooseMode.SelectCharaIdx);
        }
    }
}
