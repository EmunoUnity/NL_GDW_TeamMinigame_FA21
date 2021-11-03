using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingScenarion : MonoBehaviour
{
    public bool Player1Wins;

    public bool Player2Wins;

    public bool deciding = true;

    public Image backdrop;

    public Text win1;

    public Text restart1;

    public Text win2;

    public Text restart2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player1") && deciding == true)
        {
            Player1Wins = true;
            deciding = false;
            Debug.Log("Player 1 Wins!");
            backdrop.enabled = true;
            win1.enabled = true;
            restart1.enabled = true;
        }

        if(collision.gameObject.CompareTag("Player2") && deciding == true)
        {
            Player2Wins = true;
            deciding = false;
            Debug.Log("Player 2 Wins!");
            backdrop.enabled = true;
            win2.enabled = true;
            restart2.enabled = true;
        }

        if (deciding == false && Input.GetKeyDown(KeyCode.Keypad2))
        {
            SceneManager.LoadScene(0);
        }
    }
}
