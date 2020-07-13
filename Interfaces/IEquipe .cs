using System.Collections.Generic;
using E_Players_MVC.Models;

namespace E_Players_MVC.Interfaces
{
    public interface IEquipe 
    {
         //Create
        void Create (Equipe e);
         //Read
        List<Equipe> ReadAll();
        //Change
        void Change (Equipe e);
         //Delete
         void Delete (int idEquipe);



    }
}