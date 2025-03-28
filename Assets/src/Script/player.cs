using UnityEngine;
using UnityEngine.UI;
public class player : MonoBehaviour
{
    [SerializeField] private float jumpforce = 15f;
    private Rigidbody2D rb;
    private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    private Animator anim;
    [SerializeField] BoxCollider2D nornmalCollider;
    [SerializeField] CapsuleCollider2D duckCollider;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        nornmalCollider.enabled = true;
        duckCollider.enabled = false;
       

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = CheckIfGrounded();
        nhay();
        cui();
        phat_am_thanh();
    }
    private bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius); 
    }
    public void nhay()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = Vector2.up * jumpforce;
        }
    }
    public void cui()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            nornmalCollider.enabled = false;
            duckCollider.enabled = true;
            anim.SetBool("isDuck", true);
        }else if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            nornmalCollider.enabled = true;
            duckCollider.enabled = false;
            anim.SetBool("isDuck", false);
        }
    }
    private void phat_am_thanh()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            AudioManeger.instance.SoundJump();
        }
        if(isGrounded && !AudioManeger.instance.Phat_nhac())
        {
            AudioManeger.instance.SoundTap();
            AudioManeger.instance.set_phat_effect(true);
        }else if(!isGrounded)
        {
            AudioManeger.instance.set_phat_effect(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("obstacles"))
        {
            AudioManeger.instance.SoundHurt();
        }
    }
   
   
}
