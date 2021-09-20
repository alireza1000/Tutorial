using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


    [ExecuteInEditMode]
    public class Editor : MonoBehaviour
    {
        [SerializeField] [Range(1f, 50f)] private float grid = 10f;

        private TextMesh _textMesh;

        void Update()
        {
            Vector3 editPos;
            editPos.x = Mathf.RoundToInt(transform.position.x / grid) * grid;
            editPos.z = Mathf.RoundToInt(transform.position.z / grid) * grid;

            transform.position = new Vector3(editPos.x, 0f, editPos.z);

            _textMesh = GetComponentInChildren<TextMesh>();

            _textMesh.text = editPos.x + "," + editPos.z;
        }
    }

