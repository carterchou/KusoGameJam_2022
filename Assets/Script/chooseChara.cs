using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class chooseChara : MonoBehaviour
{
    public chooseMode choose;
    public QuickEffect effect;
    public Text name;
    public int index = -1;
    public void click() {
        if(choose != null) {
            choose.SelectChara(index);
        }
	}
	private void Awake() {
        if(index >= 0 && name != null) {
            name.text = chooseMode.charaNames[index];
        }
    }

    public void EnterGame() {
        SceneManager.LoadScene("Game");
    }
}
