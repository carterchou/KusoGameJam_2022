using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    #region ���}�G���
    public float speed;
    public string parameterMove = "���ʶ}��";

    public Image hpbar;

    public float hp;

    public float timeToHurt = 1f;
    private float timer;

    private bool canHurt;
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

    #region �p�H�G��k
    void Movement() {
        //���M�g
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
        if (Mathf.Abs(inputHorizontal) < 0.1f) return;      // �����ȵ���� < 0.1 ���B�z

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
            Debug.Log($"<color=orange>�i��Ĳ�j</color>{collision.name.Length} + {hpbar.fillAmount}");
        }
    }

    /// <summary>
    /// �N��l�����覡�]�w���A��ܪ�����
    /// </summary>
    public void SetInitAttack(int key) {
        //skill.SetAttack(key);
    }
    #endregion
}
