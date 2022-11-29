using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    public class StateDash : PlayerStateBase
    {
        bool isDash;
        float dashTimer;

        public override void OnEnter(Player owner, PlayerStateBase prevState)
        {
            isDash = false;
            dashTimer = 0;
        }

        public override void OnUpdate(Player owner)
        {
            // �_�b�V���t���O���܂�Ă�����
            if (!isDash)
            {
                // �_�b�V�������𖞂����Ă���
                if ((Input.GetKey(owner.dashKey) || Input.GetButton("Dash" + owner.playerNumber)) && owner.isGround && owner.stamina > owner.subStamina)
                {
                    // �R�X�g���x��������
                    owner.stamina -= owner.subStamina;
                    // �t���O������
                    isDash = true;
                    // �����蔻���L����
                    owner.dashCollObj.SetActive(true);

                    //�U�������������瓖���������̃X�^�~�i�����炷
                    GameObject StaminaDown = GameObject.Find("PlayerStamina");
                    StaminaDown.GetComponent<playerStamina>().StaminaDown(0.5f, owner.GetComponent<Player>().GetPlayerNumber());
                }
                // �������ĂȂ�
                else if(!(Input.GetKey(owner.dashKey) || Input.GetButton("Dash" + owner.playerNumber)) || !owner.isGround || owner.stamina <= owner.subStamina)
                {
                    // �_�b�V���U���������I������
                    owner.dashCollObj.SetActive(false);
                    owner.ChangeState(move);
                }
            }
            // �_�b�V���������s��
            owner.MoveProc(owner.inputValue, owner.velocity, owner.maxDashVel, owner.dashACC);
            // �ړ���������������
            owner.FaceFront();
            // ���Ԃ��v������
            dashTimer += Time.deltaTime;
            // ���Ԃ����̃_�b�V���̎��Ԃ𒴂��Ă�����
            if(dashTimer > owner.dashTimeOnce)
            {
                // �t���O��܂�
                isDash = false;
            }
        }
    }
}