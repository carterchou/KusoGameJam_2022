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

    private int switchKey;
    #endregion

    #region --- Event ---
    //private void Update() {
    //    timer -= Time.deltaTime;
    //    if(timer < 0f) MagicBullet();

    //}

    private void FixedUpdate() {
        timer -= Time.deltaTime;
        if (timer < 0f) {
            if (switchKey == 0) MagicBulletA();
            else MagicBulletB();
        }         
    }
    #endregion

    #region --- Private Methods ----
    public void SetAttack(int key) {
        if (key < 4) {
            switchKey = 0;
        }
        else switchKey = 1;
        Debug.Log($"<color=orange>【角色編號】</color>{key}");
    }

    public void MagicBulletA() {

        GameObject skillObject = Instantiate(magicBulletA, skillPoint.position, skillPoint.rotation);
        Rigidbody2D rb = skillObject.GetComponent<Rigidbody2D>();
        Vector3 x = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);

        float randomAngle = Random.Range(0f, 6.28319f);
        Vector2 randomVector = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));

        rb.velocity = randomVector * speed;
        timer = timeToAttack;
        //Debug.Log($"<color=orange>【發射】</color> 當前射擊方向： {randomAngle}");
    }

    private void MagicBulletB() {
        GameObject skillObject = Instantiate(magicBulletB, skillPoint.position, skillPoint.rotation);
        Rigidbody2D rb = skillObject.GetComponent<Rigidbody2D>();
        Vector3 x = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);

        float randomAngle = Random.Range(0f, 6.28319f);
        Vector2 randomVector = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));

        rb.velocity = randomVector * speed * 0.5f;
        timer = timeToAttack;
        //Debug.Log($"<color=orange>【發射】</color> 當前射擊方向： {randomAngle}");
    }
    #endregion
}
