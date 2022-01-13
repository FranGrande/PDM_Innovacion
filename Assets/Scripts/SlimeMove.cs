using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigid_slime;
    public float speed;



    void Start()
    {
        rigid_slime = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid_slime.velocity = new Vector2(speed, rigid_slime.velocity.y);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plataforma") {
            speed *= -1;
            transform.localScale = new Vector2(this.transform.localScale.x * -1, this.transform.localScale.y);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //Debug.Log("Player dameged");
            //Destroy(collision.gameObject);
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();

        }


    }
}
