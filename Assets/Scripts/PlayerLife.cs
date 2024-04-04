using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;

    [SerializeField] public GameObject[] heart;
    [SerializeField] private int life;

    private Vector2 StartPos;

    public int Life
    {
        get { return life; }
        set { life = value; }
    }

    private void Start()
    {
        life = heart.Length;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        lifeCount();
    }

    private void Respawn()
    {
        transform.position = StartPos;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void lifeCount()
    {
        if (life != 1)
        {
            life--;
            heart[life].SetActive(false);
        }
        else
        {
            SceneManager.LoadScene("End Scene");
        }
    }

    public GameObject[] GetHeartArray()
    {
        return heart;
    }
}
