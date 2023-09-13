using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] GameObject _cubePrefab; // ��������L���[�u�̃v���n�u
    [SerializeField] string _inputButton = "Fire1"; // ���[�U�[���͂����o����{�^����
    [SerializeField] Material _previewMaterial; // �v���r���[�I�u�W�F�N�g�̃}�e���A��

    private GameObject _previewCube; // �����ʒu�̃v���r���[�I�u�W�F�N�g

    private void Start()
    {
        CreatePreviewCube();
    }

    private void Update()
    {
        if (Input.GetButtonDown(_inputButton))
        {
            GenerateCube();
        }

        // �v���r���[�I�u�W�F�N�g���W�F�l���[�^�[�̈ʒu�ɕ\��
        _previewCube.transform.position = transform.position;
    }

    // �v���r���[�I�u�W�F�N�g�̍쐬
    private void CreatePreviewCube()
    {
        _previewCube = Instantiate(_cubePrefab, Vector3.zero, Quaternion.identity);

        // �v���r���[�I�u�W�F�N�g�̃����_���[���擾
        Renderer previewRenderer = _previewCube.GetComponent<Renderer>();

        // �����_���[�Ƀv���r���[�}�e���A����K�p
        previewRenderer.material = _previewMaterial;
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
}
