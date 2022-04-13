using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie1Controller : MonoBehaviour
{
    bool Saltando = false; 
    public float Velocity = 0;
    public float JumpForce = 10;

    private static readonly string Animator_State = "Estado";

    private static readonly int Animation_Jump = 0;

    private Rigidbody2D rigidbody;
    private Animator animator;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

     void Update()
    {
        var velocidadActualX = rigidbody.velocity.x;
        var velocidadActualY = rigidbody.velocity.y;

        if (!Saltando)
        {
            rigidbody.AddForce(Vector2.up * JumpForce);
            Saltando = true;
        }
    }
    private void Change_Animation(int Animation)
    {
        animator.SetInteger(Animator_State, Animation);
    }
    

private void OnCollisionEnter2D(Collision2D other)
{
    if (other.gameObject.CompareTag("SueloFlotante"))
    {
        Saltando = false;
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
    }
}
}
