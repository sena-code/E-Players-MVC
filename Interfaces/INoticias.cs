using System.Collections.Generic;
using E_Players_MVC.Models;

namespace E_Players_MVC.Interfaces
{
    public interface INoticias
    {
        //Create
        void Create (Noticias a);
         //Read
        List<Noticias> ReadAll();
        //Change
        void Change (Noticias a);
         //Delete
         void Delete (int idNoticias);
    }
}