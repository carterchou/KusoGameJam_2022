using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class QuickEffect : MonoBehaviour
{
	static AudioSource SE_Player;
	public RectTransform rect;
	Vector2 originPos = Vector2.zero;

	public bool jumpEffect = false;
	int jumpType = 0;
	Vector2 endPos = Vector2.zero;
	public float jumpDistance = 1;
	public float jumpSpeed = 1;

	public GameObject pauseMenu;

	public void Awake() {
		if (rect != null) {
			originPos = rect.localPosition;
		}
	}

	public void Update() {
		if(rect == null) {
			return;
		}		

		if (jumpEffect) {
			switch (jumpType) {
				case 0:
					jumpType = 1;
					endPos = originPos + new Vector2(0, jumpDistance);
					break;
				case 1: //往上
					if (Vector2.Distance(rect.localPosition, endPos) <= 0.25f) {
						jumpType = 2;
						endPos = originPos;
					}
					else {
						float y = Mathf.Lerp(rect.localPosition.y, endPos.y, Time.deltaTime * jumpSpeed);
						rect.localPosition = new Vector2(rect.localPosition.x, y);
					}
					break;
				case 2: //往下
					if (Vector2.Distance(rect.localPosition, endPos) <= 0.25f) {
						jumpType = 1;
						endPos = originPos + new Vector2(0, jumpDistance);
					}
					else {
						float y = Mathf.Lerp(rect.localPosition.y, endPos.y, Time.deltaTime * jumpSpeed);
						rect.localPosition = new Vector2(rect.localPosition.x, y);
					}
					break;
			}
		}
		else {
			if(jumpType != 0) {
				jumpType = 0;
				rect.localPosition = originPos;
			}
		}
	}

	public void ClickSE() {
		CheckSEPlayer();
		AudioClip se = Resources.Load<AudioClip>("sound/SE/choose");
		if(se != null) {
			SE_Player.PlayOneShot(se);
		}
	}

	public void hoverSE() {
		CheckSEPlayer();
		int i = 1;// Random.Range(1, 3);
		AudioClip se = Resources.Load<AudioClip>("sound/SE/hover"+i);
		if (se != null) {
			SE_Player.PlayOneShot(se);
		}
	}
	public void PauseSE() {
		CheckSEPlayer();
		AudioClip se = Resources.Load<AudioClip>("sound/SE/pause");
		if (se != null) {
			SE_Player.PlayOneShot(se);
		}
	}

	void CheckSEPlayer() { 
		if(SE_Player == null) {
			SE_Player = new GameObject("SE_Player").AddComponent<AudioSource>();
			DontDestroyOnLoad(SE_Player.gameObject);
		}
	}

	public void PauseGame() {
		if(pauseMenu != null) {
			PauseSE();
			pauseMenu.SetActive(true);
		}
		Time.timeScale = 0;
	}

	public void UnpauseGame() {
		if (pauseMenu != null) {
			pauseMenu.SetActive(false);
		}
		Time.timeScale = 1;
	}

	public void GoTitle() {
		Time.timeScale = 1;
		SceneManager.LoadScene("title");
	}

	public void GoChoose() {
		Time.timeScale = 1;
		chooseMode.firstIn = 1;
		SceneManager.LoadScene("chooseChara");
	}
}
