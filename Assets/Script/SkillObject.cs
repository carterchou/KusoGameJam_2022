using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillObject : MonoBehaviour
{
    //public GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }
}
