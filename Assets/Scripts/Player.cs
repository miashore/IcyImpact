using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public float speed;
    private float input;

    Rigidbody2D rb;
    Animator anim;

    public int health = 3;
    public Image[] hearts;

    public float startDashTime;
    private float dashTime;
    public float extraSpeed;
    private bool isDashing;

    private GameObject flame;
    private GameObject skull;
    public GameObject tryAgainButton;

    public AudioSource hitSound;
    public AudioSource deathSound;
    public AudioSource idleSound;

    // Start is called before the first frame update
    void Start () {
        anim = GetComponent<Animator> ();
        rb = GetComponent<Rigidbody2D> ();

        anim.SetBool ("isDead", false);
        flame = GameObject.Find ("/Player/flame");
        skull = GameObject.Find ("/Player/skull");

        // Handles health display
        GameObject canvas = GameObject.Find ("Canvas");
        if (canvas != null) {
            hearts = canvas.GetComponentsInChildren<Image> ();
        }
    }

    private void Update () {
        if (input != 0) {
            anim.SetBool ("isMoving", true);
        } else {
            anim.SetBool ("isMoving", false);
        }

        if (input > 0) {
            transform.eulerAngles = new Vector3 (transform.position.x, 180, 0);
        } else if (input < 0) {
            transform.eulerAngles = new Vector3 (transform.position.x, 0, 0);
        }

        if (Input.GetKeyDown (KeyCode.Space) && isDashing == false) {
            anim.SetBool ("isDashing", true);
            speed += extraSpeed;
            isDashing = true;
            dashTime = startDashTime;
        }

        if (dashTime <= 0 && isDashing == true) {
            anim.SetBool ("isDashing", false);
            isDashing = false;
            speed -= extraSpeed;
        } else {
            dashTime -= Time.deltaTime;
        }

        if (skull.transform.position.y <= -5.8) {
            Destroy (gameObject);
            tryAgainButton.SetActive (true);
        }

    }

    // Update is called once per frame
    // Physics need "Fixed"
    void FixedUpdate () {
        // Storing player input
        input = Input.GetAxis ("Horizontal");

        // Moving player
        rb.velocity = new Vector2 (input * speed, rb.velocity.y);

        if (health <= 0) {
            rb.velocity = new Vector2 (0, rb.velocity.y);
        }
    }

    public void TakeDamage (int damageAmount) {
        hitSound.Play ();

        // damageAmount comes from Enemy class
        health -= damageAmount;
        if (hearts.Length > 0 && health > -1) {
            // Removes heart display (3)
            hearts[health].enabled = false;
        }
        if (health <= 0) {
            deathSound.Play ();
            anim.SetBool ("isDead", true);
            flame.SetActive (false);
        }
    }

}