using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject _cubePrefab; // ��������L���[�u�̃v���n�u
    public string _inputButton = "Fire1"; // ���[�U�[���͂����o����{�^����

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GenerateCube();
        }
    }

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