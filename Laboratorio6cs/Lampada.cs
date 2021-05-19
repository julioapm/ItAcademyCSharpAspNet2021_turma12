namespace Laboratorio6cs
{
    public class Lampada : IEstadoBinario
    {
        private bool ligada;
        private int voltagem;
        private int potencia;
        public Lampada(int v, int p)
        {
            ligada = false;
            voltagem = v;
            potencia = p;
        }
        //public EstadoBinario Estado => throw new System.NotImplementedException();
        public EstadoBinario Estado
        {
            get
            {
                if (ligada) return EstadoBinario.Ligado;
                else return EstadoBinario.Desligado;
            }
        }
        public int Voltagem => voltagem;
        public int Potencia => potencia;
        public void Desligar()
        {
            ligada = false;
        }

        public void Ligar()
        {
            ligada = true;
        }
    }
}