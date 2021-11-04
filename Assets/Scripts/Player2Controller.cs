using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float horizontalInput;

    public float speed = 10.0f;

    public bool isOnGround;

    private Rigidbody playerRb;

    public float jumpForce;

    public float gasCounter2;

    private AudioSource playerAudio;

    public AudioClip jump;

    public AudioClip pickup;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        isOnGround = true;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("HorizontalTwo");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed, Space.World);

        Vector3 movementDirection = new Vector3(0, 0, -horizontalInput);
        movementDirection.Normalize();

        if (Input.GetKeyDown(KeyCode.Keypad4) && isOnGround || Input.GetKeyDown(KeyCode.Alpha4) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAudio.PlayOneShot(jump, 1.0f);
        }

        if (movementDirection != Vector3.zero)
        {
            transform.forward = movementDirection;
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
            scoreCounter.score2 = scoreCounter.score2 + 5;
            GameObject Car1 = GameObject.Find("Car1");
            ValueStorage totalPoints = Car1.GetComponent<ValueStorage>();
            totalPoints.totalPoints = totalPoints.totalPoints + 5;
            playerAudio.PlayOneShot(pickup, 1.0f);

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Small gas"))
        {
            GameObject GameManager = GameObject.Find("GameManager");
            ScoreCounter scoreCounter = GameManager.GetComponent<ScoreCounter>();
            scoreCounter.score2 = scoreCounter.score2 + 2;
            GameObject Car1 = GameObject.Find("Car1");
            ValueStorage totalPoints = Car1.GetComponent<ValueStorage>();
            totalPoints.totalPoints = totalPoints.totalPoints + 2;
            playerAudio.PlayOneShot(pickup, 1.0f);

            Destroy(collision.gameObject);
        }
    }
}
