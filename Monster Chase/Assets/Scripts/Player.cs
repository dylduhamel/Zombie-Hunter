using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // adjustable movement and jumping parameters
    // serialised lets it be private but still public from inside unity
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    // map boundaries
    [SerializeField]
    private float minX, maxX;

    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    // animation 
    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    // to test if sprite is in the air
    private bool isGrounded;
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    // Start is called before the first frame update
    void Start() {
        // attaching component from plaer to myBody - the same as dragging player into field in unity
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }


    // gets input and makes adjustments
    void PlayerMoveKeyboard() {
        movementX = Input.GetAxisRaw("Horizontal"); 

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

        if (transform.position.x > maxX) {
            transform.position = new Vector3(maxX, transform.position.y, 0f);
        }
        if (transform.position.x < minX) {
            transform.position = new Vector3(minX, transform.position.y, 0f);
        }
    }

    void AnimatePlayer() {
        // if moving right
        if(movementX > 0 ) {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        } 
        // if moving left
        else if(movementX < 0 ) {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        } 
        else {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    // gets input for jumping
    void PlayerJump() {
        if(Input.GetButtonDown("Jump") && isGrounded) {
            isGrounded = false;
            // adding a vertical jump (jumpforce is hardcoded but public) and impulse is a fast boost
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    
    // called when two rigidbodys or colliders are touching
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag(GROUND_TAG)) {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG)) {
                // destroys the player
                Destroy(gameObject);
        }
    
     }

    // using this because the ghost is supposed to be able to pass through other objects so it is not a solid like the zombies
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetType() != typeof(BoxCollider2D)) {
            if (collision.gameObject.CompareTag(ENEMY_TAG))
            Destroy(gameObject);
        }
    }
   
}
