namespace Laboratorio6cs
{
    public class Termometro
    {
        private double temperatura;
        public virtual double Temperatura => temperatura;//propriedade de leitura
        public virtual void Aumentar(double t)
        {
            temperatura += t;
        }
        public virtual void Diminuir(double t)
        {
            temperatura -= t;
        }
    }

    public class TermometroEletrico : Termometro, IEstadoBinario
    {
        private bool ligado = true;
        public EstadoBinario Estado => ligado?EstadoBinario.Ligado:EstadoBinario.Desligado;

        public void Desligar()
        {
            ligado = false;
        }

        public void Ligar()
        {
            ligado = true;
        }

        public override void Aumentar(double t)
        {
            if (ligado) base.Aumentar(t);
        }

        public override void Diminuir(double t)
        {
            if (ligado) base.Diminuir(t);
        }

        public override double Temperatura
        {
            get
            {
                if (ligado) return base.Temperatura;
                throw new System.Exception();
                //return double.NaN;
            }
        }
    }
}