using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

//Verificar se o jogador é maior de 13 anos e pegar nome dele

namespace JogoMonomito
{
    internal class Program
    {
        static void Main(string[] args)
        {


            string[] opcoes = { "Pedra", "Papel", "Tesoura" };
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
            //inicio do jogo(Decisão do jogador e da máquina)
            {
                int vidaJogador = 3;
                int vidaMaquina = 3;
                while (vidaJogador > 0 && vidaMaquina > 0)
                {
                    //Escolha da máquina
                    Random jogadaMaquina = new Random();
                    int indiceMaquina = jogadaMaquina.Next(0, opcoes.Length);
                    string jogadaDaMaquina = opcoes[indiceMaquina];
                    //Escolha do jogador
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
                        //Comparação das jogadas
                        if (jogadaDoJogador == jogadaDaMaquina)
                        {
                            Console.WriteLine("Empate!");
                        }
                        else if ((jogadaDoJogador == "Pedra" && jogadaDaMaquina == "Tesoura") ||
                                 (jogadaDoJogador == "Papel" && jogadaDaMaquina == "Pedra") ||
                                 (jogadaDoJogador == "Tesoura" && jogadaDaMaquina == "Papel"))
                        {
                            //calculo e visor da vida(jogador e máquina)
                            vidaMaquina--;
                        
                            
                                Console.WriteLine("Você ganhou a rodada! " + " ela tem " + vidaMaquina + " de vida.");
                            
                        }
                        else
                        {
                            vidaJogador--;
                            Console.WriteLine("A máquina ganhou a rodada! " + " você tem " + vidaJogador + " de vida.");



                        }
                    }
                  
               
                }
                //Verificação de vitória e derrota
                if (vidaJogador == 0)
                {
                    Console.WriteLine(" Máquina venceu, reinicie o programa e tente novamente");
                }
                else
                {
                    Console.WriteLine(jogador + " venceu, a proxima batlha te aguarda!");
                }
            }
        }
    }
}  
            

        
    

