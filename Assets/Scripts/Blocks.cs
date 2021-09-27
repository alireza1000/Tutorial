using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

//[ExecuteInEditMode]
public partial class Blocks : MonoBehaviour
{
    float grid = 1.1f;

    private TextMesh _textMesh;

    public bool Searched = false;
    public Blocks SearchBlocks;

    private Blocks Previous;

    private GameObject color;

    Vector3 editPos;

    void Update()
    {
        editPos.x = Mathf.RoundToInt(transform.position.x / grid) * grid;
        editPos.z = Mathf.RoundToInt(transform.position.z / grid) * grid;

        transform.position = new Vector3(editPos.x, 0, editPos.z);

        _textMesh = GetComponentInChildren<TextMesh>();

        String label = _textMesh.text = editPos.x / grid + "," + editPos.z / grid;

        gameObject.name = label;
    }

    public Vector3 GetPosition()
    {
        editPos.x = Mathf.RoundToInt(transform.position.x / grid) * grid;
        editPos.z = Mathf.RoundToInt(transform.position.z / grid) * grid;

        Vector3 Positin = new Vector3(editPos.x / grid, 0, editPos.z / grid);

        return Positin;
    }

    public void top(Color c)
    {
        var top = transform.Find("Top").GetComponent<MeshRenderer>();
        top.material.color = c;
    }
}