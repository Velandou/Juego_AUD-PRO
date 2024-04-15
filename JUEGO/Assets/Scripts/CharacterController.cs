using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public float saltoMax;
    public LayerMask capaSuelo;

    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private bool mirDER = true;
    private float saltoR;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltoR = saltoMax;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Salto();
    }

    bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.3f, capaSuelo);
        return raycastHit.collider != null;
    }

    void Salto()
    {
        if(EstaEnSuelo())
        {
            saltoR = saltoMax;
        }

        if (Input.GetKeyDown(KeyCode.Space) && saltoR > 0)
        {
            saltoR--;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
            rigidBody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    void Movimiento()
    {
        float inputMov = Input.GetAxis("Horizontal");

        if(inputMov != 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);

        }

        rigidBody.velocity = new Vector2(inputMov * velocidad, rigidBody.velocity.y);


        Orientacion(inputMov);
    }

    void Orientacion(float inputMov)
    {
        if ((mirDER == true && inputMov < 0 )|| (mirDER == false && inputMov > 0))
        {
            mirDER = !mirDER;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
