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

            // introdução do jogo
            Console.Clear();
            Console.WriteLine("==================================================================");
            Console.WriteLine("                BEM-VINDO AO MUNDO DE MONOMITO                    ");
            Console.WriteLine("==================================================================");
            Console.WriteLine("Um mundo movido por histórias. Mitos, fábulas e cantigas...");
            Console.WriteLine("Subitamente, histórias de heróis ganham vida. Diante da ameaça de");
            Console.WriteLine("GIYGAS, a maldade encarnada, resta a você seguir de se tonar um heroi!");
            Console.WriteLine("e enfrentar o mal que assola o mundo.");
            Console.WriteLine("==================================================================\n");
            Console.WriteLine("Pressione QUALQUER TECLA para ir para a seleção de sua classe...");
            Console.ReadKey();

            // Seleção de classe do jogador
            Console.Clear();
            Console.WriteLine("==================================================================");
            Console.WriteLine("                      ESCOLHA SUA CLASSE                          ");
            Console.WriteLine("==================================================================");
            Console.WriteLine("1 - Bárbaro (Machado Grande) | 10 PV | 1.5x Dano Pesado, 0.8x os outros");
            Console.WriteLine("2 - Ladino  (Punhal)         |  9 PV | 1.5x Dano Ágil, 0.8x os outros");
            Console.WriteLine("3 - Monge   (Soqueiras)      |  8 PV | 1.5x Dano Contra-Ataque, 0.8x os outros");
            Console.WriteLine("4 - Monomito(Espada Improvisada)| 13 PV | Dano padrão, Força de vontade extrema");
            Console.Write("\nDigite o número da sua classe: ");
            //Descobri para que o \n serve, ele serve para pular uma linha no console, então quando você usa o \n, o texto que vem depois dele vai aparecer na linha de baixo.
            //tutorial, essa linha é só para dividir o código em partes menores e mais fáceis de entender, não é necessário para o funcionamento do jogo.

            double vidaJogador = 3;
            double vidaMaquina = 10;
            double danoBase = 2;
            int classeEscolhida = 0;

            // Validação da classe escolhida pelo jogador
            // traduzindo essa parte do código: se o jogador não digitar um número válido entre 1 e 4, ele será automaticamente colocado na classe Monomito (opção 4).
            // int.TryParse: Tenta converter o texto que o Console.ReadLine() pegou em um número inteiro.
            //out int classeEscolhida: O out serve para criar a variável e passar o resultado para fora. EX: Se o jogador digitar
            //"1", o TryParse consegue converter e o out joga o número 1 dentro da variável classeEscolhida.
            //tive que mudar a variável classeEscolhida, antes ela não tava definida, e mudou a parte do out int
            // mas fica aí de aprendizado, o out é usado para passar o valor de uma variável para fora do método e o !int é tipo um inversor de true e false
            if (!int.TryParse(Console.ReadLine(), out classeEscolhida) || classeEscolhida < 1 || classeEscolhida > 4)
            {
                Console.WriteLine("\nComo o mundo originalmente havia proposto, você será Monomito.");
                classeEscolhida = 4;
                Console.ReadKey();
            }
            // Atribuição de vida inicial com base na classe escolhida
                if (classeEscolhida == 1)
                {
                    Console.WriteLine("\nVocê escolheu a classe Bárbaro, com 10 pontos de vida.");
                    vidaJogador = 10;
                }
                else if (classeEscolhida == 2)
                {
                    Console.WriteLine("\nVocê escolheu a classe Ladino, com 9 pontos de vida.");
                    vidaJogador = 9;
                }
                else if (classeEscolhida == 3)
                {
                    Console.WriteLine("\nVocê escolheu a classe Monge, com 8 pontos de vida.");
                vidaJogador = 8;
                }
                else
                {
                    Console.WriteLine("\nVocê escolheu a classe Monomito, com 13 pontos de vida.");
                    vidaJogador = 13;
                }
            Console.WriteLine("\nPressione qualquer tecla para ir para o tutorial...");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("==================================================================");
            Console.WriteLine("                    TUTORIAL DE COMBATE                           ");
            Console.WriteLine("==================================================================");
            Console.WriteLine("Entenda como funcionam os embates neste mundo (Regras do Jogo):\n");

            Console.WriteLine("1. Ataque pesado VENCE Ataque ágil");
            Console.WriteLine("   -> Por quê? O ataque pesado possui força o suficiente para");
            Console.WriteLine("      parar ataques fracos e rápidos.\n");

            Console.WriteLine("2. Ataque ágil VENCE Postura de contra-ataque");
            Console.WriteLine("   -> Por quê? Algo ágil que não foi parado com força é");
            Console.WriteLine("      praticamente indefensável.\n");

            Console.WriteLine("3. Postura de contra-ataque VENCE Ataque pesado");
            Console.WriteLine("   -> Por quê? A calma do contra-ataque consegue ganhar");
            Console.WriteLine("      de um ataque lento e pesado.");
            Console.WriteLine("==================================================================");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();

            string[] opcoes = { "Ataque pesado", "Postura de contra-ataque", "Ataque ágil" };
            Console.WriteLine("\nDigite seu nome: ");
            string jogador = Console.ReadLine();
            Console.WriteLine("\nDigite sua idade: ");
            int idade;
            while (!int.TryParse(Console.ReadLine(), out idade))
            {
                Console.WriteLine("Idade inválida. Por favor, digite um número.");
            }

            if (idade < 13)
            {
                Console.WriteLine("Você não pode jogar, pois menores de 13 anos não conseguiram arcar com as consequências.");
                return;
            }
            else
            {
                Console.WriteLine("\nBem-vindo ao jogo, " + jogador + "!");
            }
            //inicio do jogo(Decisão do jogador e da máquina)
            {
                //tem que colocar o gerador de numero aleatório fora do while, senão ele vai gerar um número não aleatório a cada rodada por causa da velocidade do while.
                Random jogadaMaquina = new Random();
                while (vidaJogador > 0 && vidaMaquina > 0)
                {
                    //Escolha da máquina
                  
                    int indiceMaquina = jogadaMaquina.Next(0, opcoes.Length);
                    string jogadaDaMaquina = opcoes[indiceMaquina];
                    //Escolha do jogador
                    Console.WriteLine("\nEscolha sua jogada:");
                    Console.WriteLine("0 - Ataque pesado");
                    Console.WriteLine("1 - Postura de contra-ataque");
                    Console.WriteLine("2 - Ataque ágil");
                    int escolhaJogador = int.Parse(Console.ReadLine());
                    if (escolhaJogador < 0 || escolhaJogador > 2)
                    {
                        Console.WriteLine("\nEscolha inválida. Tente novamente.");
                    }
                    else
                    {
                        string jogadaDoJogador = opcoes[escolhaJogador];
                        Console.WriteLine("Você escolheu: " + jogadaDoJogador);
                        Console.WriteLine("A máquina escolheu: " + jogadaDaMaquina);
                        //Comparação das jogadas
                        //Comparação das jogadas
                        if (jogadaDoJogador == jogadaDaMaquina)
                        {
                            Console.WriteLine("Empate!");
                        }
                        // Bloco ÚNICO de vitória do Jogador baseado no seu GDD
                        else if ((jogadaDoJogador == "Ataque pesado" && jogadaDaMaquina == "Ataque ágil") ||
                                 (jogadaDoJogador == "Postura de contra-ataque" && jogadaDaMaquina == "Ataque pesado") ||
                                 (jogadaDoJogador == "Ataque ágil" && jogadaDaMaquina == "Postura de contra-ataque"))
                        {
                        
                            double danoFinal = danoBase;

                            // APLICANDO A PASSIVA DO BÁRBARO (Classe 1)
                            if (classeEscolhida == 1)
                            {
                                if (escolhaJogador == 0) { danoFinal = danoBase * 1.5; }
                                else { danoFinal = danoBase * 0.8; }
                            }
                            // APLICANDO A PASSIVA DO LADINO (Classe 2)
                            else if (classeEscolhida == 2)
                            {
                                if (escolhaJogador == 2) { danoFinal = danoBase * 1.5; }
                                else { danoFinal = danoBase * 0.8; }
                            }
                            // APLICANDO A PASSIVA DO MONGE (Classe 3)
                            else if (classeEscolhida == 3)
                            {
                                if (escolhaJogador == 1) { danoFinal = danoBase * 1.5; }
                                else { danoFinal = danoBase * 0.8; }
                            }
                            // O Monomito (Classe 4) não altera o danoBase (continua 2.0)

                            // Aplicamos o dano calculado na máquina
                            vidaMaquina = vidaMaquina - danoFinal;
                            //lembrei que dava para usar $ para interpolar variáveis dentro de strings, então usei ele para mostrar o dano final e a vida da máquina. (autovomplete ajuda muito nisso)
                            Console.WriteLine($"\nVocê ganhou a rodada! Causou {danoFinal:F1} de dano. O inimigo tem {vidaMaquina:F1} de vida.");
                        }
                        else
                        {
                            // Se não empatou e o jogador não ganhou, a máquina ganhou a rodada
                            double danoInimigo = 2.0;
                            vidaJogador = vidaJogador - danoInimigo;
                            Console.WriteLine($"\nA máquina ganhou a rodada! Você perdeu {danoInimigo} de vida, restam {vidaJogador:F1} de PV.");
                        }
                    }


                }
                //Verificação de vitória e derrota
                if (vidaJogador == 0)
                {
                    Console.WriteLine(" VOCÊ foi derrotado, O mal irá sucumbir o mundo perante a sua derrotado");
                    return;
                }
                else
                {
                    Console.WriteLine(jogador + " venceu, a proxima batlha te aguarda!");
                }

            }
        
        }
    }
}  
            

        
    

