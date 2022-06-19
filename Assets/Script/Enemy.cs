using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public Text txtKillcount;
    private int killcount;
    public float speed;
    public int hp;
    public GameObject target;

    private void FixedUpdate() {
        FollowTarget();
    }

    private void FollowTarget() {
        if (Vector2.Distance(transform.position, target.transform.position) > 0.1) {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            float direction = target.transform.position.x - transform.position.x;
            gameObject.GetComponent<SpriteRenderer>().flipX = direction < 0 ? true : false;
        }
    }

    private void Destory() {
        Destroy(gameObject);
        Debug.Log("<color=orange>¡i¦º¤`¡j</color>");
    }
}
