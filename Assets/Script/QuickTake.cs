using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuickTake : MonoBehaviour
{
    public int killcount = 0;
    public Text txtKillcount;
    public GameObject[] supportChara;
    public Player player;

    void Update()
    {
        txtKillcount.text = $"À»±þ¼Æ¡G{killcount} / 60";
        Win();
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

    public void CountKill() {
        killcount += 1;
    }

    private void Win() {
        if (killcount >= 60) {
            SceneManager.LoadScene("end");
        }
    }
}
