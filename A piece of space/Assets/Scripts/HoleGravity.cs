using UnityEngine;

public class HoleGravity : MonoBehaviour
{
    const float GravityConstant = 5f;
    public GameObject[] Affectors;
    private Rigidbody2D Body;
    private float Dist;
    private uint i;
    public static float x_speed = 0.1f;
    

    void Start()
    {
        Main.a = 1;
        Body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position = transform.position;
        position.x -= x_speed;
        transform.position = position;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        ScoreCounter score = other.GetComponent<ScoreCounter>();
        Main player = other.GetComponent<Main>();

        if (score != null)
        {
            Main.a = 0;
            score.BlackScoreCount();
            Destroy(gameObject);
        }

        if (player != null)
        {
            Main.a = 0;
            player.BlackDamage();
            Destroy(gameObject);
        }
    }
}
