using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class TitleScreenManager : MonoBehaviour
{
    public RectTransform TitleScreen, GameInfo, Settings;
    public float uiSlideSpeed;
    // Start is called before the first frame update
    void Start()
    {
        TitleScreen.DOAnchorPos(Vector2.zero, 0.25f);
        uiSlideSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameInfoButton()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(TitleScreen.DOScale(Vector2.zero, 1f));
        seq.Append(TitleScreen.DOAnchorPos(new Vector2(0, -1920), uiSlideSpeed).SetEase(Ease.Linear));
        GameInfo.DOAnchorPos(Vector2.zero, uiSlideSpeed).SetEase(Ease.Linear);
    }

    public void closeGameInfo()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(GameInfo.DOScale(Vector2.zero, 0.5f));
        seq.Append(GameInfo.DOAnchorPos(new Vector2(0, 1080), uiSlideSpeed).SetEase(Ease.Linear));
        seq.Append(GameInfo.DOScale(Vector2.one, 0.5f));
        Sequence seq2 = DOTween.Sequence();
        seq2.Append(TitleScreen.DOAnchorPos(Vector2.zero, uiSlideSpeed).SetEase(Ease.Linear));
        seq2.Append(TitleScreen.DOScale(Vector2.one, 0.5f));
    }

    public void SettingsButton()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(TitleScreen.DOScale(Vector2.zero, 1f));
        seq.Append(TitleScreen.DOAnchorPos(new Vector2(0, 1920), uiSlideSpeed).SetEase(Ease.Linear));
        Settings.DOAnchorPos(Vector2.zero, uiSlideSpeed).SetEase(Ease.Linear);
    }

    public void closeSettings()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(Settings.DOScale(Vector2.zero, 0.5f));
        seq.Append(Settings.DOAnchorPos(new Vector2(19200, 0), uiSlideSpeed).SetEase(Ease.Linear));
        seq.Append(Settings.DOScale(Vector2.one, 0.5f));
        Sequence seq2 = DOTween.Sequence();
        seq2.Append(TitleScreen.DOAnchorPos(Vector2.zero, uiSlideSpeed).SetEase(Ease.Linear));
        seq2.Append(TitleScreen.DOScale(Vector2.one, 0.5f));
    }
}