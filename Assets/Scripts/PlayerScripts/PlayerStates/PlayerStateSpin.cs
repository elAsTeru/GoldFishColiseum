using UnityEngine;

public partial class Player
{
    public class StateSpin : PlayerStateBase
    {
        public override void OnEnter(Player owner, PlayerStateBase prevState)
        {
            owner.timeCounter = 0;
            owner.spinCollObj.SetActive(true);
        }
        public override void OnUpdate(Player owner)
        {
            owner.timeCounter += Time.deltaTime;
            if(owner.timeCounter > owner.spinTimeOnce)
            {
                owner.spinCollObj.SetActive(false);
                owner.ChangeState(idol);
            }
        }
    }
}