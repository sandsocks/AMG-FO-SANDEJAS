using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
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
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isAlive)
            {
                isAlive = false;
                gameOverUI.GameOver();
                Time.timeScale = 0;
            }
        }      
    }
}
