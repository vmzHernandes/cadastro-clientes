using System.Globalization;
using Repositorio;

namespace ProjetoCadastroDeClientes;

class Program {

    static ClienteRepositorio _clienteRepositorio = new ClienteRepositorio();
    static void Main(string[] args) {

        var cultura = new CultureInfo("pt-BR");
        Thread.CurrentThread.CurrentCulture = cultura;
        Thread.CurrentThread.CurrentUICulture = cultura;

        // 
        _clienteRepositorio.LerDadosClientes();
        while (true) {
            Menu();

            // "Trava" a aplicação até o usuario pressionar uma tecla
            // Se não tivesse, ficaria imprimindo o menu em loop infinito
            Console.ReadKey();
        }
    }

    static void Menu() {
        // Limpa o console
        Console.Clear();
        
        Console.WriteLine("Cadastro de Clientes");
        Console.WriteLine("--------------------");
        Console.WriteLine("1 - Cadastrar Clientes");
        Console.WriteLine("2 - Exibir Clientes");
        Console.WriteLine("3 - Editar Cliente");
        Console.WriteLine("4 - Excluir Cliente");
        Console.WriteLine("5 - Sair");
        Console.WriteLine("--------------------");

        EscolherOpcao();
    }

    static void EscolherOpcao() {
        var opcao = Console.ReadLine();

        switch (int.Parse(opcao)) {
            case 1: {
                _clienteRepositorio.CadastrarCliente();
                Menu();
                break;
            }
            
            case 2: {
                _clienteRepositorio.ExibirClientes();
                Menu();
                break;
            }

            case 3: {
                _clienteRepositorio.EditarCliente();
                Menu();
                break;
            }

            case 4: {
                _clienteRepositorio.ExcluirCliente();
                Menu();
                break;
            }

            case 5: {
                _clienteRepositorio.GravarDadosClientes();
                Environment.Exit(0);
                break;
            }

            default: {
                Console.Clear();
                Console.WriteLine("Opção inválida");
                break;
            }
        }
    }
}
