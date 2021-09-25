using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 500f;
    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
   private void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        this.rigidbody.velocity = Vector2.zero;
        this.transform.position = Vector2.zero;

        Invoke(nameof(SetRandomTrajectory), 1f);
    }
    private void SetRandomTrajectory()
    {
        Vector2 force = new Vector2();
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        this.rigidbody.AddForce(force.normalized * this.speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
