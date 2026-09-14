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
            // 1. INTRODUÇÃO DO JOGO
            Console.Clear();
            Console.WriteLine("==================================================================");
            Console.WriteLine("                BEM-VINDO AO MUNDO DE MONOMITO                    ");
            Console.WriteLine("==================================================================");
            Console.WriteLine("Um mundo movido por histórias. Mitos, fábulas e cantigas...");
            Console.WriteLine("Subitamente, histórias de heróis ganham vida. Diante da ameaça de");
            Console.WriteLine("GIYGAS, a maldade encarnada, resta a você seguir o caminho de se tornar um herói");
            Console.WriteLine("e enfrentar o mal que assola o mundo.");
            Console.WriteLine("==================================================================\n");
            Console.WriteLine("Pressione QUALQUER TECLA para ir para o Controle de Acesso...");
            Console.ReadKey();

            // 2. VERIFICAÇÃO DE IDADE E NOME (REQUISITOS DA PROFESSORA)
            Console.Clear();
            Console.WriteLine("==================================================================");
            Console.WriteLine("                    CONTROLE DE ACESSO DO JOGO                    ");
            Console.WriteLine("==================================================================");
            Console.Write("\nDigite seu nome: ");
            string jogador = Console.ReadLine();

            Console.Write("\nDigite sua idade: ");
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
                Console.WriteLine("Pressione qualquer tecla para ir para a seleção de classes...");
                Console.ReadKey();
            }

            // 3. SELEÇÃO DE CLASSE DO JOGADOR
            Console.Clear();
            Console.WriteLine("==================================================================");
            Console.WriteLine("                      ESCOLHA SUA CLASSE                          ");
            Console.WriteLine("==================================================================");
            Console.WriteLine("1 - Bárbaro (Machado Grande) | 10 PV | 1.5x Dano Pesado, 0.8x os outros");
            Console.WriteLine("2 - Ladino  (Punhal)         |  9 PV | 1.5x Dano Ágil, 0.8x os outros");
            Console.WriteLine("3 - Monge   (Soqueiras)      |  8 PV | 1.5x Dano Contra-Ataque, 0.8x os outros");
            Console.WriteLine("4 - Monomito(Espada Improvisada)| 13 PV | Dano padrão, Força de vontade extrema");
            Console.Write("\nDigite o número da sua classe: ");

            double vidaJogador = 3;
            int classeEscolhida = 0;

            if (!int.TryParse(Console.ReadLine(), out classeEscolhida) || classeEscolhida < 1 || classeEscolhida > 4)
            {
                Console.WriteLine("\nComo o Mundo originalmente havia proposto, você será Monomito.");
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

            // Configuração das variáveis de controle de progresso
            double vidaMaximaJogador = vidaJogador;
            double danoBase = 2;
            int vitoriasTotais = 0;
            int nivel = 1; Console.WriteLine("\nPressione qualquer tecla para ir para o tutorial...");
            Console.ReadKey();

            // 4. TUTORIAL DE COMBATE
            Console.Clear();
            Console.WriteLine("==================================================================");
            Console.WriteLine("                    TUTORIAL DE COMBATE                           ");
            Console.WriteLine("==================================================================");
            Console.WriteLine("Entenda como funcionam os embates neste mundo (Regras do Jogo):\n");
            Console.WriteLine("1. Ataque pesado VENCE Ataque ágil");
            Console.WriteLine("   -> Por quê? O ataque pesado possui força o suficiente para\n      parar ataques fracos e rápidos.\n");
            Console.WriteLine("2. Ataque ágil VENCE Postura de contra-ataque");
            Console.WriteLine("   -> Por quê? Algo ágil que não foi parado com força é\n      praticamente indefensável.\n");
            Console.WriteLine("3. Postura de contra-ataque VENCE Ataque pesado");
            Console.WriteLine("   -> Por quê? A calma do contra-ataque consegue ganhar\n      de um ataque lento e pesado.");
            Console.WriteLine("==================================================================");
            Console.WriteLine("Pressione qualquer tecla para iniciar a jornada...");
            Console.ReadKey();

            string[] opcoes = { "Ataque pesado", "Postura de contra-ataque", "Ataque ágil" };
            Random jogadaMaquina = new Random();

            // ==================================================================
            // 5. LOOP DA JORNADA (Faz o jogo continuar em sequência mantendo o nível)
            // ==================================================================
            while (vidaJogador > 0)
            {
                // Inimigos normais têm 10 PV. No nível 4, surge o Chefe GIYGAS com 16 PV!
                double vidaMaquina = (nivel >= 4) ? 16 : 10;
                int contadorRodadas = 0;
                bool levouDanoNestaRodada = false;

                Console.Clear();
                Console.WriteLine("==================================================================");
                if (nivel >= 4)
                {
                    Console.WriteLine($" CONFRONTO FINAL: {jogador.ToUpper()} VS GIYGAS (A MALDADE ENCARNADA) ");
                }
                else
                {
                    Console.WriteLine($"      BATALHA DETECTADA - {jogador.ToUpper()} (NÍVEL {nivel})      ");
                }
                Console.WriteLine($"      Histórico de vitórias: {vitoriasTotais} | PV Máximo: {vidaMaximaJogador}");
                Console.WriteLine("==================================================================");

                if (nivel >= 4)
                    Console.WriteLine("A terra treme. Giygas surge para apagar a sua história! É tudo ou nada!");
                else
                    Console.WriteLine("Um servo enviado por GIYGAS surge das sombras! Prepare-se!");

                Console.WriteLine("Pressione qualquer tecla para puxar suas armas...");
                Console.ReadKey();

                // LOOP DO COMBATE ATUAL
                while (vidaJogador > 0 && vidaMaquina > 0)
                {
                    contadorRodadas++;
                    Console.Clear();
                    Console.WriteLine("------------------------------------------------------------------");
                    string nomeInimigo = (nivel >= 4) ? "GIYGAS" : "Inimigo";
                    Console.WriteLine($"STATUS: {jogador} [{vidaJogador:F1}/{vidaMaximaJogador} PV] VS {nomeInimigo} [{vidaMaquina:F1} PV]");
                    Console.WriteLine($"RODADA: {contadorRodadas}");
                    Console.WriteLine("------------------------------------------------------------------");

                    // Escolha oculta da máquina
                    int indiceMaquina = jogadaMaquina.Next(0, opcoes.Length);
                    string jogadaDaMaquina = opcoes[indiceMaquina];

                    // RECOMPENSA NÍVEL 3 - PREPARAÇÃO: Revela pistas a cada 2 rodadas
                    if (nivel >= 3 && contadorRodadas % 2 == 0)
                    {
                        Console.WriteLine(" [PREPARAÇÃO ATIVA] Sua mente tática prevê o movimento do oponente!");
                        int indicePista = (indiceMaquina + 1) % 3;
                        Console.WriteLine($"-> Pista: O inimigo certamente NÃO usará: {opcoes[indicePista]}");
                        Console.WriteLine("------------------------------------------------------------------");
                    }

                    // RECOMPENSA NÍVEL 4 - ENCONTRO DE INTENÇÕES: Menu especial de Empate Forçado
                    bool empatouForçado = false;
                    if (nivel >= 4 && levouDanoNestaRodada)
                    {
                        Console.WriteLine("[ENCONTRO DE INTENÇÕES] Você sofreu dano recentemente e pode manipular o destino!");
                        Console.WriteLine("Deseja forçar um empate nesta rodada para se proteger?");
                        Console.WriteLine("S - Sim, invocar o Encontro de Intenções");
                        Console.WriteLine("N - Não, quero lutar normalmente");
                        Console.Write("Escolha: ");
                        string escolhaIntencao = Console.ReadLine().ToUpper();

                        if (escolhaIntencao == "S")
                        {
                            empatouForçado = true;
                            levouDanoNestaRodada = false;
                        }
                    }

                    int escolhaJogador = 0;
                    if (!empatouForçado)
                    {
                        Console.WriteLine("Escolha sua jogada:");
                        Console.WriteLine("0 - Ataque pesado");
                        Console.WriteLine("1 - Postura de contra-ataque");
                        Console.WriteLine("2 - Ataque ágil");
                        Console.Write("Sua escolha: ");

                        if (!int.TryParse(Console.ReadLine(), out int escolhaJogadorInformado) || escolhaJogadorInformado < 0 || escolhaJogadorInformado > 2)
                        {
                            Console.WriteLine("\nEscolha inválida. Você hesitou e a máquina te golpeou!");
                            vidaJogador -= 2.0;
                            levouDanoNestaRodada = true;
                            Console.ReadKey();
                            continue;
                        }
                        escolhaJogador = escolhaJogadorInformado;
                    }
                    Console.Clear();
                    if (empatouForçado)
                    {
                        Console.WriteLine("==================================================================");
                        Console.WriteLine(" ENCONTRO DE INTENÇÕES EXECUTADO!");
                        Console.WriteLine("Suas mentes se alinharam no Tabuleiro do Destino e a rodada foi empatada à força!");
                        Console.WriteLine("==================================================================");
                    }
                    else
                    {
                        string jogadaDoJogador = opcoes[escolhaJogador];
                        Console.WriteLine("Você escolheu: " + jogadaDoJogador);
                        Console.WriteLine("A máquina escolheu: " + jogadaDaMaquina);

                        // Comparação das jogadas caso de empate normal
                        if (jogadaDoJogador == jogadaDaMaquina)
                        {
                            Console.WriteLine("\n[EMPATE] As energias se equilibraram! Nenhum dano causado.");
                        }
                        // Comparação para determinar a vitória da rodada (Fantasia do GDD)
                        else if ((jogadaDoJogador == "Ataque pesado" && jogadaDaMaquina == "Ataque ágil") ||
                                 (jogadaDoJogador == "Postura de contra-ataque" && jogadaDaMaquina == "Ataque pesado") ||
                                 (jogadaDoJogador == "Ataque ágil" && jogadaDaMaquina == "Postura de contra-ataque"))
                        {
                            double danoFinal = danoBase;

                            // Aplicando a Habilidade Passiva de cada classe
                            if (classeEscolhida == 1) // Bárbaro
                            {
                                if (escolhaJogador == 0) { danoFinal = danoBase * 1.5; }
                                else { danoFinal = danoBase * 0.8; }
                            }
                            else if (classeEscolhida == 2) // Ladino
                            {
                                if (escolhaJogador == 2) { danoFinal = danoBase * 1.5; }
                                else { danoFinal = danoBase * 0.8; }
                            }
                            else if (classeEscolhida == 3) // Monge
                            {
                                if (escolhaJogador == 1) { danoFinal = danoBase * 1.5; }
                                else { danoFinal = danoBase * 0.8; }
                            }

                            vidaMaquina -= danoFinal;
                            if (vidaMaquina < 0) vidaMaquina = 0;

                            Console.WriteLine($"\nVocê ganhou a rodada! Causou {danoFinal:F1} de dano. O oponente tem {vidaMaquina:F1} de vida.");
                        }
                        else
                        {
                            // Vitória da máquina na rodada
                            double danoInimigo = 2.0;
                            vidaJogador -= danoInimigo;
                            if (vidaJogador < 0) vidaJogador = 0;
                            levouDanoNestaRodada = true; // Ativa a permissão para usar o Nível 4 na próxima rodada

                            Console.WriteLine($"\nA máquina ganhou a rodada! Você perdeu {danoInimigo} de vida, restam {vidaJogador:F1} de PV.");
                        }
                    }

                    Console.WriteLine("\nPressione qualquer tecla para a próxima rodada...");
                    Console.ReadKey();
                }

                // VERIFICAÇÃO DE VITÓRIA OU DERROTA DA BATALHA ATUAL
                Console.Clear();
                if (vidaJogador <= 0)
                {
                    Console.WriteLine("==================================================================");
                    Console.WriteLine("   GAME OVER - O MONOMITO FOI QUEBRADO");
                    Console.WriteLine("==================================================================");
                    Console.WriteLine("O mal de Giygas irá sucumbir o mundo perante a sua queda.");
                    Console.WriteLine("Sua jornada termina aqui. Descanse, jovem herói.");
                    Console.WriteLine("==================================================================");
                    Console.ReadKey();
                    return; // Fecha o programa definitivamente
                }
                else
                {
                    vitoriasTotais++;
                    Console.WriteLine("==================================================================");
                    if (nivel >= 4)
                    {
                        Console.WriteLine(" O MONOMITO TRIUNFOU! GIYGAS FOI DESTRUÍDO EM DEFINITIVO! ");
                        Console.WriteLine("==================================================================");
                        Console.WriteLine($"Parabéns, {jogador}! As histórias reais foram salvas e a paz retornou!");
                        Console.WriteLine("A Five Migas saúda você pela conclusão da Jornada do Herói!");
                        Console.WriteLine("Pressione qualquer tecla para encerrar com honras...");
                        Console.ReadKey();
                        return; // Vitória máxima do jogo, encerra o programa com sucesso!
                    }
                    else
                    {
                        Console.WriteLine(jogador + " venceu a batalha, o lacaio de Giygas foi purificado!");
                        Console.WriteLine("==================================================================");
                    }

                    // SISTEMA DE PROGRESSÃO ENTRE PARTIDAS DO GDD
                    if (vitoriasTotais == 1 && nivel == 1)
                    {
                        nivel = 2;
                        vidaMaximaJogador += 1.0; // Recompensa Nível 2: +1 PV Máximo
                        Console.WriteLine("\n RECOMPENSA DE NÍVEL DESTRANCADA! ");
                        Console.WriteLine("Você subiu para o NÍVEL 2!");
                        Console.WriteLine($"Monomito ganhou experiência de combate! Seu PV Máximo mudou para: {vidaMaximaJogador} PV.");
                    }
                    else if (vitoriasTotais == 2 && nivel == 2)
                    {
                        nivel = 3; // Recompensa Nível 3: Ganha Preparação
                        Console.WriteLine("\n RECOMPENSA DE NÍVEL DESTRANCADA! ");
                        Console.WriteLine("Você subiu para o NÍVEL 3!");
                        Console.WriteLine("Habilidade Desbloqueada: PREPARAÇÃO! (Dicas visuais a cada 2 rodadas)");
                    }
                    else if (vitoriasTotais == 3 && nivel == 3)
                    {
                        nivel = 4; // Recompensa Nível 4: Ganha Encontro de Intenções
                        Console.WriteLine("\n RECOMPENSA DE NÍVEL DESTRANCADA! ");
                        Console.WriteLine("Você subiu para o NÍVEL 4!");
                        Console.WriteLine("Habilidade Desbloqueada: ENCONTRO DE INTENÇÕES! (Forçar empate após sofrer dano)");
                        Console.WriteLine("Prepare-se... GIYGAS sentiu sua força e atacará agora!");
                    }

                    // Recompensa de Continuidade: Cura total antes do próximo combate
                    vidaJogador = vidaMaximaJogador;

                    Console.WriteLine("\nPrepare-se para o próximo desafio da jornada...");
                    Console.WriteLine("Pressione qualquer tecla para marchar adiante...");
                    Console.ReadKey();
                }
            }
        }
    }
}

