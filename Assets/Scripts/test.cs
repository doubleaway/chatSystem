using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    private float moveSpeed = 4.0f;//�̵� �ӵ�
    
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");//������
        float y = Input.GetAxisRaw("Vertical");//���Ʒ�
        //���ο� ��ġ
        transform.position += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;
    }
}
