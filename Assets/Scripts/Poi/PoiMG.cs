using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoiMG : MonoBehaviour
{
    private float mTime;
    private bool ScoopFlag;

    public Chase mChase;
    public Animator mAnim;
    public Animator mAnim2;
    public CatchScript mCatch;

    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        mTime = 0.0f;
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
   {
        mCatch.CatchUpdate();

        if (ScoopFlag)
        { 
            ScoopFlag = false;
            mChase.agent.speed = 15.0f;
            mTime += Time.deltaTime;
            if(mTime >= 15.0f)
            {
                mTime = 0.0f;
                // ターゲットをランダムで変更する
                mChase.target = mChase.Players[Random.Range(0, mChase.Players.Length)].transform;
            }
        }
        else
        {
            mChase.ChaseUpdate();
        }
    }

    /// <summary>
    /// コライダーに入ったら
    /// </summary>
    /// <param name="other">コライダー</param>
    private void OnTriggerEnter(Collider other)
    {
        // タグが『Player』であったら
        if (transform.parent == null && other.tag == "Player" && !ScoopFlag)
        {
            ScoopFlag = true;
            var empty = new GameObject();
            empty.transform.parent = other.gameObject.transform;
            mAnim.SetBool("scoop", true);
            mAnim2.SetBool("scoop", true);
        }
        else
        {
            mAnim.SetBool("scoop", false);
            mAnim2.SetBool("scoop", false);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        // タグが『Player』であったら
        if (transform.parent != null && other.tag == "Player")
        {
            transform.parent = null;
            //mAnim.SetBool("scoop", false);
            //mAnim2.SetBool("scoop", false);
        }
    }
}


