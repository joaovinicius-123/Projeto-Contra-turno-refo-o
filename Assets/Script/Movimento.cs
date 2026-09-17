using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>(); //pega os valores do rigidbody 2D

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");  //Vai reconhecer o movimento horizontal
        rb.linearVelocity = new Vector2(moveHorizontal* speed, rb.linearVelocity.y); //Fará o objeto se movimentar para a direção do eixo x e y; 

        if (Input.GetKeyDown(KeyCode.Space)) //Atribuirá o movimento de pulo na tecla espaço
        {
            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);  //Vai desenvolver a fisica necessaria para o objeto pular
        }
    }
}
