using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deth : MonoBehaviour
{
    //[SerializeField]
    //private GameObject player1;

    //[SerializeField]
    //private GameObject player2;
    [SerializeField]
    private Deth myPlayer;

    [SerializeField]
    private Deth elsePlayer;

    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private GameObject elsePanel;

    [SerializeField]
    private GameObject[] gage;

    private void Start()
    {
        myPlayer = myPlayer.GetComponent<Deth>();
        elsePlayer = elsePlayer.GetComponent<Deth>();
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag == "DethBox")
    //    {
    //        panel.SetActive(true);
    //        elsePanel.SetActive(false);
    //        elsePlayer.enabled = false;
    //        myPlayer.enabled = false;
    //    }

    //}

    private void Update()
    {
        if(panel.activeInHierarchy == true)
        {
            elsePanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DethBox")
        {
            panel.SetActive(true);
            elsePanel.SetActive(false);
            elsePlayer.enabled = false;
            myPlayer.enabled = false;

            for(int i = 0; i < gage.Length; i++)
            {
                gage[i].SetActive(false);
            }
        }
    }

}
