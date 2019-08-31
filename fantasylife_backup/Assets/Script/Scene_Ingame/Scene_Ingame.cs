using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Scene_Ingame : MonoBehaviour, EventListener {
    public Canvas canvas_Base;
    public Image imgFade;

    public Terrian terrian;

    [Serializable]
    public struct StatusSprites {
        public int type;
        public Sprite[] sprites;
    }

    [Header("UI")]
    public Text txtTime;
    public Text txtMinute;
    public Text txtNoon;

    public Image[] imgStatus;

    [Header("UI Sprites")]
    public List<StatusSprites> mapSprites;

    public void Awake() {
        EventManager.instance = new EventManager();
        EventManager.instance.AddListener(this);

        GameManager.instance = new GameManager();
        GameManager.instance.Awake();
    }

    public void FixedUpdate() {
        txtTime.text = string.Format("{0:D2}", GameManager.gamehour % 12).ToString(); // 시간 표시
        txtMinute.text = string.Format("{0:D2}", GameManager.gameminute).ToString(); // 분 표시

        GameManager.instance.FixedUpdate();
    }

    private void RefreshNoonUI() {
        if (GameManager.gamehour < 12) // AM이면
            txtNoon.GetComponent<Text>().text = "AM";
        else //PM 이면
            txtNoon.GetComponent<Text>().text = "PM";
    }

    private void RefreshStatusUI(int type) {
        if (imgStatus.Length <= type)
            return;

        var data = mapSprites.Find(x => x.type == type);
        imgStatus[type].sprite = data.sprites[Mathf.Min(data.sprites.Length, Mathf.Max(0, (int)GameManager.instance.GetParam(type) / 30 - 1))];
    }

    public void MoveMapToID(int id) {
        Sequence seq = DOTween.Sequence();
        seq.Append(imgFade.DOFade(1f, 0.5f));
        seq.OnComplete(() => {
            terrian.ChangeData(id);
            imgFade.DOFade(0f, 0.5f);
        });
        seq.Play();
    }

    public void HandleEvent(GameEvent e) {
        switch (e.type) {
            case GameEventType.REFRESH_NOON:
                RefreshNoonUI();
                break;
            case GameEventType.REFRESH_STATUS:
                var type = (int)e.args[0];
                RefreshStatusUI(type);
                break;
        }
    }
}
