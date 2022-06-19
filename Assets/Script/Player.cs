using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    #region 公開：欄位
    public float speed;
    public string parameterMove = "移動開關";

    public Image hpbar;

    public float hp;

    public float timeToHurt = 1f;
    private float timer;

    private bool canHurt;
    #endregion

    #region 私人：欄位
    private Rigidbody2D rig;
    private Animator ani;
    #endregion

    #region 私人：屬性
    private float inputHorizontal { get => Input.GetAxis("Horizontal"); }
    private float inputVertical { get => Input.GetAxis("Vertical"); }
    #endregion

    #region 事件
    void Awake() {
        canHurt = true;
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        //hpbar.fillAmount = 1;
    }

    void Update() {
        Filp();
        UpdateAnimation();
        hpbar.fillAmount = hp / 100f;
        timer -= Time.deltaTime;
        if (timer < 0f) canHurt = true;
    }

    private void FixedUpdate() {
		if (inputHorizontal != 0 || inputVertical != 0) {
            Movement();
        }       
    }
    #endregion

    #region 私人：方法
    void Movement() {
        //橢圓映射
        Vector2 origin = new Vector2(inputHorizontal, inputVertical);
        Vector2 v = Vector2.zero;
        v.x = origin.x * Mathf.Sqrt(1 - (origin.y * origin.y) / 2.0f);
        v.y = origin.y * Mathf.Sqrt(1 - (origin.x * origin.x) / 2.0f);
        //Debug.Log(v * speed);
        rig.velocity = v * speed;
    }

    private void UpdateAnimation() {
        ani.SetBool(parameterMove, inputHorizontal != 0 || inputVertical != 0);
    }

    private void Filp() {
        if (Mathf.Abs(inputHorizontal) < 0.1f) return;      // 水平值絕對值 < 0.1 不處理

        gameObject.GetComponent<SpriteRenderer>().flipX = inputHorizontal < 0 ? true : false;
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name.Length > 15 && canHurt) {
            hp -= 6;
            canHurt = false;
            if (hp <= 0) {
                SceneManager.LoadScene("chooseChara");
            }
            //collision.gameObject.GetComponent<Animator>().SetTrigger(parameterHurt);
            Debug.Log($"<color=orange>【接觸】</color>{collision.name.Length} + {hpbar.fillAmount}");
        }
    }

    /// <summary>
    /// 將初始攻擊方式設定成你選擇的角色
    /// </summary>
    public void SetInitAttack(int key) {
        //skill.SetAttack(key);
    }
    #endregion
}
