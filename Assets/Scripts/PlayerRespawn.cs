using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    private float checkPointPositionX, checkpointPositionY;
    public Animator animator;
    public GameObject[] vidas;
    private int life;

    void Start()
    {
        life = vidas.Length;
        if (PlayerPrefs.GetFloat("checkPointPositionX") != 0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }

    private void ChecarVidas()
    {
        if (life < 1)
        {
            Destroy(vidas[0].gameObject);
            animator.Play("Hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        else if (life < 2)
        {
            Destroy(vidas[1].gameObject);
            animator.Play("Hit");

        }
        else if (life < 3)
        {
            Destroy(vidas[2].gameObject);
            animator.Play("Hit");

        }
    }

    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    public void PlayerDamaged()
    {
        //animator.Play("Hit");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        life--;
        ChecarVidas();
    }
}
