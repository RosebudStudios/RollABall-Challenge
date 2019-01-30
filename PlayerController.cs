using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {


    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;


    private Rigidbody rb;
    private int count;
    private int lives;


    private void Start()
    {
        rb =  GetComponent<Rigidbody>();
        count = 0;
        lives = 3;
        SetCountText();
        SetLivesText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce (movement * speed);
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            lives = lives - 1;
            SetLivesText();
        }
    }
    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();

        if (count == 14)
        {
            transform.position = new Vector3(-26.5f, 1, 44.56f);
        }

        if (count >= 24)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            winText.text = "Congratulations \n Press esc to exit";
        }
    }
    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();

        if (lives <= 0)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            winText.text = "You Lose \n Press R to restart";
        }
    }
}