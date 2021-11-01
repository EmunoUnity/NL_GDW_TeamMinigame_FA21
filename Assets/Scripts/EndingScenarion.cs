using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScenarion : MonoBehaviour
{
    public bool Player1Wins;

    public bool Player2Wins;

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
        if (collision.gameObject.CompareTag("Player 1"))
        {
            Player1Wins = true;
            Debug.Log("Player 1 Wins!");
        }

        if(collision.gameObject.CompareTag("Player 2"))
        {
            Player2Wins = true;
            Debug.Log("Player 2 Wins!");
        }
    }
}
