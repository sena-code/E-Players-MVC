using System;
using System.Collections.Generic;
using System.IO;
using E_Players_MVC.Interfaces;

namespace E_Players_MVC.Models
{
    public class Noticias : EplayersBase , INoticias
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/noticias.csv";

         /// <summary>
        /// Metodo construtor para poder criar um arquivo, caso não exista
        /// </summary>
        public Noticias ()
        {
            CreateFolderAndFile(PATH);
        }
        /// <summary>
        /// Tirar um item e substituir por um outro
        /// </summary>
        /// <param name="a">O novo item</param>
        public void Change(Noticias a)
        {
            List<string> lines = ReadAllLinesCSV(PATH);
            lines.RemoveAll(x => x.Split(";")[0] == a.IdNoticia.ToString());
            lines.Add( PreparedLines (a));
            RewriteCSV(PATH, lines);
        }
        /// <summary>
        /// Criar e cadastrar um item nas linhas do csv
        /// </summary>
        public void Create(Noticias a)
        {
            string[] lines = {PreparedLines(a)};
            File.AppendAllLines(PATH, lines);
        }
         /// <summary>
        /// Deletar um dos itens cadastrados no csv 
        /// </summary>
        public void Delete(int idNoticias)
        {
            List<string> lines = ReadAllLinesCSV(PATH);
            lines.RemoveAll(x => x.Split(";")[0] == idNoticias.ToString());
            RewriteCSV(PATH, lines);
        }
         /// <summary>
        /// Lê todas as linhas do csv
        /// </summary>
        /// <returns>Uma lista</returns>

        public List<Noticias> ReadAll()
        {
             List<Noticias> news = new List<Noticias>();
            string[] lines = File.ReadAllLines(PATH);
            foreach (var item in lines)
            {
                string[] line = item.Split(";");
                Noticias noticia = new Noticias();
                noticia.IdNoticia = Int32.Parse(line[0]);
                noticia.Titulo = line[1];
                noticia.Texto = line[2];
                noticia.Imagem = line[3];

                news.Add(noticia);
            }
            return news;
        }
        
        /// <summary>
        /// Preparar as linhas no csv 
        /// </summary>
        /// <param name="a">Todos as caracteristicas que irá aparecer no csv</param>
        /// <returns></returns>
        private string PreparedLines(Noticias a)
        {
            return $"{a.IdNoticia};{a.Titulo};{a.Texto};{a.Imagem}";
        }
    }
}