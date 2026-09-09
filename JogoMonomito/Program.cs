using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoMonomito
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Criar um sistema que faça um pedra-papel-tesoura, máquina vs jogador
            //Pessoas com menos de 13 anos não podem jogar(PEDIDO DA PROFESSORA)
            //Pedir nome do jogador(PEDIDO DA PROFESSORA)
            //Baseado no GDD do Monomito. penso em usar códigos para definir um valor de comparação
            //Entre jogadas de máquina e jogador.Ex:

            //Jogada = ReadLine() (!jogador!)
            //Máquina pick = new Random().Next(0, 2); 
            //Pedra = 1, Papel = 1, Tesoura = 1
            //if tesoura vs papel, tesoura = 2 && if tesoura > papel, então  tesoura ganha
            //Fazer isso para pedra,papel e tesoura
            //A partir disso mudar variaveis como vida e dano
            //EX: jogador = 100 de vida, máquina = 100 de vida
            //Pedra ganha de tesoura(jogador), então máquina - 30 de vida

            //Escrever introdução do jogo, explicando as regras e como jogar, talvez um pouco
            //De história do jogo, e depois começar a batalha.
            //Coisas como descrever um pouco do mundo e protagonista, alem disso descrições de 
            //Evolução do personagem, e talvez uma história de fundo para o antagonista e inimigos comuns.

            string[] opcoes = {"Pedra", "Papel", "Tesoura"};
            Console.WriteLine("Digite seu nome: ");
            string jogador = Console.ReadLine();
            Console.WriteLine("Digite sua idade: ");
            int idade = Convert.ToInt32(Console.ReadLine());

            if (idade < 13)
            {
                Console.WriteLine("Você não pode jogar, pois é menor de 13 anos.");
            }
            else
            {
                Console.WriteLine("Bem-vindo ao jogo, " + jogador + "!");
                
            }
            {
                Random jogadaMaquina = new Random();
                int indiceMaquina = jogadaMaquina.Next(0, opcoes.Length);
                string jogadaDaMaquina = opcoes[indiceMaquina];
                Console.WriteLine("Escolha sua jogada:");
                Console.WriteLine("0 - Pedra");
                Console.WriteLine("1 - Papel");
                Console.WriteLine("2 - Tesoura");
                int escolhaJogador = int.Parse(Console.ReadLine());
                if (escolhaJogador < 0 || escolhaJogador > 2)
                {
                    Console.WriteLine("Escolha inválida. Tente novamente.");
                }
                else
                {
                    string jogadaDoJogador = opcoes[escolhaJogador];
                    Console.WriteLine("Você escolheu: " + jogadaDoJogador);
                    Console.WriteLine("A máquina escolheu: " + jogadaDaMaquina);
                    if (jogadaDoJogador == jogadaDaMaquina)
                    {
                        Console.WriteLine("Empate!");
                    }
                    else if ((jogadaDoJogador == "Pedra" && jogadaDaMaquina == "Tesoura") ||
                             (jogadaDoJogador == "Papel" && jogadaDaMaquina == "Pedra") ||
                             (jogadaDoJogador == "Tesoura" && jogadaDaMaquina == "Papel"))
                    {
                        Console.WriteLine("Você ganhou!");
                    }
                    else
                    {
                        Console.WriteLine("A máquina ganhou!");
                    }
                }
            }
            {
  
            }

        }
    }
}