// anotações e pensamentos que tive durante o desenvolvimento do jogo:

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
//Descobri para que o \n serve, ele serve para pular uma linha no console, então quando você usa o \n, o texto que vem depois dele vai aparecer na linha de baixo.
//tutorial, essa linha é só para dividir o código em partes menores e mais fáceis de entender, não é necessário para o funcionamento do jogo.
// Guarda o limite máximo inicial (8, 9, 10 ou 13)
// ... (Toda a sua lógica atual de escolher jogada, comparar e aplicar dano)
// O jogador venceu esta batalha!
// Recupera os pontos de vida do jogador para o máximo atual antes da próxima batalha
// O código bate na chave de fechamento abaixo e VOLTA para o início do 'while (vidaJogador > 0)'
// começando uma nova batalha com a vidaMaquina valendo 10 de novo

// Validação da classe escolhida pelo jogador
// traduzindo essa parte do código: se o jogador não digitar um número válido entre 1 e 4, ele será automaticamente colocado na classe Monomito (opção 4).
// int.TryParse: Tenta converter o texto que o Console.ReadLine() pegou em um número inteiro.
//out int classeEscolhida: O out serve para criar a variável e passar o resultado para fora. EX: Se o jogador digitar
//"1", o TryParse consegue converter e o out joga o número 1 dentro da variável classeEscolhida.
//tive que mudar a variável classeEscolhida, antes ela não tava definida, e mudou a parte do out int
// mas fica aí de aprendizado, o out é usado para passar o valor de uma variável para fora do método e o !int é tipo um inversor de true e false

