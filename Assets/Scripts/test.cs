using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    private float moveSpeed = 4.0f;//이동 속도
    
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");//조ㅏ우
        float y = Input.GetAxisRaw("Vertical");//위아래
        //새로운 위치
        transform.position += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;
    }
}
