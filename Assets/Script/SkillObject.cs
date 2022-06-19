using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillObject : MonoBehaviour
{
    public string parameterHurt = "Hurt";
    public string parameterDead = "Dead";

    //private GameObject enemyObject;
 
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name.Length > 15) {

            collision.gameObject.GetComponent<Enemy>().hp -= 5;
            collision.gameObject.GetComponent<Animator>().SetTrigger(parameterHurt);

            if (collision.gameObject.GetComponent<Enemy>().hp < 0) {
                collision.gameObject.GetComponent<Animator>().SetTrigger(parameterDead);
                collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            }             
        }
        Destroy(gameObject);
        //Debug.Log($"<color=green>°i¿ª§§•ÿº–°j</color> {collision.name}");
    }

}
