using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaquinaRefrigerante : MonoBehaviour
{
    [Header("UI")]
    public Button btnInserir;
    public Button btnCancelar;
    public Button btnComprar;
    public Text avisoTexto;
    public Button btnManutencao;


    [Header("Sistema")]
    public Animator animator;
    public GameObject compartimentoRefrigerantes;
    public Transform localSpawn;
    public GameObject prefabRefrigerante;
    public List<GameObject> refrigerantesVisuais = new List<GameObject>();

    [Header("Estado")]
    public bool emManutencao = false;
    public bool temMoeda = false;
    public int estoque = 0;

    void Start()
    {
        estoque = 0;
        AtualizarVisualEstoque();
        VerificarEstoque();
        animator.SetInteger("rerigerantes", estoque);
        animator.SetBool("estoquezerado", true);
    }

    public void InserirMoeda()
    {
        if (emManutencao || estoque <= 0) return;

        temMoeda = true;
        animator.SetBool("TemMoeda", true);
    }

    public void Cancelar()
    {
        temMoeda = false;
        animator.SetBool("TemMoeda", false);
        avisoTexto.text = "CANCELADO";
    }

    public void Comprar()
    {
        if (temMoeda && estoque > 0)
        {
           estoque--;
            AtualizarVisualEstoque();
            temMoeda = false;
            animator.SetBool("TemMoeda", false);
            animator.SetTrigger("Vender");

            animator.SetInteger("rerigerantes", estoque);
            animator.SetBool("estoquezerado", estoque <= 0);


        }
        else if (estoque <= 0)
        {
            avisoTexto.text = "VAZIO";
        }
    }

    public void AdicionarRefrigerante()
    {
        if (estoque >= 10) return; // limite opcional
        estoque++;

        GameObject lata = Instantiate(prefabRefrigerante, localSpawn.position, Quaternion.identity, localSpawn);
        refrigerantesVisuais.Add(lata);

        AtualizarVisualEstoque();

        animator.SetInteger("rerigerantes", estoque);
        animator.SetBool("estoquezerado", estoque <= 0);

    }

    public void AtualizarVisualEstoque()
    {
        // Destrói os visuais existentes
        foreach (GameObject lata in refrigerantesVisuais)
        {
            Destroy(lata);
        }
        refrigerantesVisuais.Clear();

        // Recria o estoque visual
        for (int i = 0; i < estoque; i++)
        {
            GameObject lata = Instantiate(prefabRefrigerante, localSpawn.position + Vector3.right * i * 0.2f, Quaternion.identity, localSpawn);
            refrigerantesVisuais.Add(lata);
        }
    }

    public void VerificarEstoque()
    {
       animator.SetInteger("rerigerantes", estoque);
        animator.SetBool("estoquezerado", estoque <= 0);

    }

    public void AbrirCompartimento()
    {
        compartimentoRefrigerantes.SetActive(true);
    }

    public void FecharCompartimento()
    {
        compartimentoRefrigerantes.SetActive(false);
    }
    public void AlternarManutencao()
{
    emManutencao = !emManutencao;
    animator.SetBool("EmManutencao", emManutencao);
}
}
