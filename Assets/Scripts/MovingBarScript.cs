using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBarScript : MonoBehaviour
{
    public float speed = 1f;

    float movment;
    float sideLimmit = 2.3f;

    // Update is called once per frame
    void Update()
    {
        //moving the bar with the arrow keys
        movment = Input.GetAxisRaw("Horizontal");
        this.transform.Translate(new Vector3(movment * speed * Time.deltaTime, 0, 0));

        //keep the bar from moving outside the map
        if (transform.position.x > sideLimmit)
        {
            transform.position = new Vector2(sideLimmit, transform.position.y);
        }
        if (transform.position.x < -sideLimmit)
        {
            transform.position = new Vector2(-sideLimmit, transform.position.y);
        }
    }
}
