using System.Collections.Generic;
using System;

namespace DemoEFCore5WS.Dtos
{
    public class BlogDTO
    {
        public int Id {get;set;}
        public string Nome {get;set;}
        public List<PostDTO> Posts {get;set;}
        public DateTime UltimaAtualizacao {get;set;}
    }
}