using System;
using System.Collections.Generic;
using Gamificação_01___Final.UI;
using JRJ.Modas;
using ProjetoFinal.db;

namespace JRJ.Modas
{
    public class CategoriaUI : IUserInterface { 

        public void Menu()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Listar categorias");
                Console.WriteLine("2 - Cadastrar categoria");
                Console.WriteLine("3 - Alterar categoria");
                Console.WriteLine("4 - Excluir categoria");
                Console.WriteLine("0 - Voltar");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Listar();
                        break;
                    case "2":
                        Cadastrar();
                        break;
                    case "3":
                        Alterar();
                        break;
                    case "4":
                        Excluir();      
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (continuar);
        }

        public void Listar()
        {
            Console.Clear();

            try
            {
                if (CategoriaModel.categorias.Count == 0)
                {
                    throw new Exception("Não há nenhuma categoria cadastrada!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Lista de categorias:");
            foreach (var categoria in CategoriaModel.categorias)
            {
                Console.WriteLine($"ID: {categoria.CategoriaID} | Guid: {categoria.CategoriaIDGUID} | Nome: {categoria.Nome}");
            }
        }

        public void Cadastrar()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de categoria:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            CategoriaModel categoria1;

            using (var db = new Context())
            {
                categoria1 = new CategoriaModel
                {
                    CategoriaIDGUID = Guid.NewGuid(),
                    Nome = nome
                };
                db.Categorias.Add(categoria1);
                db.SaveChanges();
            }

            CategoriaModel.categorias.Add(categoria1);

            Console.WriteLine();
            Console.WriteLine("Categoria cadastrada com sucesso!");
        }
        public void Alterar()
        {
            Console.Clear();

            try
            {
                if (CategoriaModel.categorias.Count == 0)
                {
                    throw new Exception("Não há nenhuma categoria cadastrada!");
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            

            Console.WriteLine("Alteração de categoria:");
            Console.Write("Digite o ID da categoria que deseja alterar: ");
            long id = long.Parse(Console.ReadLine());
            CategoriaModel categoria = CategoriaModel.categorias.Find(c => c.CategoriaID == id);

           while (categoria == null)
            {
                Console.Write("\nCategoria não encontrada!\nDigite novamente o código da categoria: ");
                id = long.Parse(Console.ReadLine());
                categoria = CategoriaModel.categorias.Find(c => c.CategoriaID == id);
            }

            Console.Write($"Novo nome para a categoria {categoria.Nome}: ");
            string nome = Console.ReadLine();
            categoria.Nome = nome;

            Console.WriteLine();
            Console.WriteLine("Categoria alterada com sucesso!");
        }

        public void Excluir()
        {
            Console.Clear();

            try
            {
                if (CategoriaModel.categorias.Count == 0)
                {
                    throw new ArgumentException("Não há nenhuma categoria cadastrada!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Exclusão de categoria:");

            long id;
            while (true)
            {
                Console.Write("ID da categoria: ");
                try
                {
                    id = long.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("ID inválido. Digite um valor numérico válido.");
                }
            }

            CategoriaModel categoria = CategoriaModel.categorias.Find(c => c.CategoriaID == id);

            while (categoria == null)
            {
                Console.Write("\nCategoria não encontrada!\nDigite novamente o código da categoria: ");
                id = long.Parse(Console.ReadLine());
                categoria = CategoriaModel.categorias.Find(c => c.CategoriaID == id);
            }

            try
            {
                if (ProdutoModel.produtos.Exists(p => p.Categoria.CategoriaID == id))
                {
                    throw new Exception("Não é possível excluir a categoria, pois existem produtos vinculados a ela!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            

            CategoriaModel.categorias.Remove(categoria);

            Console.WriteLine();
            Console.WriteLine("Categoria excluída com sucesso!");
        }
    }
}




