using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class QuickEffect : MonoBehaviour
{
	public RectTransform rect;
	Vector2 originPos = Vector2.zero;

	public bool jumpEffect = false;
	int jumpType = 0;
	Vector2 endPos = Vector2.zero;
	public float jumpDistance = 1;
	public float jumpSpeed = 1;

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
}
