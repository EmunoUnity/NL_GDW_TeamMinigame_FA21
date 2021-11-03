using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2Script : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        ScoreCounter scoreCounter = GameManager.GetComponent<ScoreCounter>();

        GameObject Car1 = GameObject.Find("Car1");
        ValueStorage totalPoints = Car1.GetComponent<ValueStorage>();

        speed = 7 + (scoreCounter.score / (totalPoints.totalPoints / 2));
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("HorizontalTwo");
        transform.Translate(Vector3.left * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.back * 5 * Time.deltaTime * speed);
    }
}
