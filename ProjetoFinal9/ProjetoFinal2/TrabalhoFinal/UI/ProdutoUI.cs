using Gamificação_01___Final.UI;
using JRJ.Modas;
using System;
using System.Collections.Generic;


namespace JRJ.Modas
{
    public class ProdutoUI : IUserInterface
    {

        public void Menu()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Listar produtos");
                Console.WriteLine("2 - Cadastrar produto");
                Console.WriteLine("3 - Alterar produto");
                Console.WriteLine("4 - Excluir produto");
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
                if (ProdutoModel.produtos.Count == 0)
                {
                    throw new Exception("Não há nenhum produto cadastrado!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Lista de produtos:");
            foreach (var produto in ProdutoModel.produtos)
            {
                Console.WriteLine(
                    $"ID: {produto.ProdutoID} " +
                    $"| Nome: {produto.Nome} " +
                    $"| Preço: {produto.Preco} " +
                    $"| Categoria: {produto.Categoria.Nome} " +
                    $"| Estoque: {produto.Estoque}"  
                );
            }
        }

        public void Cadastrar()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de produto:");
           
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            double preco;
            while (true)
            {
                Console.Write("Preço: ");
                try
                {
                    preco = double.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Preço inválido. Digite um valor numérico válido.");
                }
            }

            Console.Write("Quantidade em estoque: ");
            long estoque = long.Parse(Console.ReadLine());

            int idCategoria;
            while (true)
            {
                Console.Write("ID da categoria: ");
                try
                {
                    idCategoria = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("ID inválido. Digite um valor numérico válido.");
                }
            }

            CategoriaModel categoria = CategoriaModel.categorias.Find(c => c.CategoriaID == idCategoria);

            while(categoria == null)
            {
                Console.Write("\nCategoria não encontrada!\nDigite o ID novamente (0 voltar):");
                idCategoria = int.Parse(Console.ReadLine());

                if(idCategoria == 0)
                {
                    return;
                }

                categoria = CategoriaModel.categorias.Find(c => c.CategoriaID == idCategoria);
            }

            ProdutoModel produto = new ProdutoModel(nome, preco, estoque, categoria);

            ProdutoModel.produtos.Add(produto);
            Console.WriteLine("Produto cadastrado com sucesso!");
        }

        public void Alterar()
        {
            Console.Clear();

            try
            {
                if (ProdutoModel.produtos.Count == 0)
                {
                    throw new Exception("Não há nenhum produto cadastrado!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Alteração de produto:");

            Console.Write("ID do produto: ");
            long idProduto = long.Parse(Console.ReadLine());

            ProdutoModel produto = ProdutoModel.produtos.Find(p => p.ProdutoID == idProduto);

            while(produto == null)
            {
                Console.Write("\nProduto não encontrado!\nInforme o ID novamente:");
                idProduto = int.Parse(Console.ReadLine());
                produto = ProdutoModel.produtos.Find(p => p.ProdutoID == idProduto);
            }
            
            Console.Write($"Nome ({produto.Nome}): ");
            string nome = Console.ReadLine();
            produto.Nome = nome;

            Console.Write($"Preço ({produto.Preco}): ");
            double preco = double.Parse(Console.ReadLine());
            produto.Preco = preco;

            Console.Write($"ID da categoria ({produto.Categoria.CategoriaID}): ");
            long idCategoria = long.Parse(Console.ReadLine());
            produto.Categoria = CategoriaModel.categorias.Find(c => c.CategoriaID == idCategoria);

            while(produto.Categoria == null)
            {
                Console.Write("\nCategoria não encontrada!\nInforme o ID novamente:");
                idCategoria = int.Parse(Console.ReadLine());
                produto.Categoria = CategoriaModel.categorias.Find(c => c.CategoriaID == idCategoria);
            }

            Console.WriteLine("Produto alterado com sucesso!");
        }

        public void Excluir()
        {
            Console.Clear();

            try
            {
                if (ProdutoModel.produtos.Count == 0)
                {
                    throw new Exception("Não há nenhum produto cadastrado!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Exclusão de produto:");

            Console.Write("ID do produto: ");
            long idProduto = long.Parse(Console.ReadLine());

            ProdutoModel produto = ProdutoModel.produtos.Find(p => p.ProdutoID == idProduto);

            if (produto != null)
            {
                ProdutoModel.produtos.Remove(produto);
                Console.WriteLine("Produto excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado!");
            }
        }
    }
}
