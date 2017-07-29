using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float Speed;

    // Update is called once per frame
    void Update()
    {
        GameObject generator = FindNearestGenerator();
        Vector3 currentPos = gameObject.transform.position;

        if (generator != null)
        {
            Vector3.MoveTowards(currentPos, generator.transform.position, Time.deltaTime * Speed);
            return;
        }

        GameObject player = FindNearestPlayer();

        if (player != null)
        {
			Vector3.MoveTowards(currentPos, player.transform.position, Time.deltaTime * Speed);
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
}
