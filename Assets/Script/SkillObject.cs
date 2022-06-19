using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillObject : MonoBehaviour
{
    private int killCount = 0;
    private string parameterHurt = "Hurt";
    private string parameterDeath = "Death";

    private void Update() {
        if (killCount >= 100) SceneManager.LoadScene("chooseChara");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name.Length > 15) {

            collision.gameObject.GetComponent<Enemy>().hp -= 5;
            collision.gameObject.GetComponent<Animator>().SetTrigger(parameterHurt);

            if (collision.gameObject.GetComponent<Enemy>().hp <= 0) {
                QuickEffect.CheckSEPlayer();
                int index = Random.Range(1, 3);
                AudioClip se = Resources.Load<AudioClip>("Sound/se/dead" + index);
                QuickEffect.SE_Player.PlayOneShot(se);
                collision.gameObject.GetComponent<Animator>().SetTrigger(parameterDeath);
                collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                killCount += 1;
			}
			else {
                QuickEffect.CheckSEPlayer();
                AudioClip se = Resources.Load<AudioClip>("Sound/se/hit");
                QuickEffect.SE_Player.PlayOneShot(se);
            }
        }
        Destroy(gameObject);
        Debug.Log($"<color=green>¡iÀ»±þ¼Æ¶q¡j</color> {killCount}");
    }

}
