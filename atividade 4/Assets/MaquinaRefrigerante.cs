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

    public int estoque = 2;
    public bool emManutencao = false;
    public bool temMoeda = false;

    void Start()
    {
       // AtualizarInterface();

        
        btnInserir.onClick.AddListener(() =>
        {
            if (emManutencao)
            {
                estoque++;
               // CriarLatinhaVisual();
                animator.SetTrigger("abasteceu");
             //   VerificarEstoque();
            }
            else if (!temMoeda && estoque > 0)
            {
                temMoeda = true;
                animator.SetTrigger("inseriuMoeda");
            }

          //  AtualizarInterface();
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

                
             //   AbrirCompartimento();

             //   Invoke(nameof(SoltarLatinha), 1.5f);
             //   VerificarEstoque();
            }
        });

        btnManutencao.onClick.AddListener(() =>
        {
            emManutencao = !emManutencao;
            animator.SetBool("manutencaoAtivada", emManutencao);
            //AtualizarInterface();
        });
    }

}