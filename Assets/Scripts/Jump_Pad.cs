using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jump_Pad : MonoBehaviour
{
    [SerializeField] private float bounce = 20f;
    private enum JumpPadState { idle, jumping }

    private Animator JumpPadAnim;

    private void Start()
    {
        JumpPadAnim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        JumpPadState state;
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            state = JumpPadState.jumping;
        }
        else
        {
            state = JumpPadState.idle;
        }
        JumpPadAnim.SetInteger("state", (int)state);
        state = 0;
        JumpPadAnim.SetInteger("state", (int)state);
    }

}
