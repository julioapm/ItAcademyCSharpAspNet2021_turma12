namespace Laboratorio4cs
{
    public class CirculoColorido : Circulo
    {
        public string Cor {get;set;}
        public CirculoColorido(double x, double y, double r, string c)
        : base(x,y,r)
        {
            Cor = c;
        }
        public override string ToString()
        {
            return base.ToString() + $" cor={Cor}";
        }
    }
}