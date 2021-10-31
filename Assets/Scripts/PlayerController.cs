using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput;

    public float speed = 10.0f;

    public bool isOnGround;

    private Rigidbody playerRb;

    public float jumpForce;

    public float gasCounter;

    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        isOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Gas"))
        {
            GameObject GameManager = GameObject.Find("GameManager");
            ScoreCounter scoreCounter = GameManager.GetComponent<ScoreCounter>();
            scoreCounter.score += 5;
            gasCounter = gasCounter + 5;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Small gas"))
        {
            GameObject GameManager = GameObject.Find("GameManager");
            ScoreCounter scoreCounter = GameManager.GetComponent<ScoreCounter>();
            scoreCounter.score += 2;
            gasCounter = gasCounter + 2;
            Destroy(collision.gameObject);
        }
    }
}