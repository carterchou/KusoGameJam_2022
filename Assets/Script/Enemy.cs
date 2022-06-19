using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

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
