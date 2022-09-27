using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Notifies
    {
        public Notifies()
        {
            Notificacoes = new List<Notifies>();
        }

        [NotMapped]
        public string? NomePropriedade { get; set; }
        
        [NotMapped]
        public string? Mensagem { get; set; }

        [NotMapped]
        public List<Notifies> Notificacoes { get; set; }

        public bool ValidadrPropriedadeString(string valor, string nomePropriedade)
        {
            if(string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifies
                {
                    Mensagem = "Campo obrigatório",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }

            return true;
        }

        public bool ValidadrPropriedadeInt(int valor, string nomePropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifies
                {
                    Mensagem = "Campo obrigatório",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }

            return true;
        }
    }
}
