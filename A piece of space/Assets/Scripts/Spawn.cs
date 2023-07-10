using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float spawn_delay = 1f;
    public GameObject prefab;
    public Vector2 volume;
    public float start_time_delay;
    private float time_delay = 0.5f;
    private Vector2 spawn_point;
    public static int max_spawn_count = 2;
    public static int min_spawn_count = 1;
    
    
    void Start()
    {
        time_delay = start_time_delay;
        spawn_point = transform.position;
    }
    
    void Update()
    {
        if (time_delay <= 0)
        {
            StartCoroutine(Spawn_());
            time_delay = start_time_delay;
        }
        else
        {
            time_delay -= Time.deltaTime;
        }

        if (ScoreCounter.score > 200)
        {
            max_spawn_count = 3;
        }
        if (ScoreCounter.score > 5000)
        {
            min_spawn_count = 2;
        }
    }
    
    IEnumerator Spawn_()
    {
        
        int spawn_count = Random.Range(min_spawn_count, max_spawn_count);
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
