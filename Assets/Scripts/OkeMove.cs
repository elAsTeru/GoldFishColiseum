using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkeMove : MonoBehaviour
{
    [SerializeField]
    //public Transform target;
    public float speed;

    private int XZRand;
    Vector3 Point;
    [SerializeField]float MaxX = 20.0f;
    [SerializeField]float MinX = -20.0f;
    [SerializeField] float MaxZ = 7.2f;
    [SerializeField] float MinZ = -7.2f;

    // Start is called before the first frame update
    void Start()
    {
        //�ړ��n�_�̏�����(Y���W�͌Œ�)
        Point = new Vector3(0.0f, this.transform.position.y, 0.0f);

        //�ړ��n�_�������_���Ɏ擾
        RandomPoint();
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ����x
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, Point, step);

        Vector3 pos = Point;

        //float test = Vector3.Distance(target.position, pos);
        transform.LookAt(pos);

        //�ړ��n�_�ɒ�������ړ��n�_�������_���ɕύX����
        if (Vector3.Distance(transform.position, pos) < 0.5f)
        {
            RandomPoint();
        }
    }

    //�ړ��n�_�������_���Ɍ��߂�֐�
    void RandomPoint()
    {
        XZRand = Random.Range(0, 4);

        if (XZRand == 0) //������
        {
            Point.x = Random.Range(MinX, MaxX);
            Point.z = MinZ;
        }
        else if (XZRand == 1) //�����
        {
            Point.x = Random.Range(MinX, MaxX);
            Point.z = MaxZ;
        }
        else if (XZRand == 2) //������
        {
            Point.x = MinX;
            Point.z = Random.Range(MinZ, MaxZ);
        }
        else if (XZRand == 3) //�E����
        {
            Point.x = MaxX;
            Point.z = Random.Range(MinZ, MaxZ);
        }
    }
}
