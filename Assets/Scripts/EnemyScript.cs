using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public EnemyGenerator enemyGenerator;
    void Update()
    {
        transform.Translate(Vector2.left * enemyGenerator.CurrentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextLine"))
        {
            enemyGenerator.GenerateRandom();
        }

        if (collision.gameObject.CompareTag("finishLine"))
        {
            Destroy(this.gameObject);
        }
    }
}
