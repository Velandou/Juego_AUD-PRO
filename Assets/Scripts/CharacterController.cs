using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public float saltoMax;
    public float fuerzaGolpe;
    public LayerMask capaSuelo;

    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private bool mirDER = true;
    private float saltoR;
    private Animator animator;
    private bool puedeMoverse = true;


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
        float castDistance = 0.05f; // Adjust as needed
        Vector2 castOrigin = transform.position - new Vector3(0f, boxCollider.size.y / 2f, 0f); // Adjust y-offset if needed
        RaycastHit2D hit = Physics2D.Raycast(castOrigin, Vector2.down, castDistance, capaSuelo);
        return hit.collider != null;
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
        if (!puedeMoverse) return;

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

    public void AplicarGolpe()
    {
        puedeMoverse = false;
        Vector2 direccionGolpe;
        if(rigidBody.velocity.x > 0)
        {
            direccionGolpe = new Vector2(-1, 1);
        }
        else
        {
            direccionGolpe = new Vector2(1, 1);
        }
        rigidBody.AddForce(direccionGolpe * fuerzaGolpe);

        StartCoroutine(EsperarYActivarMovimiento());
    }

    IEnumerator EsperarYActivarMovimiento()
    {
        yield return new WaitForSeconds(0.1f);

        while (!EstaEnSuelo())
        {
            yield return null;
        }

        puedeMoverse = true;
    }
}
