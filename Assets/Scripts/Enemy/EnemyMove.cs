using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float Speed;
    public bool AttackPlayerAlways;

    private Rigidbody2D rigidBody;
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        GameObject generator = FindNearestGenerator();
        Vector3 currentPos = gameObject.transform.position;

        if (generator != null && !AttackPlayerAlways)
        {
            Vector2 direction = generator.transform.position - transform.position;
            rigidBody.AddRelativeForce(direction.normalized * Speed, ForceMode2D.Force);
            return;
        }

        GameObject player = FindNearestPlayer();

        if (player != null)
        {
            Vector2 direction = player.transform.position - transform.position;
            rigidBody.AddRelativeForce(direction.normalized * Speed, ForceMode2D.Force);
            return;
        }

    }

    private GameObject FindNearestGenerator()
    {
        return FindNearestObjectOfType(Tag.Generator);
    }

    private GameObject FindNearestPlayer()
    {
        return FindNearestObjectOfType(Tag.Player);
    }

    private GameObject FindNearestObjectOfType(string type)
    {
        float minDist = Mathf.Infinity;

        Vector2 pos = gameObject.transform.position;

        GameObject generator = null;
        GameObject[] generators = GameObject.FindGameObjectsWithTag(type);

        foreach (var gen in generators)
        {
            float dist = Vector2.Distance(gen.transform.position, pos);

            if (dist < minDist)
            {
                minDist = dist;
                generator = gen;
            }
        }

        return generator;
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == Tag.Generator || collision.gameObject.tag == Tag.Player){
            Vector2 direction = transform.position - collision.transform.position;
            rigidBody.AddRelativeForce(direction.normalized * 2000);
        }
    }
}
