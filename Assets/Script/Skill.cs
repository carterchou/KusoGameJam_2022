using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    #region --- Inspector ---    
    public Transform skillPoint;
    public GameObject magicBulletA;
    public GameObject magicBulletB;
    public float speed;

    public float timeToAttack;
    private float timer;
    #endregion

    #region --- Event ---
    //private void Update() {
    //    timer -= Time.deltaTime;
    //    if(timer < 0f) MagicBullet();

    //}

    private void FixedUpdate() {
        timer -= Time.deltaTime;
        if (timer < 0f) MagicBulletB();
    }
    #endregion

    #region --- Private Methods ----
    public void MagicBulletA(int key) {


        GameObject skillObject = Instantiate(magicBulletA, skillPoint.position, skillPoint.rotation);
        Rigidbody2D rb = skillObject.GetComponent<Rigidbody2D>();
        Vector3 x = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);

        float randomAngle = Random.Range(0f, 6.28319f);
        Vector2 randomVector = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));

        rb.velocity = randomVector * speed;
        timer = timeToAttack;
        //Debug.Log($"<color=orange>�i�o�g�j</color> ��e�g����V�G {randomAngle}");
    }

    private void MagicBulletB() {
        GameObject skillObject = Instantiate(magicBulletB, skillPoint.position, skillPoint.rotation);
        Rigidbody2D rb = skillObject.GetComponent<Rigidbody2D>();
        Vector3 x = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);

        float randomAngle = Random.Range(0f, 6.28319f);
        Vector2 randomVector = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));

        rb.velocity = randomVector * speed * 0.5f;
        timer = timeToAttack;
        //Debug.Log($"<color=orange>�i�o�g�j</color> ��e�g����V�G {randomAngle}");
    }
    #endregion
}
