using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    List<Character> characterList = new List<Character>();
    GameObject springBoard;
    int characterListIndex = 0;
    bool isStart = false;
    bool isJumping = false;
    bool isReady = false;
    GameObject target;

    // 1. ����ĳ����
    // ĳ���� ����Ʈ -> ������ -> �� (StartPoint -> EndPoint)

    // ĳ���Ͱ� EndPoint�� ������� (��������)
    // �ش� EndPoint�� �ݰ� ������ ������? ��ġ
    // �̹� ���� EndPoint�� ������ �õ��� ��� �ٽ� ���� ����

    private void Awake()
    {
        GameManager.instance = this;
        CharacterListInit();
        springBoard = GameObject.Find("SpringBoard");


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            FillSpringBoard();

            if (isJumping)
            {
                Vector3 targetPos = target.transform.localPosition; 
                Camera.main.transform.position = new Vector3(targetPos.x, targetPos.y, -10);
            }
        }
        
    }

    public void GameStart()
    {
        foreach(Character character in characterList)
        {
            character.GetComponent<SpriteRenderer>().flipX = true;
            character.DefaultSize();
            isStart = true;
        }

        Camera.main.transform.position = new Vector3(0, 0, -10);
    }
    public void CharacterListInit()
    {
        Transform characters = GameObject.Find("Characters").transform;

        for (int i = 0; i < characters.childCount; i++)
        {
            characterList.Add(characters.GetChild(i).GetComponent<Character>());
        }
        characterList[0].SizeUp();
    }

    void IndexCheck() 
    {
        if (characterListIndex > characterList.Count-1)
        {
            characterListIndex = 0;
        }

        if(characterListIndex < 0)
        {
            characterListIndex = characterList.Count-1;
        }
    }

    public void NextCharacterSelect()
    {
        characterList[characterListIndex++].DefaultSize();
        IndexCheck();
        characterList[characterListIndex].SizeUp();
    }

    public void PrevCharacterSelect()
    {
        characterList[characterListIndex--].DefaultSize();
        IndexCheck();
        characterList[characterListIndex].SizeUp();
    }

    public void FillSpringBoard()
    {
        if (springBoard.transform.childCount == 0 && characterList.Count >0 && !isReady)
        {
            characterList[0].transform.parent = springBoard.transform;
            Invoke("SpringBoardMove", 1.0f);
        }
        
    }

    public void SpringBoardMove()
    {
        springBoard.transform.GetChild(0).localPosition = new Vector3(0, 0, 0);
        springBoard.transform.GetChild(0).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        characterList.RemoveAt(0);
        isReady = true;

    }

    public void JumpCharacter()
    {
        if (springBoard.transform.childCount > 0 && isReady)
        {
            Vector2 force = new Vector2(0, 2000f);
            Transform ch = springBoard.transform.GetChild(0);
            target = ch.gameObject;
            Rigidbody2D rb2D = ch.GetComponent<Rigidbody2D>();
            rb2D.AddForce(force);
            rb2D.AddTorque(5f);
            ch.parent = null;
            isJumping = true;
        }
        
    }

    public void JumpEnd()
    {
        isReady = false;
        isJumping = false;
        Camera.main.transform.position = new Vector3(1, -2, -10);
    }

    // �ٴ�, ��ü1, ��ü2 ��������
    // �ٴڰ� ��ü1 �浹��
    // ��ü1�� ��ü2 �浹 X �浹���� ��

}
