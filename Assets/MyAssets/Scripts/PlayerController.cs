using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // get components
    protected Animator playerAnim;
    protected Rigidbody playerRb;
    protected GameManager gameManger;
    // jump
    [SerializeField] protected float jumpForce = 5.0f;
    protected bool isOnGround = true;
    protected bool canDoubleJump = true;
    [SerializeField] protected float gravityModifier;
    [SerializeField] protected AudioSource jumpSound;

    // game over
    public bool gameOver = false;
    [SerializeField] protected ParticleSystem deadParticle;
    [SerializeField] protected AudioSource hitSound;

    [SerializeField] protected AudioSource switchSound;
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerRb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }
    protected void GroundPound()
    {
        if (!canDoubleJump || !isOnGround)
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x, -10f, playerRb.velocity.z);
        }
    }
    protected void Jump()
    {
        if (canDoubleJump)
        {
            canDoubleJump = false;
        }
        else
        {
            isOnGround = false;
        }
        // recommended jump force: 1000
        //playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Force);

        // recommended jump force: 5
        playerRb.velocity = new Vector3(playerRb.velocity.x, jumpForce, playerRb.velocity.z);
        playerAnim.SetTrigger("JumpTrig");
        jumpSound.Play();
    }

    // check player is on ground
    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            canDoubleJump = true;
        }
    }

    // check player collides with obstacle
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            deadParticle.Play();
            playerAnim.SetBool("Dead", true);
            gameOver = true;
            gameManger.setGameOver = true;
            hitSound.Play();
        }
        if (other.gameObject.CompareTag("Switcher"))
        {
            switchSound.Play();
        }
    }
}
