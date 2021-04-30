using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Transform bar;
    public GameManager manager;

    bool isStarting;

    // Start is called before the first frame update
    void Start()
    {
        isStarting = true;
    }

    // Update is called once per frame
    void Update()
    {
        //start the round
        if (Input.GetKeyDown(KeyCode.Space) && isStarting)
        {
            StartBallMovement();
            isStarting = false;
        }

        //die - help for end cases when the ball is too slow
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            BallDie();
        }

        //fix movment so the ball's velocity wont be only on the x or the y 
        if (GetComponent<Rigidbody2D>().velocity.x < 0.1f && GetComponent<Rigidbody2D>().velocity.x > -0.1f && isStarting == false)
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10);
        }
        if (GetComponent<Rigidbody2D>().velocity.y < 0.1f && GetComponent<Rigidbody2D>().velocity.y > -0.1f && isStarting == false)
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10);
        }
    }

    //give the ball a random force to the right or the left
    void StartBallMovement()
    {
        this.transform.SetParent(null);
        int dir = (Random.Range(0, 2) == 1) ? 1 : -1;
        this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300 + Vector2.right * 170 * dir);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Brick"))
        {
            manager.AddPoints(1);
            //show paricles befor destroying the object
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, 0.6f);
        }
        else if (collision.transform.CompareTag("Ground"))
        {
            BallDie();
        }
    }

    public void BallDie()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        this.transform.position = new Vector3(bar.position.x, bar.position.y + 0.44f, 0);
        this.transform.SetParent(bar);
        isStarting = true;
        manager.RemoveLife(1);
    }
}
