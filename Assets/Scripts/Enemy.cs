using UnityEngine;

public class Enemy: MonoBehaviour
{
    public float speed = 2f;
    public Transform tower;

    void Update()
    {
        if (tower == null) return;

        // move toward the tower
        Vector3 direction = (tower.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}