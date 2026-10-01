using System.Collections;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float movespeed = 100f;        //velocidade normal
    public float dashSpeed = 99f;      // velocidade durante o dash
    public float dashDuration = 0.2f;   // tempo que o das dura
    public float dasCooldown = 1f;     // tempon de recarga do dash




    private Rigidbody2D rb;  // Rigidboy do player
    private float cooldown = 1f;
    private float forçaDash = 99f;
    private float duração = 0.15f;
    private bool podedash = true;
    private bool fazendoDash = false;
    private float ultimadireçãoX = 1f;
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

        float x = Input.GetAxisRaw("Horizontal");
        if ( x != 0f) ultimadireçãoX = Mathf.Sign(x);
    }

    IEnumerator FazerDash()
    {
        podedash = false;
        fazendoDash = true;

        float gravidadeOriginal = rb.gravityScale;
        rb.gravityScale = 0f;

        rb.linearVelocity = new Vector2(ultimadireçãoX * forçaDash, 0f);

        yield return new WaitForSeconds(duração);

        rb.gravityScale = gravidadeOriginal;
        fazendoDash = false;


        yield return new WaitForSeconds(cooldown);
        podedash = true;
    }
}

        
       
     
        
       
        
    


        
