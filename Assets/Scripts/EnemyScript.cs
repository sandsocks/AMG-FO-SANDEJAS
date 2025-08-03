using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public EnemyGenerator enemyGenerator;
    private Transform target;
    void Start()
    {
        GameObject finishLineObject = GameObject.FindWithTag("finishLine");

        if (finishLineObject != null)
        {
            target = finishLineObject.transform;
        }
    }
    void Update()
    {
        //transform.Translate(Vector2.left * enemyGenerator.CurrentSpeed * Time.deltaTime);
        
        if (target != null)
        {
            var direction = (target.position - transform.position).normalized;
            this.transform.position += direction * enemyGenerator.CurrentSpeed * Time.deltaTime;
        }
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
