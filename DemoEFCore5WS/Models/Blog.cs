using System.Collections.Generic;

namespace DemoEFCore5WS.Models
{
    public class Blog
    {
        //chave primária
        public int Id {get;set;}
        public string Nome {get;set;}
        //Relacionamento um para muitos
        public List<Post> Posts {get;set;}
    }
}