using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSpawn : MonoBehaviour
{
    public float spawn_delay = 1f;
    public GameObject prefab;
    public Vector2 volume;
    public float max_start_time_delay;
    public float min_start_time_delay;
    private float time_delay = 0.5f;
    private Vector2 spawn_point;

    
    
    void Start()
    {
        time_delay = Random.Range(min_start_time_delay, max_start_time_delay);
        spawn_point = transform.position;
    }
    
    void Update()
    {
        if (time_delay <= 0)
        {
            if (Main.onFire == false)
            {
               StartCoroutine(Spawn_());
               time_delay = Random.Range(min_start_time_delay, max_start_time_delay); 
            }
            
        }
        else
        {
            time_delay -= Time.deltaTime;
        }
    }
    
    IEnumerator Spawn_()
    {
        
        int spawn_count = 1;
        GameObject parent = new GameObject();
        while (spawn_count > 0)
        {
            spawn_count -= 1;
            Vector3 pos = new Vector3(spawn_point.x,
                Random.Range(spawn_point.y - volume.y, spawn_point.y + volume.y));
            GameObject obj = Instantiate(prefab, pos, Quaternion.identity, parent.transform);
            yield return new WaitForSeconds(spawn_delay);
        }
    }
}
