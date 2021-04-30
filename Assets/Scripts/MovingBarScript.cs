using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBarScript : MonoBehaviour
{
    public float speed = 1f;

    float movment;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movment = Input.GetAxisRaw("Horizontal");
        this.transform.Translate(new Vector3(movment * speed * Time.deltaTime, 0, 0));
        if (transform.position.x > 2)
        {
            transform.position = new Vector2(2.3f, transform.position.y);
        }
        if (transform.position.x < -2)
        {
            transform.position = new Vector2(-2.3f, transform.position.y);
        }
    }
}
