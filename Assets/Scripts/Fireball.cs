using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed;
    public float Lifetime;
    public float damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyFireball", Lifetime);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    void FixedUpdate()
    {
        MoveFixedUpdate();
    }
    private void MoveFixedUpdate()
    {
        transform.position += transform.forward*Speed*Time.fixedDeltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        EnemyDamage(collision);
        DestroyFireball();  
    }
    private void DestroyFireball()
    {
        Destroy(gameObject);
    }
    private void EnemyDamage(Collision collision)
    {
        var EnemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (EnemyHealth!=null)
        {
            EnemyHealth.DealDamage(damage);
        }
    }
}
