using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemy;

    public float MinumumSpeed;
    public float CurrentSpeed;
    public float MaximumSpeed;

    public float SpeedMultiplier;
    void Awake()
    {
        CurrentSpeed = MinumumSpeed;
        GenerateEnemy();
    }

    public void GenerateRandom()
    {
        float randomWait = Random.Range(0.1f, 1.2f);
        Invoke("GenerateEnemy", randomWait);
    }

    public void GenerateEnemy()
    {
        GameObject EnemyIns = Instantiate(enemy, transform.position, transform.rotation);
        EnemyIns.GetComponent<EnemyScript>().enemyGenerator = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentSpeed < MaximumSpeed)
        {
            CurrentSpeed += SpeedMultiplier;
        }
    }
}
