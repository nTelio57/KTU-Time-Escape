using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Safe : MonoBehaviour
{
    [SerializeField]
    private Animator Animator;
    public string Code;
    [SerializeField]
    private Text CodeText;
    private string _currentCode;

    private bool _isInputEnabled = true;

    public void OnNumPadClick(string num)
    {
        if (!_isInputEnabled)
            return;

        _currentCode += num;
        CodeText.text = _currentCode;

        if(_currentCode.Equals(Code))
            Unlock();
        else if (_currentCode.Length == 4)
        {
            StartCoroutine(WrongCode());
        }
    }

    IEnumerator WrongCode()
    {
        _isInputEnabled = false;
        for (int i = 0; i < 6; i++)
        {
            _currentCode = i % 2 == 0 ? "xxxx" : "";
            CodeText.text = _currentCode;
            yield return new WaitForSeconds(0.5f);
        }
        _isInputEnabled = true;
    }

    public void OnDeleteClick()
    {
        _currentCode = _currentCode.Remove(_currentCode.Length - 1);
        CodeText.text = _currentCode;
    }

    public void Unlock()
    {
        _isInputEnabled = false;
        Animator.SetBool("IsOpen", true);
    }
}
