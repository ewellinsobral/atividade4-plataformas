using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MaquinaRefrigerante : MonoBehaviour
{
    [SerializeField] private Animator compartimentoAnimator; 
    public Animator animator;

    public Button btnInserir;
    public Button btnCancelar;
    public Button btnComprar;
    public Button btnManutencao;

    public GameObject compartimentoRefrigerantes;
    public GameObject lataPrefab;
    public Transform saidaRefrigerante;

    public TextMeshProUGUI avisoTexto;

    private int estoque = 0;
    private bool emManutencao = false;
    private bool temMoeda = false;

    void Start()
    {
        if (compartimentoAnimator == null)
        {
            Debug.LogWarning("Animator do compartimento não atribuído!");
        }

        AtualizarInterface();

        
        btnInserir.onClick.AddListener(() =>
        {
            if (emManutencao)
            {
                estoque++;
                CriarLatinhaVisual();
                animator.SetTrigger("abasteceu");
                VerificarEstoque();
            }
            else if (!temMoeda && estoque > 0)
            {
                temMoeda = true;
                animator.SetTrigger("inseriuMoeda");
            }

            AtualizarInterface();
        });

        btnCancelar.onClick.AddListener(() =>
        {
            if (temMoeda && !emManutencao)
            {
                temMoeda = false;
                animator.SetBool("manutencaoAtivada", false);
                animator.Play("SemMoeda");
            }
        });

        btnComprar.onClick.AddListener(() =>
        {
            if (temMoeda && estoque > 0 && !emManutencao)
            {
                temMoeda = false;
                estoque--;
                animator.SetTrigger("despejar");

                
                AbrirCompartimento();

                Invoke(nameof(SoltarLatinha), 1.5f);
                VerificarEstoque();
            }
        });

        btnManutencao.onClick.AddListener(() =>
        {
            emManutencao = !emManutencao;
            animator.SetBool("manutencaoAtivada", emManutencao);
            AtualizarInterface();
        });
    }

    public void AbrirCompartimento()
    {
        compartimentoAnimator.SetTrigger("Abrir");
    }

    public void FecharCompartimento()
    {
        compartimentoAnimator.SetTrigger("Fechar");
    }

    void AtualizarInterface()
    {
            if (AvisoTexto != null){
        if (emManutencao)
        {
            avisoTexto.text = "MANUTENÇÃO";
        }
        else if (estoque == 0)
        {
            avisoTexto.text = "VAZIO";
        }
        else if (temMoeda)
        {
            avisoTexto.text = "OK";
        }
        else
        {
            avisoTexto.text = "";
        }
            }
            else
    {
     Debug.LogWarning("AvisoTexto está nulo!");
    }

        compartimentoRefrigerantes.SetActive(emManutencao);
    }

    void VerificarEstoque()
    {
        animator.SetBool("estoquezerado", estoque == 0);
    }

    void CriarLatinhaVisual()
    {
        Instantiate(lataPrefab, compartimentoRefrigerantes.transform);
    }

    void SoltarLatinha()
    {
        Instantiate(lataPrefab, saidaRefrigerante.position, Quaternion.identity);
        AtualizarInterface();

       
        FecharCompartimento();
    }
}

