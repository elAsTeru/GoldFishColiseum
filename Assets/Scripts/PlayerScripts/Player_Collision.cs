using UnityEngine;

public partial class Player
{
    [Header("当たり判定")]
    [Tooltip("ダッシュ攻撃あたり判定が入ったオブジェクト")][SerializeField] GameObject dashCollObj;
    [Tooltip("回転攻撃当たり判定が入ったオブジェクト")][SerializeField] GameObject spinCollObj;

    private void OnCollisionEnter(Collision collision)
    {
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != this.gameObject && other.tag == this.tag)
        if(state == dash)
        {
                mgr.AttackProc(this.gameObject, other.gameObject, PlayerMgr.AtkState.Dash);
        }
        else if(state == spin)
        {
                mgr.AttackProc(this.gameObject, other.gameObject, PlayerMgr.AtkState.Spin);
        }

        state = idol;
    }
}