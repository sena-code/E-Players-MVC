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

        /// <summary>
        /// Metodo construtor para poder criar um arquivo, caso não exista
        /// </summary>
        public Equipe (){
            CreateFolderAndFile(PATH);
        }
        /// <summary>
        /// Tirar um item e substituir por um outro
        /// </summary>
        /// <param name="e">é o novo item</param>
        public void Change(Equipe e)
        {
            List<string> lines = ReadAllLinesCSV(PATH);
            lines.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
            lines.Add( PreparedLine (e));
            RewriteCSV(PATH, lines);
        }
        /// <summary>
        /// Criar e cadastrar um item nas linhas do csv
        /// </summary>
        /// <param name="e"></param>
        public void Create(Equipe e)
        {
            string[] line = { PreparedLine(e)};
            File.AppendAllLines(PATH, line);
        }
        /// <summary>
        /// Preparar as linhas no csv 
        /// </summary>
        /// <param name="e">Todos as caracteristicas que irá aparecer no csv</param>
        /// <returns></returns>
        private string PreparedLine(Equipe e)
        {
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }
        /// <summary>
        /// Deletar um dos itens cadastrados no csv 
        /// </summary>
        /// <param name="idEquipe">Variavel</param>
        public void Delete(int idEquipe)
        {
            List<string> lines = ReadAllLinesCSV(PATH);
            lines.RemoveAll(x => x.Split(";")[0] == idEquipe.ToString());
            RewriteCSV(PATH, lines);
        }
        /// <summary>
        /// Lê todas as linhas do csv
        /// </summary>
        /// <returns>Uma lista</returns>
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