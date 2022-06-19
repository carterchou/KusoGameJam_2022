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
                collision.gameObject.GetComponent<Animator>().SetTrigger(parameterDeath);
                collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                killCount += 1;
            }             
        }
        Destroy(gameObject);
        Debug.Log($"<color=green>¡iÀ»±þ¼Æ¶q¡j</color> {killCount}");
    }

}
