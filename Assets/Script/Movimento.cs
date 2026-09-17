using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float movespeed = 5f;        //velocidade normal
    public float dashSpeed = 15f;      // velocidade durante o dash
    public float dashDuration = 0.2f;   // tempo que o das dura
    public float dasCooldown = 1f;     // tempon de recarga do dash

    private Rigidbody2D rb;            // Rigidboy do player


    private Vector2 moveInput;
    private bool isdashing = false;
    private float dashTimeLeft;
    private float lasDashR;
    float EndDash;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>(); //pega os valores do rigidbody 2D

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");  //Vai reconhecer o movimento horizontal
        rb.linearVelocity = new Vector2(moveHorizontal* movespeed, rb.linearVelocity.y); //Far� o objeto se movimentar para a dire��o do eixo x e y; 

        if (Input.GetKeyDown(KeyCode.Space)) //Atribuir� o movimento de pulo na tecla espa�o
        {
            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);  //Vai desenvolver a fisica necessaria para o objeto pular
        }

        void FixedUpdate()
        {
            if (isdashing)
            {
                rb.linearVelocity = moveInput * dashSpeed;
                dashTimeLeft -= Time.fixedDeltaTime;

                if (dashTimeLeft <= 0)
                {
                    
                }
            }
        }
    }
}
