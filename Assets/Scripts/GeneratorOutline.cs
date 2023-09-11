using UnityEngine;

public class GeneratorOutline : MonoBehaviour
{
    [SerializeField] private float _outlineWidth = 0.1f; // 輪郭線の幅
    [SerializeField] private Color _outlineColor = Color.yellow; // 輪郭線の色
    [SerializeField] private float _blinkSpeed = 1.0f; // 点滅の速さ

    private bool _isOutlineVisible = false; // 輪郭線の表示フラグ
    private Renderer _generatorRenderer; // ジェネレーターのレンダラー
    private MaterialPropertyBlock _propertyBlock;

    private void Start()
    {
        _generatorRenderer = GetComponent<Renderer>();
        _propertyBlock = new MaterialPropertyBlock();
        SetOutlineVisible(false);
    }

    private void Update()
    {
        UpdateOutline();
    }

    // 輪郭線の表示を点滅させる
    private void UpdateOutline()
    {
        if (_isOutlineVisible)
        {
            // 輪郭線の幅を点滅させる
            float outlineWidthOffset = Mathf.PingPong(Time.time * _blinkSpeed, _outlineWidth);
            SetOutlineWidth(outlineWidthOffset);
        }
    }

    // 輪郭線の幅を設定する
    private void SetOutlineWidth(float width)
    {
        _propertyBlock.SetFloat("_OutlineWidth", width);
        _generatorRenderer.SetPropertyBlock(_propertyBlock);
    }

    // 輪郭線の表示/非表示を設定する
    public void ToggleOutline()
    {
        _isOutlineVisible = !_isOutlineVisible;
        SetOutlineVisible(_isOutlineVisible);
    }

    // 輪郭線の表示/非表示を設定する
    private void SetOutlineVisible(bool visible)
    {
        if (visible)
        {
            _propertyBlock.SetFloat("_OutlineWidth", _outlineWidth);
            _propertyBlock.SetColor("_OutlineColor", _outlineColor);
        }
        else
        {
            _propertyBlock.SetFloat("_OutlineWidth", 0f);
        }

        _generatorRenderer.SetPropertyBlock(_propertyBlock);
    }
}
