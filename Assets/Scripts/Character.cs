using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // ���� �Ŵ��������� char���� list�� �����Ѵ�.

    // ��ư�� ������ �̹� ĳ������ isSelected = false���ǰ�
    // index++ �Ǹ鼭 list�� �ش�� ĳ���͵��� isSelected = true�� �ȴ�.
    // ���� ĳ������ isSelected�� true��� ĳ������ Scale�� Ŀ����.

    // Update������ ȣ���ϸ� ����ؼ� isSelected�� �˻��ؾ��ϴϱ�
    // �׳� ��ư�� �Լ��� ����?
    public string name;

    private void Awake()
    {

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SizeUp()
    {
        transform.localScale = new Vector3(1.0f, 2.0f, 1);
    }

    public void DefaultSize()
    {
        transform.localScale = new Vector3(0.5f, 1.0f, 1);
    }
    
    
}
