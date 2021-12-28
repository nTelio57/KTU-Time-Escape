using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeTravelController : MonoBehaviour
{
    [SerializeField]
    private SyncTransform Camera;

    [SerializeField]
    private Image GfxImage;

    private bool _isAnimating = false;

    private const float AnimationDuration = 0.5f;
    private const int AnimationFrameCount = 30;

    private float AnimationStepSize => AnimationDuration / (AnimationFrameCount * 1.0f);

    private void Update()
    {
        if (StateManager.IsLocked) return;
        if (ShouldTimeTravel())
        {
            StartCoroutine(DoTimeTravel());
        }
    }

    private bool ShouldTimeTravel()
    {
        return Input.GetKeyDown(KeyCode.Mouse1) && !_isAnimating;
    }

    private IEnumerator DoTimeTravel()
    {
        _isAnimating = true;


        for (int i = 0; i < AnimationFrameCount; i++)
        {
            var c = GfxImage.color;
            float alpha = (AnimationStepSize * i) / AnimationDuration;

            GfxImage.color = new Color(c.r, c.g, c.b, alpha);

            yield return new WaitForSeconds(AnimationStepSize);
        }

        transform.position += Camera.PositionOffset;
        Camera.InvertPositionOffset();

        for (int i = AnimationFrameCount; i >= 0; i--)
        {
            var c = GfxImage.color;
            float alpha = (AnimationStepSize * i) / AnimationDuration;
            GfxImage.color = new Color(c.r, c.g, c.b, alpha);

            yield return new WaitForSeconds(AnimationStepSize);
        }

        _isAnimating = false;
    }
}
