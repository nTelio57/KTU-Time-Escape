using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfTrigger : MonoBehaviour
{
    public Bookshelf Bookshelf;
    private bool _trapUsed;
    private void OnTriggerEnter(Collider other)
    {
        if (!_trapUsed)
        {
            Bookshelf.Trigger();
            _trapUsed = true;
        }
    }
}
