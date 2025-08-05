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

    RaycastHit hit;
    int layerMask = 1 << 9;
    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
        Time.timeScale = 1;
    }
    void Update()
    {
        //Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - (GetComponent<Collider2D>().bounds.extents.y));
        //RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, groundCheckDistance, groundLayer);

        if (Physics.Raycast(transform.position,Vector2.down, out hit,Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.yellow);
            Debug.Log("Not Grounded");
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.red);
            Debug.Log("Grounded");
        }    

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
                Debug.Log("Not Alive");
            }
        }      
    }
}
