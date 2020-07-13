using System;
using System.Collections.Generic;
using System.IO;
using E_Players_MVC.Interfaces;

namespace E_Players_MVC.Models
{
    public class Equipe :  EplayersBase , IEquipe
    {
        public int IdEquipe {get; set;}

        public string Nome {get; set;}

        public string Imagem {get; set;}

        private const string PATH = "Database/equipe.csv";

        public Equipe (){
            CreateFolderAndFile(PATH);
        }
        public void Change(Equipe e)
        {
            List<string> lines = ReadAllLinesCSV(PATH);
            lines.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
            lines.Add( PreparedLine (e));
            RewriteCSV(PATH, lines);
        }

        public void Create(Equipe e)
        {
            string[] line = { PreparedLine(e)};
            File.AppendAllLines(PATH, line);
        }

        private string PreparedLine(Equipe e)
        {
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

        public void Delete(int idEquipe)
        {
            List<string> lines = ReadAllLinesCSV(PATH);
            lines.RemoveAll(x => x.Split(";")[0] == idEquipe.ToString());
            RewriteCSV(PATH, lines);
        }

        public List<Equipe> ReadAll()
        {
             List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }

    }
}