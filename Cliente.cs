using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ProjetoCadastroDeClientes {
    public class Cliente {
        // Propriedades da classe cliente
        public int Id { get; set; }
        // O ? após string indica que essa propriedade pode aceitar valores nulos, o que remove a mensagem de Non-nullable property no console
        public string? Nome { get; set; }
        public DateOnly DataNascimento { get; set; }
        public DateTime CadastradoEm { get; set; }
        public decimal Desconto { get; set;}
    }

}