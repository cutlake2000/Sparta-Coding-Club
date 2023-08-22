using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBoard : MonoBehaviour
{
    Vector2 springJumpPower = new Vector2(-10f, 1000f);
    float springTurnPower = 2.0f;
    public bool isReady = false;

    void Start()
    {
        FillSpringBoard();
    }

    public void FillSpringBoard()
    {
        GameObject characterList = GameManager.Instance.CharacterList;
        if (transform.childCount == 0 && characterList.transform.childCount > 0 && !isReady)
        {
            characterList.transform.GetChild(0).transform.parent = transform;
            SpringBoardMove();
        }

        // ĳ���� ����Ʈ�� ù ��Ҹ�
        // SpringBoard�� Child�� ������ ��
        // SpringBoardMove()

    }

    public void SpringBoardMove()
    {
        transform.GetChild(0).localPosition = new Vector3(0, 0, 0);
        transform.GetChild(0).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        transform.GetChild(0).GetComponent<Character>().DefaultSize();
        transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        isReady = true;

        // child�� ���� ��ġ�� �̵���Ų��
        // RigidBody�� z�� ������ Ǯ���ش�.
        // isReady�� true�� �Ǿ �غ� �Ϸ�ȴ�.
    }

    public void JumpCharacter()
    {
        if (isReady)
        {
            isReady = false;
            Rigidbody2D rb2D = transform.GetChild(0).GetComponent<Rigidbody2D>();

            rb2D.AddForce(springJumpPower);
            rb2D.AddTorque(springTurnPower);

            transform.GetChild(0).GetComponent<Character>().isJumping = true;
            transform.GetChild(0).parent = null;
            
            

            // child���� ���� ���ؼ� jump��Ű��
            // SpringBoard ������ ��������.
        }

    }
}
