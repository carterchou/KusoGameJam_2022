using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillObject : MonoBehaviour
{
    //public GameObject hitEffect;

    //private void OnCollisionEnter2D(Collision2D collision) {
    //    Destroy(gameObject);
    //}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Enemy") {
            Destroy(collision);
        }
            Destroy(gameObject);
        Debug.Log($"<color=green>�i�����ؼСj</color> {collision.name}");
    }
}
