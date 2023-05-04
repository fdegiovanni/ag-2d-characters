using UnityEngine;

public class CreatureMover : MonoBehaviour
{
    public float maxSpeed = 3f;
    public float accelerationTime = 2f;

    private Rigidbody2D rigidBody;
    private float timeBetweenChangeDirection;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenChangeDirection -= Time.deltaTime;
        if(timeBetweenChangeDirection <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeBetweenChangeDirection += accelerationTime;
        }
    }

    void OnCollissionEnter2D(Collision2D col)
    {
        movement = -movement;
    }

    void FixedUpdate()
    {
        rigidBody.AddForce(movement * maxSpeed);
    }
}
