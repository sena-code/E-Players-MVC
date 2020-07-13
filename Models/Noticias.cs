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

        public Noticias ()
        {
            CreateFolderAndFile(PATH);
        }
 
        public void Change(Noticias a)
        {
            List<string> lines = ReadAllLinesCSV(PATH);
            lines.RemoveAll(x => x.Split(";")[0] == a.IdNoticia.ToString());
            lines.Add( PreparedLines (a));
            RewriteCSV(PATH, lines);
        }

        public void Create(Noticias a)
        {
            string[] lines = {PreparedLines(a)};
            File.AppendAllLines(PATH, lines);
        }

        public void Delete(int idNoticias)
        {
            List<string> lines = ReadAllLinesCSV(PATH);
            lines.RemoveAll(x => x.Split(";")[0] == idNoticias.ToString());
            RewriteCSV(PATH, lines);
        }

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
        
        private string PreparedLines(Noticias a)
        {
            return $"{a.IdNoticia};{a.Titulo};{a.Texto};{a.Imagem}";
        }
    }
}