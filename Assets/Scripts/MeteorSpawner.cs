using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] GameObject asteroid1;
    [SerializeField] GameObject asteroid2;
     [SerializeField] BoxCollider boxCollider;
     private PlayerMovement player;
 
     Vector3 cubeSize;
     Vector3 cubeCenter;

    float spawnRate = 3f;
    float timer;
    int counter;
    public bool shouldSpawn;
 
 
     private void Awake()
     {
         cubeCenter = boxCollider.gameObject.transform.position;
 
         // Multiply by scale because it does affect the size of the collider
         cubeSize.x = boxCollider.gameObject.transform.localScale.x * boxCollider.size.x;
         cubeSize.y = boxCollider.gameObject.transform.localScale.y * boxCollider.size.y;
         cubeSize.z = boxCollider.gameObject.transform.localScale.z * boxCollider.size.z;

         shouldSpawn = false;
     }
 
 
     private void Start()
     {
        timer = spawnRate;
        player = FindObjectOfType<PlayerMovement>();
     }

     void Update()
     {
        if (shouldSpawn)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = spawnRate;
                ShootMeteor();
                counter++;
                if (counter > 5)
                {
                    spawnRate -= 0.1f;
                    counter = 0;
                }
            }
        }
     }

     private void ShootMeteor()
     {
        int decide = Random.Range(0, 2);
        Rigidbody rb = Instantiate(decide == 1 ? asteroid1 : asteroid2, GetRandomPosition(), Quaternion.identity).GetComponent<Rigidbody>();
        Vector3 direction = player.gameObject.transform.position - rb.gameObject.transform.position;
        direction.Normalize();
        rb.velocity = direction * 200;
        rb.AddTorque(new Vector3 (Random.Range(0, 201), Random.Range(0, 201), Random.Range(0, 201)));
     }
 
 
     private Vector3 GetRandomPosition()
     {
         Vector3 randomPosition = new Vector3(Random.Range(-cubeSize.x, cubeSize.x), Random.Range(-cubeSize.y, cubeSize.y), Random.Range(-cubeSize.z, cubeSize.z));
        Debug.Log(randomPosition);
         return cubeCenter + randomPosition;
     }
}
