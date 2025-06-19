using System;
using System.Collections.Generic;

class Program
{
    // Váriaveis Globais
    static decimal patrimonio = 0, rendaFx = 0, rendaVar = 0, stocks=0, cripto = 0;
    static string fxCategory = "", varCategory = "";

    static int output = 0;

    // Dicionário para facilitar a entrada nos Menus
    static Dictionary<string, Func<decimal>> metodoCategoria = new Dictionary<string, Func<decimal>>
    {
        {"RendaFixa", RendaFixa},
        {"RendaVariavel", RendaVariavel},
        {"AcoesInternacionais", Stocks},
        {"Criptomoedas", Cripto},
        {"VerPatrimonio", VerPatrimonio}
    };

    // Função para adicionar Renda Fixa
    static decimal RendaFixa()
    {
        Console.Write("\nDigite a categoria do investimento: ");
        fxCategory = Console.ReadLine();

        Console.Write("\nDigite seu patrimônio em Renda Fixa: ");
        while (!decimal.TryParse(Console.ReadLine(), out rendaFx))
        {
            Console.Write("Valor Inválido. Digite um número válido: ");
        }
        patrimonio += rendaFx;
        Console.WriteLine($"-- Adicionado R$ {rendaFx} em {fxCategory} --");
        return rendaFx;
    }

    // Função para adicionar Renda Variável
    static decimal RendaVariavel()
    {
        Console.Write("\nDigite a categoria do investimento: ");
        varCategory = Console.ReadLine();

        Console.Write("\nDigite seu patrimônio em Renda Variável: ");
        while (!decimal.TryParse(Console.ReadLine(), out rendaVar))
        {
            Console.Write("Valor Inválido. Digite um número válido: ");
        }
        patrimonio += rendaVar;
        Console.WriteLine($"-- Adicionado R$ {rendaVar} em {varCategory} --");
        return rendaVar;
    }
    static decimal Stocks()
    {
        Console.Write("\nDigite seu patrimônio em Ações Internacionais: ");
        while (!decimal.TryParse(Console.ReadLine(), out stocks))
        {
            Console.Write("Valor Inválido. Digite um número válido: ");
        }
        stocks *= 5; // Multiplicando por 5 para simular a conversão de ações internacionais
        patrimonio += stocks;
        Console.WriteLine($"-- Adicionado R$ {stocks} em Ações Internacionais --");
        return stocks;
    }
    static decimal Cripto()
    {
        Console.Write("\nDigite seu patrimônio em Cripto: ");
        while (!decimal.TryParse(Console.ReadLine(), out cripto))
        {
            Console.Write("Valor Inválido. Digite um número válido: ");
        }
        cripto *= 10; // Multiplicando por 10 para simular a conversão de criptomoedas
        patrimonio += cripto;
        Console.WriteLine($"-- Adicionado R$ {cripto} em Criptomoedas --");
        return cripto;
    }

    static decimal VerPatrimonio()
    {
        Console.WriteLine($"-- Patrimônio --");
        Console.WriteLine($"\nRenda Fixa: R$ {rendaFx} em {fxCategory}");
        Console.WriteLine($"\nRenda Variável: R$ {rendaVar} em {varCategory}");
        Console.WriteLine($"\nAções Internacionais: R$ {stocks}");
        Console.WriteLine($"\nCriptomoedas: R$ {cripto}");
        Console.WriteLine($"\nTotal: R$ {patrimonio}");
        return patrimonio;
    }

    // Menu das Categorias
    static void Menu(string categoria)
    {
        while (true)
        {
            Console.Write($"\n--- {categoria} ---");
            Console.Write("\n1 - Continuar");
            Console.Write("\n2 - Voltar");
            Console.Write("\nOpção: ");

            string inputMenu = Console.ReadLine();

            if (!int.TryParse(inputMenu, out int menuOption))
            {
                Console.WriteLine("Opção Inválida");
                continue;
            }
            if (menuOption == 1)
            {
                metodoCategoria[categoria]();
            }
            else if (menuOption == 2)
            {
                break;
            }
            else
            {
                Console.Write("Opção Inválida");
            }
        }
    } 
    
    // Menu Principal
    static void Main()
    {
        while (true)
        {

            Console.WriteLine("\n-- Calculadora de Patrimonio --");
            Console.WriteLine("1 - Cálculo Renda Fixa");
            Console.WriteLine("2 - Cálculo Renda Variavel");
            Console.WriteLine("3 - Cálculo Ações Internacionais");
            Console.WriteLine("4 - Cálculo Criptomoedas");
            Console.WriteLine("5 - Ver Patrimônio Total");
            Console.WriteLine("6 - Sair");
            Console.WriteLine("Selecione uma das opções acima: ");

            string input = Console.ReadLine();
            output = Convert.ToInt32(input);

            if (output < 1 || output > 6)
            {
                Console.WriteLine("Opção inválida! Digite um número de 1 a 6.");
            }

            switch (output)
            {
                case 1:
                    Menu("RendaFixa");
                    break;
                case 2:
                    Menu("RendaVariavel");
                    break;
                case 3:
                    Menu("AcoesInternacionais");
                    break;
                case 4:
                    Menu("Criptomoedas");
                    break;
                case 5:
                    Menu("VerPatrimonio");
                    break;
                case 6:
                    Console.WriteLine("\nObrigado por usar a Calculadora de Patrimônio!");
                    Console.WriteLine("\nEncerrando Programa...");
                    return;
                default:
                    Console.WriteLine("Opção Inválida! Digite um número de 1 a 6");
                    break;
            }
        }
    }
} 
