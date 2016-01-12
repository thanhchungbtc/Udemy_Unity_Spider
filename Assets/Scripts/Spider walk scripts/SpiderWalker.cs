using UnityEngine;
using System.Collections;

public class SpiderWalker : MonoBehaviour {


    public float speed = 1f;

    [SerializeField]
    private Transform startPos, endPos;

    private bool collision;

    private Rigidbody2D myBody;

    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        Move();
        ChangeDirection();
    }

    void Move() {
        myBody.velocity = new Vector2(transform.localScale.x, 0) * speed;
        
    }

    void ChangeDirection() {
        collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));

        Debug.DrawLine(startPos.position, endPos.position, Color.green);

        if (!collision) {
            Vector3 temp = transform.localScale;
            if (temp.x == 1f) {
                temp.x = -1f;
            } else {
                temp.x = 1f;
            }

            transform.localScale = temp;
        }
    }

    void OnCollisionEnter2D(Collision2D target) {
        if (target.gameObject.tag == "Player") {
            Destroy(target.gameObject);
        }
    }
}
