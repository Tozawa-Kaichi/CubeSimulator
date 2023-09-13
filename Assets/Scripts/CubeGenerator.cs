using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab; // ��������L���[�u�̃v���n�u
    [SerializeField] private string _inputButton = "Fire1"; // ���[�U�[���͂����o����{�^����
    [SerializeField] private float _outlineWidth = 0.1f; // �֊s���̕�
    [SerializeField] private Color _outlineColor = Color.yellow; // �֊s���̐F
    [SerializeField] private float _blinkSpeed = 1.0f; // �_�ł̑���

    private bool _isOutlineVisible = false; // �֊s���̕\���t���O
    private Renderer _cubeRenderer; // �����L���[�u�̃����_���[
    private MaterialPropertyBlock _propertyBlock;

    private void Start()
    {
        _cubeRenderer = _cubePrefab.GetComponent<Renderer>();
        _propertyBlock = new MaterialPropertyBlock();
        SetOutlineVisible(true);
    }

    private void Update()
    {
        if (Input.GetButtonDown(_inputButton))
        {
            GenerateCube();
        }

        // �L���[�u�̈ʒu�ɗ֊s����\��
        if (_isOutlineVisible)
        {
            UpdateOutline();
        }
    }

    // �L���[�u�𐶐�����
    private void GenerateCube()
    {
        // ���̃X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g�̈ʒu�𐶐��ʒu�Ƃ��Ďg�p
        Vector3 spawnPosition = transform.position;

        GameObject newCube = Instantiate(_cubePrefab, spawnPosition, Quaternion.identity);

        Rigidbody cubeRigidbody = newCube.GetComponent<Rigidbody>();
        if (cubeRigidbody != null)
        {
            cubeRigidbody.useGravity = true;
        }
    }

    // �֊s���̕\����_�ł�����
    private void UpdateOutline()
    {
        // �֊s���̕���_�ł�����
        float outlineWidthOffset = Mathf.PingPong(Time.time * _blinkSpeed, _outlineWidth);
        SetOutlineWidth(outlineWidthOffset);
    }

    // �֊s���̕���ݒ肷��
    private void SetOutlineWidth(float width)
    {
        _propertyBlock.SetFloat("_OutlineWidth", width);
        _cubeRenderer.SetPropertyBlock(_propertyBlock);
    }

    // �֊s���̕\��/��\����؂�ւ���
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

        _cubeRenderer.SetPropertyBlock(_propertyBlock);
    }
}
