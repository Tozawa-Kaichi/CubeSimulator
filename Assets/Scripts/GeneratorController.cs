using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f; // �ړ����x
    [SerializeField] private float ascendSpeed = 5.0f; // �㏸���x
    [SerializeField] private float descendSpeed = 5.0f; // ���~���x

    private void Update()
    {
        // �W�F�l���[�^�[�̈ړ�
        MoveGenerator();

        // �W�F�l���[�^�[�̏㏸�Ɖ��~
        AscendDescendGenerator();
    }

    private void MoveGenerator()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �ړ��x�N�g���̌v�Z
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        moveDirection.Normalize();

        // �W�F�l���[�^�[�̈ړ�
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void AscendDescendGenerator()
    {
        // �W�F�l���[�^�[�̏㏸
        if (Input.GetButtonDown("Jump")) // Jump �{�^���̓f�t�H���g�ŃX�y�[�X�L�[�Ƀ}�b�v����Ă��܂�
        {
            transform.Translate(Vector3.up * ascendSpeed * Time.deltaTime);
        }
        // �W�F�l���[�^�[�̉��~
        else if (Input.GetButtonDown("Fire3")) // Fire3 �{�^���̓f�t�H���g�ō�Shift�Ƀ}�b�v����Ă��܂�
        {
            transform.Translate(Vector3.down * descendSpeed * Time.deltaTime);
        }
    }
}
