using UnityEngine;

public class Player : MonoBehaviour {
    #region 公開：欄位
    public float speed;
    public string parameterMove = "移動開關";
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
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    void Update() {
        Filp();
        UpdateAnimation();
    }

    private void FixedUpdate() {
        Movement();
    }
    #endregion

    #region 私人：方法
    void Movement() {
        rig.velocity = new Vector2(speed * inputHorizontal, speed * inputVertical);
    }

    private void UpdateAnimation() {
        ani.SetBool(parameterMove, inputHorizontal != 0 || inputVertical != 0);
    }

    private void Filp() {
        if (Mathf.Abs(inputHorizontal) < 0.1f) return;      // 水平值絕對值 < 0.1 不處理
        float yAngle = inputHorizontal > 0 ? 0 : 180;
        transform.eulerAngles = new Vector3(0, yAngle, 0);
    }

    /// <summary>
    /// 將初始攻擊方式設定成你選擇的角色
    /// </summary>
    private void SetInitAttack() {

    }
    #endregion
}
