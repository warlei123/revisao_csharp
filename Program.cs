using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            var operacoes = new Operacoes();
            string opcaoUsuario = ObterOpcaoUsuario();
            Aluno[] alunos = new Aluno[1000];
            var indiceAluno = 0;
            Aluno aluno = new Aluno();
            
            while (opcaoUsuario.ToUpper() != "X")
            {

                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno");
                        aluno.nome = Console.ReadLine();
                        Random padraDaMatricula = new Random();
                        aluno.matricula = padraDaMatricula.Next(1000, 9999);
                        
                    
                        Console.WriteLine("Informe a nota do aluno");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.nota = nota;
                        }
                        else
                        {
                        Console.WriteLine("Opçao inválida.");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;

                    case "2":
                        foreach (var referenciaDoAluno in alunos)
                        if(!string.IsNullOrEmpty(referenciaDoAluno.nome)){
                            {
                                Console.WriteLine($"Aluno {referenciaDoAluno.nome} - nota {referenciaDoAluno.nota} - Matricula {referenciaDoAluno.matricula}");
                            }
                        }
                        break;
                        
                    case "3":
                        decimal notaTotal = 0;
                        var numeroDeAlunos = 0;

                        for(int i = 0; i < alunos.Length; i++)
                        {
                            if(!string.IsNullOrWhiteSpace(alunos[i].nome))
                            {
                                notaTotal = notaTotal + alunos[i].nota;
                                numeroDeAlunos++;
                            }
                        }
                        var mediaGeral = notaTotal / numeroDeAlunos;
                        Conceito conceitoGeral;
                        
                        if(mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.Pessimo;
                        }
                        else if(mediaGeral >= 2 && mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.Ruim;
                        }
                        else if(mediaGeral >=4 && mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.Regular;
                        }
                        else if(mediaGeral >= 6 && mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.Bom;
                        }
                        else
                        {
                            conceitoGeral = Conceito.Perfeito;
                        }

                        Console.WriteLine($"Media Geral: {mediaGeral} - conceito: {conceitoGeral}");
                        break;
                    case "4":
                        
                        Console.WriteLine("Informe o numero da matricula");
                        var numeroMatriculaDoAluno = Console.ReadLine(); 
                        var textoMatricula = aluno.matricula.ToString();

                        if(numeroMatriculaDoAluno == textoMatricula)
                        {
                            if (aluno.nota < 6)
                            {
                                Console.WriteLine($"O aluno {aluno.nome} esta reprovado");
                            }
                            else if(aluno.nota == 6)
                            {
                                Console.WriteLine($"O aluno {aluno.nome} está em Recuperação");
                            }
                            else
                            {
                                Console.WriteLine($"O aluno {aluno.nome} esta aprovado");
                            }
                        }
                       break;
                        
                        
                    default:
                        Console.WriteLine("Opçao inválida.");
                        break;
                }

               opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar aluno");
            Console.WriteLine("3 - Calcular media geral");
            Console.WriteLine("4 - Verificar situação do aluno");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
  
        static int PerguntaNumero()
        {
           Console.WriteLine("Digite um numero");
           var numeroEscolhido = Console.ReadLine();
   
           return int.Parse(numeroEscolhido);
        }
    }
}
