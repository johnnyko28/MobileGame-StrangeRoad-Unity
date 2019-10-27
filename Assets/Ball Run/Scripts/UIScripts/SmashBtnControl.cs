using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SmashBtnControl : MonoBehaviour
{
    TextMeshProUGUI text;

    PlayerControl player
    {
        get
        {
            return MainObjControl.Instant.playerCtrl;
        }
    }

    private void Start()
    {
        GetComponent<Image>().color = new Color(0.3f, 0.4f, 0.6f); // ��ʼ��ť�û�
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Smash()
    {
        player.Smashtime = 5.0;
        if (!player.smashing)
            MainCanvas.Instance.inGameScript.DecrScore();
            StartCoroutine(DoSmash());
    }

    IEnumerator DoSmash()
    {
        player.SetSmash(true);
        GetComponent<Image>().color = new Color(1, 1, 1); // ���߰�ť����ʱ��ԭΪ��ɫ
        text.fontSize = 72;
        float waittime = 0.1f;
        while (player.Smashtime > 0)
        {
            text.text = ((int)player.Smashtime + 1).ToString() + "s";
            yield return new WaitForSeconds(waittime);
            player.Smashtime -= waittime;
        }
        text.fontSize = 45;
        //text.text = "Smash";
        text.text = "";  // �������
        player.SetSmash(false);
        GetComponent<Image>().color = new Color(0.3f, 0.4f, 0.6f); // ���������ť�û�
    }
}
