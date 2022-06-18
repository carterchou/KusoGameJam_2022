using UnityEngine;

public class Player : MonoBehaviour {
    #region ���}�G���
    public float speed;
    public string parameterMove = "���ʶ}��";
    #endregion

    #region �p�H�G���
    private Rigidbody2D rig;
    private Animator ani;
    #endregion

    #region �p�H�G�ݩ�
    private float inputHorizontal { get => Input.GetAxis("Horizontal"); }
    private float inputVertical { get => Input.GetAxis("Vertical"); }
    #endregion

    #region �ƥ�
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

    #region �p�H�G��k
    void Movement() {
        rig.velocity = new Vector2(speed * inputHorizontal, speed * inputVertical);
    }

    private void UpdateAnimation() {
        ani.SetBool(parameterMove, inputHorizontal != 0 || inputVertical != 0);
    }

    private void Filp() {
        if (Mathf.Abs(inputHorizontal) < 0.1f) return;      // �����ȵ���� < 0.1 ���B�z
        float yAngle = inputHorizontal > 0 ? 0 : 180;
        transform.eulerAngles = new Vector3(0, yAngle, 0);
    }

    /// <summary>
    /// �N��l�����覡�]�w���A��ܪ�����
    /// </summary>
    private void SetInitAttack() {

    }
    #endregion
}
