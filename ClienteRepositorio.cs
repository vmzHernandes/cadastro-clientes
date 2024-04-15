using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoCadastroDeClientes;

    namespace Repositorio {
    public class ClienteRepositorio {
        
        // Propriedades para adicionar, remover, editar e exibir os clientes

        // -------------------------
        
        // Cria e instancia a lista de clientes com o nome 'clientes'
        public List<Cliente> clientes = new List<Cliente>();

        // Alguns métodos de manipulação das informações

        // ***** IMPRESSÃO DOS DADOS DO CLIENTE *****
        public void ImprimirCliente(Cliente cliente) {
            // Da classe Cliente, imprime as propriedade sdefinidas em Cliente.cs
            Console.WriteLine($"ID.............: {cliente.Id}");
            Console.WriteLine($"Nome...........: {cliente.Nome}");
            Console.WriteLine($"Desconto.......: {cliente.Desconto.ToString("0.00")}");
            Console.WriteLine($"Data Nascimento: {cliente.DataNascimento}");
            Console.WriteLine($"Data Cadastro..: {cliente.CadastradoEm}");
            Console.WriteLine("-----------------");
        }

        // ***** EXIBIÇÃO DOS DADOS DO CLIENTE *****
        public void ExibirClientes() {
            Console.Clear();
            // Para cada cliente da lista 'clientes', roda o método ImprimirCliente()
            foreach (var cliente in clientes) {
                ImprimirCliente(cliente);
            }
            Console.ReadKey();
        }

        
        // ***** CADASTRO DE UM NOVO CLIENTE *****
        public void CadastrarCliente() {
            Console.Clear();

            // Pede nome, data de nascimento e desconto para cada cliente novo que for cadastrado
            Console.Write("Nome do Cliente: ");
            var nome = Console.ReadLine();
            Console.Write(Environment.NewLine);

            Console.Write("Data de Nascimento: ");
            var dataNascimento = DateOnly.Parse(Console.ReadLine());
            Console.Write(Environment.NewLine);

            Console.Write("Desconto: ");
            var desconto = decimal.Parse(Console.ReadLine());
            Console.Write(Environment.NewLine);

            // Após isso, cria um novo cliente e atribui as caracteristicas fornecidas pelo console
            var cliente = new Cliente();
            cliente.Id = clientes.Count + 1;
            cliente.Nome = nome;
            cliente.DataNascimento = dataNascimento;
            cliente.Desconto = desconto;
            cliente.CadastradoEm = DateTime.Now;

            // Adiciona o novo cliente para a lista 'clientes', que contém todos os clientes
            clientes.Add(cliente);

            Console.WriteLine("Cliente cadastrado com sucesso");
            ImprimirCliente(cliente);
            Console.ReadKey();
        }

        
        
        // ***** EDIÇÃO DAS PROPRIEDADES DE UM CLIENTE ESPECÍFICO
        public void EditarCliente() {
            Console.Clear();
            
            // Para editar um cliente específico, primeiro pede-se seu Id
            Console.Write("Informe o código do cliente: ");
            var codigo = Console.ReadLine();

            // Com o Id, aplica-se umn filtro que acha o cliente com o ID informado
            var cliente = clientes.FirstOrDefault(p => p.Id == int.Parse(codigo));

            // Se não achar nenhum cliente com o ID fornecido, manda uma mensagem de erro e retorna para informar outro ID 
            if (cliente == null) {
                Console.WriteLine("Cliente não encontrado");
                Console.ReadKey();
                return;
            }

            // Mostra as informações atuais do cliente selecionado pelo ID
            ImprimirCliente(cliente);
            
            // Pede as novas informações do cliente
            Console.Write("Nome do cliente: ");
            var nome = Console.ReadLine();
            Console.Write(Environment.NewLine);

            Console.Write("Data de nascimento: ");
            var dataNascimento = DateOnly.Parse(Console.ReadLine());
            Console.Write(Environment.NewLine);

            Console.Write("Desconto: ");
            var desconto = decimal.Parse(Console.ReadLine());
            Console.Write(Environment.NewLine);

            // Atualiza as informações do cliente com o que foi passado anteriormente
            cliente.Nome = nome;
            cliente.DataNascimento = dataNascimento;
            cliente.Desconto = desconto;
            cliente.CadastradoEm = DateTime.Now;

            // Diz que o cliente foi atualizado e imprime suas informações
            Console.WriteLine("Cliente atualizado");
            ImprimirCliente(cliente);
            Console.ReadKey();
        }

        // ***** EXCLUIR ALGUM CLIENTE ESPECÍFICO *****
        public void ExcluirCliente() {
            Console.Clear();
            
            // Semelhante ao método para editar um cliente
            // Para editar um cliente específico, primeiro pede-se seu Id
            Console.Write("Informe o código do cliente: ");
            var codigo = Console.ReadLine();

            // Com o Id, aplica-se umn filtro que acha o cliente com o ID informado
            var cliente = clientes.FirstOrDefault(p => p.Id == int.Parse(codigo));

            // Se não achar nenhum cliente com o ID fornecido, manda uma mensagem de erro e retorna para informar outro ID 
            if (cliente == null) {
                Console.WriteLine("Cliente não encontrado");
                Console.ReadKey();
                return;
            }

            // Mostra as informações atuais do cliente selecionado pelo ID
            ImprimirCliente(cliente);

            // Remove o cliente desejado da lista 'clientes'
            clientes.Remove(cliente);
            Console.WriteLine("Cliente removido");
            Console.ReadKey();
        }

        // ***** GRAVAÇÃO DOS DADOS EM UM JSON *****
        public void GravarDadosClientes() {
            // Serialização: Transforma os objetos da memória em uma string no formato JSON 
            var json = System.Text.Json.JsonSerializer.Serialize(clientes);

            // Grava a string 'json' no arquivos clientes.txt
            File.WriteAllText("clientes.txt", json);
        }

        public void LerDadosClientes() {
            // Desserialização: Transforma a string em objeto
            if (File.Exists("clientes.txt")) {
                var dados = File.ReadAllText("clientes.txt");
                var clientesArquivo = System.Text.Json.JsonSerializer.Deserialize<List<Cliente>>(dados);

                // Adicionando a coleção de clientes na lista Cliente criada na l162
                clientes.AddRange(clientesArquivo);
            }
        }


        // ***** RECUPERAÇÃO DOS DADOS  *****
    }
}