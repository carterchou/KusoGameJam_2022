using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed;
    //public Transform target;
    public GameObject target;

    //private void start() {
    //    target = GameObject.Find("player");
    //}

    private void Update() {
        FollowTarget();
    }

    void FollowTarget() {
        //target = GameObject.Find("player");
        if (Vector2.Distance(transform.position, target.transform.position) > 0.1) {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            float direction = target.transform.position.x - transform.position.x;
            gameObject.GetComponent<SpriteRenderer>().flipX = direction < 0 ? true : false;
            //Filp(direction);
        }
    }

    void Filp(float speed) {
        gameObject.GetComponent<SpriteRenderer>().flipX = speed < 0 ? true : false;
    }

}
