using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    #region --- Inspector ---    
    public Transform skillPoint;
    public GameObject magicBullet;
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
        if (timer < 0f) MagicBullet();
    }
    #endregion

    #region --- Private Methods ----
    private void MagicBullet() {
        GameObject skillObject = Instantiate(magicBullet, skillPoint.position, skillPoint.rotation);
        Rigidbody2D rb = skillObject.GetComponent<Rigidbody2D>();
        Vector3 x = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);

        float randomAngle = Random.Range(0f, 6.28319f); //generates random angle in radians
        Vector2 randomVector = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));

        //rb.AddForce(randomVector * speed, ForceMode2D.Impulse);
        rb.velocity = randomVector * speed;
        timer = timeToAttack;
        //Debug.Log($"<color=orange>�i�o�g�j</color> ��e�g����V�G {randomAngle}");
    }
    #endregion


}
