using UnityEngine;

public class GeneratorOutline : MonoBehaviour
{
    [SerializeField] private float _outlineWidth = 0.1f; // �֊s���̕�
    [SerializeField] private Color _outlineColor = Color.yellow; // �֊s���̐F
    [SerializeField] private float _blinkSpeed = 1.0f; // �_�ł̑���

    private bool _isOutlineVisible = false; // �֊s���̕\���t���O
    private Renderer _generatorRenderer; // �W�F�l���[�^�[�̃����_���[
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

    // �֊s���̕\����_�ł�����
    private void UpdateOutline()
    {
        if (_isOutlineVisible)
        {
            // �֊s���̕���_�ł�����
            float outlineWidthOffset = Mathf.PingPong(Time.time * _blinkSpeed, _outlineWidth);
            SetOutlineWidth(outlineWidthOffset);
        }
    }

    // �֊s���̕���ݒ肷��
    private void SetOutlineWidth(float width)
    {
        _propertyBlock.SetFloat("_OutlineWidth", width);
        _generatorRenderer.SetPropertyBlock(_propertyBlock);
    }

    // �֊s���̕\��/��\����ݒ肷��
    public void ToggleOutline()
    {
        _isOutlineVisible = !_isOutlineVisible;
        SetOutlineVisible(_isOutlineVisible);
    }

    // �֊s���̕\��/��\����ݒ肷��
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
