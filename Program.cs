using System;
using System.Linq;

namespace joguinho_maroto
{
    class Program
    {
        static void Main(string[] args)
        {
        repeticao: //referencia para voltar caso o jogador queira jogar novamente

            Random numero = new Random();
            string[] palavras = new string[7] { "hipopotamo", "canguru", "narval", "penguim", "gazela", "veado", "leão" }; //matriz com as palavras a serem embaralhadas
            char[] letras;  // variavel para separar as palavras
            int[] sequenciaNumeros; //array para colocar os numeros gerados em uma sequencia, onde cada numero é uma letras
            int numeroGerado; // numero gerado aleatoriamente é armazenado aqui
            string respostaUsuario;
            int numeroAcertos = 0;


            Console.WriteLine("Bem vindos ao jogo: ANAGRAMANIA DA TIA <3\r\nPara ganhar o jogo você deve adivinhar quais são as palvras que estam emabalharadas.\r\nBoa sorte ;)!!");
            for (int i = 0; i < palavras.Length; i++)
            {
                letras = palavras[i].ToCharArray(); // quebrar a palavra em caracteres
                Console.WriteLine();

                sequenciaNumeros = new int[letras.Length]; // sequencia de numeros vai ser do tamanho da varias letras 
                for (int h = 0; h < letras.Length; h++) //caracter individual do array
                {
                inicio: //referencia
                    numeroGerado = numero.Next(letras.Length); //numeros é gerado aleatoriamente
                    sequenciaNumeros[h] = 10; // é pre definido um numero, para quando for gerado o numero 0 nao de erro no codigo
                    for (int p = 0; p < letras.Length; p++)
                    {
                        if (sequenciaNumeros[p] == numeroGerado) //testa para ver se o numero gerado ja foi repetido
                        {
                            goto inicio; // se o numero já foi gerado ele volta pra linha de referencia e pula todo o resto do for
                        }
                    }
                    sequenciaNumeros[h] = numeroGerado;
                }
                for (int j = 0; j < letras.Length; j++)
                {
                    Console.Write(letras[sequenciaNumeros[j]]);//ele usa a sequencia de numeros aleatorio para pegar uma letra da palavra
                }

            }
            Console.WriteLine();
            Console.WriteLine();
            while (numeroAcertos < palavras.Length) //o loop acontece ate o usuario acertar todas as palavras
            {

                Console.WriteLine("Digite uma palavras:");
                respostaUsuario = Console.ReadLine().ToLower();
                for (int l = 0; l < palavras.Length; l++) // loop para verificar se a palavra digitada esta certa
                {
                    if (respostaUsuario == palavras[l]) // essa condição é para ver se o usuario acertou algumas das palavras, se nao, é pedido novamente uma palvra e todo o loop acontece novamente
                    {
                        numeroAcertos++;
                        Console.WriteLine("Parabens você acertou a palavras: " + respostaUsuario + ". Ainda falta " + numeroAcertos + "/" + palavras.Length + " palavras");
                        Console.WriteLine();
                    }
                }
            }
            Console.WriteLine("Parabéns!!! *clap* *clap* *clap* Você acertou todas as palavras. Muito obrigada por ter jogado ANAGRAMANIA DA TIA ");
            Console.WriteLine("Se desejar sair do jogo, aperte: <enter>. Se quiser refazer o quiz, aperte qualquer tecla  ");
            if (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                goto repeticao; // volta pro começo do codigo
            }
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Environment.Exit(0); //acaba o programa
            }
        }
    }
}
