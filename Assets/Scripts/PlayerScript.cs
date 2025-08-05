using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce;
    
    float score;

    [SerializeField]
    bool isGrounded = false;
    bool isAlive = true;

    Rigidbody2D RB;

    public TMP_Text ScoreText;
    public GameOverUI gameOverUI;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
                Debug.Log("Not Grounded");
            }

        }

        if (isAlive)
        {
            score += Time.deltaTime * 4;
            ScoreText.text = score.ToString("F");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
                Debug.Log("Grounded");
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isAlive)
            {
                isAlive = false;
                gameOverUI.GameOver();
                Time.timeScale = 0;
                Debug.Log("Game Over");
            }
        }      
    }
}
