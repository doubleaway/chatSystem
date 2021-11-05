using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float speed;
    public GameManager manager;
    // Start is called before the first frame update
    float h;
    float v;
    bool isHorizonMove;
    Rigidbody2D rigid;
    Animator anim;
    Vector3 dirVec;
    GameObject scanObject;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //move value
        h = manager.isAction?0:Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        //check button down&up
        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonDown("Vertical");

        //check horizontal move
        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;
        //Animation
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("isChange", false);
        }


        //direction
        if (vDown && v == 1)
            dirVec = Vector3.up;
        else if (vDown && v == -1)
            dirVec = Vector3.down;
        else if (hDown && h == -1)
            dirVec = Vector3.left;
        else if (hDown && h == 1)
            dirVec = Vector3.right;

        //scan obj
        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            //Debug.Log(scanObject.name);
            manager.Action(scanObject);
           
        }
           
    }

     void FixedUpdate()
    {
        //move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;
        //ray
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f,LayerMask.GetMask("object"));
        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }
}