// no final só deixei algumas divisões de código para deixar o código mais organizado e fácil de ler, mas não afeta o funcionamento do jogo.
// Infelizmente, achei muito dificíl fazer aquelas divisões de texto ========== e pedi para o chat só colocar para mim
// ainda tive que montar tipo um quebra cabeça no código porque eu tinha começado por uma ordem totalmente aleatória, mas no final deu certo e o jogo funciona bem.(espero eu....)
//talvez era para eu ter feito algum planejamento antes de começar a escrever o código, mas eu não fiz, então tive que ir ajustando as coisas no meio do caminho. Mas no final deu certo e o jogo funciona bem.(espero eu....)
//espero eu... é tipo uma referencia à segunda fase do romantismo brasileiro, que é a fase da incerteza, da dúvida, da melancolia e da subjetividade. É uma fase em que o eu lírico se sente perdido, inseguro e angustiado diante do mundo e da vida. É uma fase em que o eu lírico
//busca respostas para os seus questionamentos existenciais e para os seus conflitos internos. É uma fase em que o eu lírico se volta para si mesmo e para os seus sentimentos, emoções e pensamentos. É uma fase em que o eu lírico se expressa através da poesia, da música e da arte. É uma fase em que o eu lírico se revela
//como um ser humano complexo, sensível e vulnerável. É uma fase em que o eu lírico se identifica com a natureza, com a sociedade e com a história. É uma fase em que o eu lírico se transforma em um herói trágico, que enfrenta os desafios da vida com coragem, dignidade e esperança. 
//nem lembrava de tudo isso, mas o auto complete meteu aí e eu não quero tirar
//bom tinha tanto comentario espalhado que eu acabei colocando tudo aqui para organizar melhor.