using UnityEngine;

public class PhysicsOverlap : MonoBehaviour
{

    public float radius = 5f;
    public float checkTime = 2.5f;
    public GameObject Player;

    Transform target;
    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        // every 2–3 seconds, check for enemies
        if (timer >= checkTime)
        {
            timer = 0f;
            FindNearestEnemy();
        }

        // if target is out of range or destroyed, find a new one
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) > radius)
            {
                FindNearestEnemy();
            }
        }
    }

    void FindNearestEnemy()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);

        float closestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (Collider hit in hits)
        {
            if (!hit.CompareTag("Enemy")) continue;

            float distance = Vector3.Distance(
                hit.transform.position,
                Player.transform.position
            );

            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestEnemy = hit.transform;
            }
        }

        target = nearestEnemy;

        if (target != null)
        {
            Debug.Log("Target enemy: " + target.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}