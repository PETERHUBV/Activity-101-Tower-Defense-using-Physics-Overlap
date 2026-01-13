using UnityEngine;

public class PhysicsTrigger : MonoBehaviour
{

    public float damage = 50f;
    public MeshRenderer enemyMesh;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SphereCollider sc = gameObject.AddComponent<SphereCollider>();
        sc.isTrigger = true;
        sc.radius = 5f;
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Damaged enemy;" + other.name);
        }
        void Update()
        {

        }
    }
}