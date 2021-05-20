using System;

namespace DemoEventos
{
    class Program
    {
        static void Main(string[] args)
        {
            Contador c = new Contador(3);
            c.ValorAtingido += (origem, dados) => {
                Console.WriteLine(origem);
                Console.WriteLine("Bum!");
            };
            for(int i=0; i<5; i++)
            {
                c.Incrementar();
                Console.WriteLine(c.Valor);
            }
            Console.WriteLine("Fim");
        }
    }

    class Contador
    {
        private int valorAlvo;
        public event EventHandler ValorAtingido;
        public int Valor {get; private set;}
        public Contador(int v)
        {
            valorAlvo = v;
        }
        public void Incrementar()
        {
            Valor++;
            if (Valor == valorAlvo)
            {
                var e = EventArgs.Empty;
                OnValorAtingido(e);
            }
        }
        protected virtual void OnValorAtingido(EventArgs e)
        {
            if (ValorAtingido != null)
            {
                ValorAtingido(this, e);
            }
        }
    }
}
