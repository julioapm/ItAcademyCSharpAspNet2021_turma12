namespace Laboratorio6cs
{
    public enum EstadoBinario {Ligado, Desligado}
    public interface IEstadoBinario
    {
        void Ligar();
        void Desligar();
        EstadoBinario Estado {get;}
    }
}