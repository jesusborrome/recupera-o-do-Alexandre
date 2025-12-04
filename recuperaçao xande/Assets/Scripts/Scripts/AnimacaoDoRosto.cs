using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnimacaoDoRosto : MonoBehaviour
{

    //agrupa  as imagens dos personagens
    [Header("imagem")]
    public GameObject[] Imagens;

    public void MostraPersonagem(int id)
    {
        foreach (var img in Imagens)
            img.SetActive(false);

        if (id >= 0 && id < Imagens.Length)
            Imagens[id].SetActive(true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
