using UnityEngine;

public class ItensColetaveis : MonoBehaviour
{
    public bool itemDeEscudo;

    public bool itemDeLaserDuplo;

    public bool itemDeVida;

    public int VidaParaDar;
    private void OnTriggerEnter2D(Collider2D Colison)
    {
        if(Colison.gameObject.CompareTag("Player"))
        {
            if(itemDeEscudo == true)
            {
                Colison.gameObject.GetComponent<VidaDoPlayer>().AtivarEscudo();
            }
            if(itemDeLaserDuplo == true)
            {
                Colison.gameObject.GetComponent<Playermove>().temLaserDuplo = false;

                Colison.gameObject.GetComponent<Playermove>().TempoAtualDosLasersDuplos = 
                Colison.gameObject.GetComponent<Playermove>().TempoMaximoDosLasersDuplos;
                
                Colison.gameObject.GetComponent<Playermove>().temLaserDuplo = true;
            }
            if(itemDeVida == true)
            {
                Colison.gameObject.GetComponent<VidaDoPlayer>().GanharVida(VidaParaDar);
            }

            Destroy(this.gameObject);
        }
    }

}
