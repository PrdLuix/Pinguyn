using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public int vidas = 3;

    private Transform tr;
    public Transform verificaChao;
    public bool estaNoChao;
    public bool estaPulando;
    public int maxJump = 2;
    bool jumping;
    public float forcaPulo;
    public float raioVchao;
    public LayerMask solido;
    public VariableJoystick variableJoystick;

    [SerializeField] float velocidade;
    float movimento;
    Rigidbody2D rb;

    UIManager uiManager;
    [SerializeField] GameObject bolas;
    [SerializeField] int quantBolas;

    [SerializeField] bool turnRight;

    
    void Start()
    {
        turnRight = true;
        quantBolas = 0;
        vidas = 3;
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE
#endif
        Vector3 theScale = transform.localScale;
        estaNoChao = Physics2D.OverlapCircle(verificaChao.position, raioVchao, solido);
        if ((movimento < 0 ||variableJoystick.Horizontal < 0)&&turnRight)
        {
            Flip();
        }
        else if((movimento > 0 || variableJoystick.Horizontal > 0) && turnRight == false)
        {
            Flip();
        }
        Tiro();
        if (estaNoChao)
        {
            maxJump = 2;
        }
    }
    void Flip()
    {
        turnRight = !turnRight;
        tr.localScale = new Vector2(-tr.localScale.x, tr.localScale.y);
    }
    private void FixedUpdate()
    {
            Jump();
        Movimentacao();
    }
    void Tiro()
    {

        if (quantBolas > 0 && Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(bolas, transform.position,transform.rotation);
            quantBolas--;
        }
    }
    public void PerderVida()
    {
        vidas--;
        uiManager.PerderVidas(vidas);
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            rb.AddForce(tr.up * forcaPulo);
            estaPulando = true;
            estaNoChao = false;
        }
        else if (Input.GetButtonDown("Jump") && estaPulando)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(tr.up * forcaPulo);
            estaPulando = false;
        }
    }
    void Movimentacao()
    {
#if UNITY_STANDALONE
        movimento = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movimento * velocidade, rb.velocity.y);
#endif

#if UNITY_ANDROID
        rb.velocity = new Vector3(variableJoystick.Horizontal * velocidade, rb.velocity.y);
#endif
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coletavel")
        {
            if (quantBolas < 5)
            {
                quantBolas++;
                Destroy(collision.gameObject);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(verificaChao.position, raioVchao);
    }
}