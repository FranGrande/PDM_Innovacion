using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoMove : MonoBehaviour
{
    
    // Start is called before the first frame update
    [SerializeField] private Transform[] puntosMov;
    [SerializeField] private float velocidad;
    public GameObject player;
    public GameObject enemigo;

    private int i = 0;
    private Vector3 escalaIni, escalaTemp;
    private float miraDer = 1;
    private float velocidadIni;
    private SpriteRenderer sEnemigo;
    private Color colorOriginal;

    void Start()
    {
        escalaIni = transform.localScale;
        velocidadIni = velocidad;
        sEnemigo = enemigo.GetComponent<SpriteRenderer>();
        colorOriginal = sEnemigo.color;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosMov[i].transform.position, velocidad * Time.deltaTime);
        if (Vector2.Distance(transform.position, puntosMov[i].transform.position) < 0.1f)
        {
            if (puntosMov[i] != puntosMov[puntosMov.Length - 1]) i++;
            else i = 0;

            miraDer = Mathf.Sign(puntosMov[i].transform.position.x - transform.position.x);
            gira(miraDer);
        }
    }

    private void gira(float lado) {
        if (lado == -1)
        {
            escalaTemp = transform.localScale;
            escalaTemp.x = escalaTemp.x * -1;
        }
        else escalaTemp = escalaIni;

        transform.localScale = escalaTemp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (player == null) return;
        float lado = Mathf.Sign(player.transform.position.x - transform.position.x);
        if (Mathf.Abs(transform.position.x - player.transform.position.x) < 2 && Mathf.Abs(transform.position.y - player.transform.position.y) < 0.1f && lado == miraDer)
        {
            Ataca();
        }
        else {
            Relaja();
        }
    }

    private void Ataca()
    {
        velocidad *= 1.1f;
        Color nuevoColor = new Color(255f/255f, 100f/255f, 100f/255f);
        sEnemigo.color = nuevoColor;
    }

    private void Relaja() {
        velocidad = velocidadIni;
        sEnemigo.color = colorOriginal;
    }

}
