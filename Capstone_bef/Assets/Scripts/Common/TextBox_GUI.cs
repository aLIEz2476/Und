using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TextBox_GUI : MonoBehaviour {

    public string textFileName; // 대본 파일명 
    public float sec; // 1글자 당 출력 시간
    public Text textInfo; // 대사 내용
    public Text textName; // 대사를 말하는 등장인물
    private bool standby; // 중복실행 방지
    private TextAsset ta; // 텍스트 에셋
    private int line; // 행 구분 변수
    private string s; // 임시 저장 스트링 변수

    // Use this for initialization
    void Start () {
        line = 0;
        standby = true;
        ta = Resources.Load<TextAsset>("Scinario/" + textFileName);
        s = ta.text;
	}
	
    public void print()
    {
        if (standby)
            StartCoroutine("textprint");
    }

    IEnumerator textprint()
    {
        standby = false;
        textName.text = textInfo.text = string.Empty;
        int cnt = 0; char[] c = division(s);
        textName.text = nameCheck(c[0]);
        for (cnt = 2; cnt < c.Length; cnt++)
        {
            textInfo.text += c[cnt].ToString();
            yield return new WaitForSeconds(sec);
        }
        standby = true;
    }

    char[] division(string script)
    {
        char[] c = script.ToCharArray();
        script = string.Empty;
        char[] sct = string.Empty.ToCharArray();
        for (int i = line; i < c.Length; i++)
        {
            script = string.Format(script + c[i].ToString());
            if (c[i] == '\r')
            {
                line = i + 2;
                sct = script.ToCharArray();
                break;
            }
        }
        return sct;
    }

    string nameCheck(char c)
    {
        switch(c)
        {
            case '크':
                return "크론델";
            case '말':
                return "말콘트";
            case '가':
                return "가르콘테";
            default:
                return null;
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
