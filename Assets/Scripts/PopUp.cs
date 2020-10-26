using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

/// Class that represents all popups in the game. Have basic functions for all popups such as Show and Hide. Parent of all popups
public class PopUp : MonoBehaviour
{
    [SerializeField] private GameObject _popUpBody;
    [SerializeField] private Image _darkBg;
    [SerializeField] private bool _hideOnStart = true;

    //Not all popups have dark background above them, so there is check for if background is null to avoid errors
    private bool _isDarkBgNotNull;

    public virtual void Start()
    {
        _isDarkBgNotNull = _darkBg != null;
        if (_hideOnStart)
        {
            Reset();
        }
    }

    /// <summary>
    /// Starts the coroutine for delayed popup show animation
    /// </summary>
    /// <param name="delay">delay before animation</param>
    public void Show(float delay)
    {
        StartCoroutine(ShowDelayed(delay));
    }

    private IEnumerator ShowDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayPopOutAnimation();
    }

    /// <summary>
    /// Starts the coroutine for delayed popup hide animation and then destroys the gameObject of the popup
    /// </summary>
    /// <param name="delay">delay before animation</param>
    protected void Hide(float delay)
    {
        StartCoroutine(HideDelayed(delay));
    }

    private IEnumerator HideDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayPopInAnimation();
    }

    /// <summary>
    /// Resets popup state by scaling it size to 0 and fading background to 0
    /// </summary>
    private void Reset()
    {
        _popUpBody.transform.DOScale(0f, 0f);
        if (_isDarkBgNotNull) _darkBg.DOFade(0f, 0f);
    }

    private void PlayPopOutAnimation()
    {
        if (_isDarkBgNotNull) _darkBg.DOFade(1f, 0.3f);
        _popUpBody.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);
    }

    void PlayPopInAnimation()
    {
        if (_isDarkBgNotNull) _darkBg.DOFade(0f, 0.3f);
        _popUpBody.transform.DOScale(0f, 0.3f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}
