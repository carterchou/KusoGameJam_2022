using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed;
    public Transform target;

    private void Update() {
        FollowTarget();
    }

    void FollowTarget() {
        if (Vector2.Distance(transform.position, target.position) > 0.1) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            float direction = target.position.x - transform.position.x;
            Filp(direction);
        }
    }

    void Filp(float speed) {
        transform.eulerAngles = speed > 0 ? new Vector3(0, 0, 0) : new Vector3(0, 180, 0);
    }

}
