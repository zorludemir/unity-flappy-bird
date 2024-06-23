using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float flapForce;
    public float forwardSpeed;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2 (forwardSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.velocity = new Vector2(forwardSpeed, 0);
            rb.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(0);
    }
}
