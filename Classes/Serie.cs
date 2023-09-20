using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeriesTv.Enum;

namespace SeriesTv.Classes
{
    public class Serie : EntidadeBase
    {

        private Genero Genero {get; set;}
        private string Titulo {get; set;} = string.Empty;
        private string Descricao {get; set;} = string.Empty;
        private int Ano {get; set;}
        private bool Excluido {get; set;} = false;

        public Serie(int id, Genero genero, string titulo, string descricao, int ano) : base(id)
        {
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
        }

        public override string ToString()
        {
            StringBuilder stb = new StringBuilder();
            stb.AppendLine($"Gênero: {Genero}");
            stb.AppendLine($"Titulo: {Titulo}");
            stb.AppendLine($"Descrição: {Descricao}");
            stb.AppendLine($"Ano de inicio: {Ano}");
            stb.AppendLine($"Excluido: {Excluido}");
            return stb.ToString();
        }

        public string GetTitulo()
        {
            return this.Titulo;
        }
        public int GetId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            Excluido = true;
        }
    }
}