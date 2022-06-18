using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleMode : MonoBehaviour
{
	public void EnterGame() {
		chooseMode.SelectCharaIdx = -1;
		chooseMode.firstIn = 0;
		SceneManager.LoadScene("chooseChara");
	}

	public void ExitGame() {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
	public void RickRoll() {
		Application.OpenURL("http://youtu.be/dQw4w9WgXcQ");
	}
}
