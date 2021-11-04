using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2Script : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public GameObject barrel;
    public GameObject pointR, pointL, pointM;
    public float timer = 0f;

    private AudioSource playerAudio;
    public AudioClip crash;

    // Start is called before the first frame update
    void Start()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        ScoreCounter scoreCounter = GameManager.GetComponent<ScoreCounter>();

        GameObject Car1 = GameObject.Find("Car1");
        ValueStorage totalPoints = Car1.GetComponent<ValueStorage>();

        speed = 7 + ((scoreCounter.score2 / (totalPoints.totalPoints)) * 2);

        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("HorizontalTwo");
        transform.Translate(Vector3.left * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.back * 5 * Time.deltaTime * speed);

        timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z) && timer <= 0)
        {
            Instantiate(barrel, pointL.transform.position, barrel.transform.rotation);
            timer = 2f;
        }

        if (Input.GetKeyDown(KeyCode.X) && timer <= 0)
        {
            Instantiate(barrel, pointM.transform.position, barrel.transform.rotation);
            timer = 2f;
        }

        if (Input.GetKeyDown(KeyCode.C) && timer <= 0)
        {
            Instantiate(barrel, pointR.transform.position, barrel.transform.rotation);
            timer = 2f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrel"))
        {
            Destroy(collision.gameObject);
           
            StartCoroutine(GotHit());
        }
    }

    IEnumerator GotHit()
    {
        playerAudio.PlayOneShot(crash, 1.0f);

        GameObject GameManager = GameObject.Find("GameManager");
        ScoreCounter scoreCounter = GameManager.GetComponent<ScoreCounter>();

        GameObject Car1 = GameObject.Find("Car1");
        ValueStorage totalPoints = Car1.GetComponent<ValueStorage>();

        speed = 7;
        yield return new WaitForSeconds(.5f);
        speed = 7 + ((scoreCounter.score2 / (totalPoints.totalPoints) * 2));
    }
}
