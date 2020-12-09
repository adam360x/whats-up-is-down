using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D box;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float dropTime;
    public float noCollideTime;
    public float destroyTime;
    public float respawnTime;
    private bool isGrounded;
    private Vector2 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        startPos = gameObject.transform.position;
    }

    void OnCollisionEnter2D(Collision2D col) {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.10f, whatIsGround);
        if(col.gameObject.tag.Equals("Player") && isGrounded){
            Invoke("DropPlatform", dropTime);
            Invoke("NoCollidePlat", noCollideTime);
            Invoke("DestroyPlat", destroyTime);
            Invoke("RespawnPlat", respawnTime);
        }
    }

    void NoCollidePlat() {
        box.enabled = false;
    }

    void DropPlatform(){
        rb.isKinematic = false;
        rb.mass = 100;
        rb.gravityScale = 5;
    }

    void DestroyPlat(){
        gameObject.SetActive(false);
    }

    void RespawnPlat(){
        rb.isKinematic = true;
        box.enabled = true;
        gameObject.transform.position = startPos;
        gameObject.SetActive(true);
    }
  
}
