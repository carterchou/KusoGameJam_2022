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
    private void Update() {
        timer -= Time.deltaTime;
        if(timer < 0f) MagicBullet();

    }
    #endregion

    #region --- Private Methods ----
    private void MagicBullet() {
        GameObject skill = Instantiate(magicBullet, skillPoint.position, skillPoint.rotation);
        Rigidbody2D rb = magicBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(skillPoint.up * speed, ForceMode2D.Impulse);
        timer = timeToAttack;
        Debug.Log($"<color=orange>【發射】</color> 當前射擊方向： {skillPoint.up}");
    }
    #endregion


}
