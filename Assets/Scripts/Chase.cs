using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    // �v���C���[
    public GameObject[] Players;
    // NavMeshAgent
    public NavMeshAgent agent;
    // �ǂ��Ώۂ��i�[
    public Transform target;

    public poiColor mPoiColor;


    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // �^�O����v���C���[��T��
        Players = GameObject.FindGameObjectsWithTag("Player");
        // �^�[�Q�b�g�������_���őI��
        target = Players[Random.Range(0, Players.Length)].transform;
        mPoiColor.ColorUpdate(target, Players[0], Players[1]);
    }

    // Update is called once per frame
    public void ChaseUpdate()
    {
        //Count += Time.deltaTime;
        //Debug.Log(UpCount);
        // �^�[�Q�b�g�̃|�W�V�����Ɍ�����
        agent.destination = target.position;
        //if(UpCount <= 5)
        //{
        //    agent.destination = new Vector3(0, 2.5f, 0);
        //}
    }

    /// <summary>
    /// �R���C�_�[�ɓ�������
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // �^�O���wPlayer�x�ł�������
        if(other.gameObject.tag == "Player")
        {
            // �^�[�Q�b�g�������_���ŕύX����
            target = Players[Random.Range(0, Players.Length)].transform;
        }
        mPoiColor.ColorUpdate(target, Players[0], Players[1]);
    }
}