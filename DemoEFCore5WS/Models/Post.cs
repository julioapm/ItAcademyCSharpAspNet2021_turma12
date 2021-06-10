namespace DemoEFCore5WS.Models
{
    public class Post
    {
        //chave primária
        public int Id {get;set;}
        public string Titulo {get;set;}
        //chave estrangeira
        public int BlogId {get;set;}
        //relacionamento muitos para um
        public Blog Blog {get;set;}
    }
}