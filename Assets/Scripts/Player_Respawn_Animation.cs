using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Respawn_animatin : MonoBehaviour
{
    private Animator respawn;
    private float lifecount = 0f;

    void Start()
    {
        respawn = GetComponent<Animator>();
        respawn_animation();
    }    

    private void respawn_animation()
    {
        lifecount++;
        respawn.SetFloat("alive", lifecount);
    }
}
