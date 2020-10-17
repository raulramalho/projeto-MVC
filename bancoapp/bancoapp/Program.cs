using AppBancoDLL;
using AppBancoDominio;
using AppBancoADO;
using bancoapp;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bancoapp
{
    class Program
    {
        public static void Main(string[] args)
        {
            MySqlConnection conexao = new MySqlConnection("server = localhost; user id = root; database = dbexemplo");
            conexao.Open();
            //instanciando classe banco
            Banco banco = new Banco();



            //declarando variaveis
            var usuario = new usuario();
            var UsuarioDAO = new UsuarioDAO();
            int escolha,id,repetir;
            do {
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("- 0 - Cadastrar Usuario      -");
                Console.WriteLine("- 1 - Editar Usuario         -");
                Console.WriteLine("- 2 - Excluir Usuario        -");
                Console.WriteLine("- 3 - Listar Usuario         -");
                Console.WriteLine("- 4 - Sair                   -");
                Console.WriteLine("------------------------------");

                escolha = int.Parse(Console.ReadLine());
                switch (escolha)
                {
                    case 0:
                        Console.Write("digite o nome usuário:");
                        usuario.NomeUsu = Console.ReadLine();
                        Console.Write("\ndigite o cargo usuário:");
                        usuario.Cargo = Console.ReadLine();
                        Console.Write("\ndigite a data de nascimento do usuário:");
                        usuario.DataNasc = DateTime.Parse(Console.ReadLine());
                        new UsuarioDAO().salvar(usuario);
                        break;
                    case 1:
                        Console.WriteLine("Digite o Id do usuario que deseja editar");
                        id = int.Parse(Console.ReadLine());
                        Console.Write("digite o nome usuário:");
                        UsuarioDAO.atualizar(id);
                        usuario.NomeUsu = Console.ReadLine();
                        Console.Write("\ndigite o cargo usuário:");
                        usuario.Cargo = Console.ReadLine();
                        Console.Write("\ndigite a data de nascimento do usuário:");
                        usuario.DataNasc = DateTime.Parse(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("Digite o Id do usuario que deseja excluir");
                        id = int.Parse(Console.ReadLine());
                        UsuarioDAO.excluir(id);
                        break;


                    case 3:
                        var leitor = UsuarioDAO.listar();

                        foreach (var usuarios in leitor)
                        {
                            Console.WriteLine("Id:{0}, Nome:{1}, Cargo:{2}, Data:{3}",
                               usuarios.IdUsu, usuarios.NomeUsu, usuarios.Cargo, usuario.DataNasc);
                        }

                        break;
                    case 4:

                        break;
                }
                Console.WriteLine("Deseja voltar para o menu? se sim digite 1 se não aperte outra tecla");
               repetir= int.Parse(Console.ReadLine());
            } while (repetir == 1);
            Console.ReadKey();
        }
    }
}