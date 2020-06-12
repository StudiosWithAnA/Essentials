using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour
{
    public TextMeshPro textMesh;
    void Start()
    {

    }

    
    void Update()
    {
        float speed = 10f;
        transform.position += new Vector3(0, speed) * Time.deltaTime;
    }

    public void Make(int Damage)
    {
        textMesh.text = Damage.ToString();
    }

    public void setCG(TMP_ColorGradient CG)
    {
        textMesh.colorGradientPreset = CG;
    }

}
