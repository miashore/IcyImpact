using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float minSpeed;
    public float maxSpeed;
    float speed;

    Player playerScript;

    public int damage;

    public GameObject[] explosions;

    // Start is called before the first frame update
    void Start () {
        speed = Random.Range (minSpeed, maxSpeed);

        // Allows us to reference another script/class and use their public properties and methods
        GameObject player = GameObject.FindGameObjectWithTag ("Player");
        if (player != null) {
            playerScript = player.GetComponent<Player> ();
        }
    }

    // Update is called once per frame
    void Update () {
        transform.Translate (Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D (Collider2D hitObject) {
        // Randomizes the explosion particle effects attached to hazard objects
        GameObject randomExplosion = explosions[Random.Range (0, explosions.Length - 1)];

        if (hitObject.tag == "Player") {
            playerScript.TakeDamage (damage);
            Destroy (gameObject);
            Instantiate (randomExplosion, transform.position, Quaternion.identity);
        }

        if (hitObject.tag == "Ground") {
            Destroy (gameObject);
            Instantiate (randomExplosion, transform.position, Quaternion.identity);
        }
    }
}