using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMedicamentos
{
    class Program
    {
        public static Medicamentos med = new Medicamentos();
        static void Main(string[] args)
        {
            int opcao;
            bool menuescolha;

            do
            {
                Console.Clear();
                Console.WriteLine("****************************************");
                Console.WriteLine("0. Finalizar processo");
                Console.WriteLine("1. Cadastrar medicamento ");
                Console.WriteLine("2. Consultar medicamento (Sintetico) ");
                Console.WriteLine("3. Consultar medicamento (analítico)");
                Console.WriteLine("4. Comprar medicamento");
                Console.WriteLine("5. Vender medicamento");
                Console.WriteLine("6. Listar medicamentos");
                Console.WriteLine("****************************************");
                Console.WriteLine("Escolha sua Opção:");
                menuescolha = int.TryParse(Console.ReadLine(), out opcao);
                if (menuescolha)
                {
                    Medicamento mAux = new Medicamento();
                    bool aux;
                    int Mid, Lid = 0, qtd = 0;
                    DateTime venc;
                    string Mlab, Mnome;
                    Lote mLote = new Lote();

                    switch (opcao)
                    {
                        case 0:
                            return;
                        case 1:
                            Console.WriteLine("insira as informaçoes do cadastro");
                            do
                            {
                                Console.Write("insira o numero do ID: ");
                                aux = int.TryParse(Console.ReadLine(), out Mid);
                                if (!aux)
                                    Console.WriteLine("tem que ser somente numero");
                            } while (!aux);

                            Console.WriteLine("digite o nome do  medicamento a ser cadastrado: ");
                             Mnome = Console.ReadLine();
                            Console.WriteLine("digite o laboratório do medicamento a ser cadastrado: ");
                            Mlab = Console.ReadLine();
                            Medicamento m1 = new Medicamento(Mid, Mnome, Mlab);
                            med.adicionar(m1);
                            Console.WriteLine("dados inseridos");
                            Console.ReadKey();
                            break;
                        case 2:
                            do
                            {
                                Console.WriteLine("digite o ID a ser consultado");
                                aux = int.TryParse(Console.ReadLine(), out Mid);
                                if (aux)
                                {
                                    mAux = med.pesquisar(new Medicamento(Mid, "", ""));
                                    if (mAux.Id == 0)
                                        Console.WriteLine("Medicamento não encontrado");
                                    else
                                        Console.WriteLine(mAux.ToString());
                                }
                                else
                                    Console.WriteLine("tem que ser numero lek ");
                            } while (!aux);
                            Console.ReadKey();
                            break;
                        case 3:
                            do
                            {
                                Console.WriteLine("digite ID: ");
                                aux = int.TryParse(Console.ReadLine(), out Mid);
                                if (aux)
                                {
                                    mAux = med.pesquisar(new Medicamento(Mid, "", ""));
                                    if (mAux.Id == 0)
                                        Console.WriteLine("Medicamento não encontrado");
                                    else
                                        Console.WriteLine(mAux.ToString());

                                    foreach (Lote l in mAux.Lotes)
                                    {
                                        Console.WriteLine(l.ToString());
                                    }
                                }
                                else
                                    Console.WriteLine("lek é serio escolha um numero ");
                            } while (!aux);
                            Console.ReadKey();
                            break;
                        case 4:
                            venc = DateTime.Now;
                            Console.WriteLine("Digite o ID e quantidade do medicamento que deseja comprar: ");
                            aux = int.TryParse(Console.ReadLine(), out Mid);
                            mAux = med.pesquisar(new Medicamento(Mid, "", ""));
                            if (mAux.Id == 0)
                                Console.WriteLine("medicamento não encontrado: ");
                            else
                            {
                                Console.WriteLine("Informações do lote ");
                                do
                                {
                                    Console.WriteLine("ID do Lote ");
                                    aux = int.TryParse(Console.ReadLine(), out Lid);
                                    if (!aux)
                                        Console.WriteLine("por favor só numeros");
                                } while (!aux);
                                do
                                {
                                    Console.WriteLine("quantidade");
                                    aux = int.TryParse(Console.ReadLine(), out qtd);
                                    if (!aux)
                                        Console.WriteLine("a quantidade tem que ser em numero ");
                                } while (!aux && Lid < 0);

                                do
                                {
                                    Console.WriteLine("data de vencimento (DD/MM/AAAA)");
                                    aux = DateTime.TryParse(Console.ReadLine(), out venc);
                                    if (!aux)
                                    {
                                        Console.WriteLine("Data Invalida");
                                        Console.WriteLine("Data deve possuir dia mes e ano separados:");
                                    }
                                } while (!aux);
                                Console.WriteLine("Compra realizada com sucesso!!!");
                            }

                            Lote nLote = new Lote(Lid, qtd, venc);
                            mAux.comprar(nLote);
                            
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.WriteLine("Digite o id do medicamento");
                            aux = int.TryParse(Console.ReadLine(), out Mid);
                            mAux = med.pesquisar(new Medicamento(Mid, "", ""));
                            if (mAux.Id == 0)
                                Console.WriteLine("Medicamento não encontrado ");
                            else
                            {
                                do
                                {
                                    Console.WriteLine("Quantidade de produtos");
                                    aux = int.TryParse(Console.ReadLine(), out qtd);
                                    if (!aux && Lid < 0)
                                        Console.WriteLine("A quantidade precisa ser numeros positivos");

                                } while (!aux && Lid < 0);
                                mAux.vender(qtd);
                                Console.WriteLine("produto vendido!!");
                            }
                            Console.ReadKey();
                            break;
                        case 6:
                            foreach (Medicamento m in med.ListaMedicamentos)
                            {
                                Console.WriteLine(m.ToString());
                            }
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("a Opção que escolheu está invalida");
                            Console.WriteLine("as opções são numeros de 0 à 6");
                            Console.ReadKey();

                            break;

                    }

                }
                else
                {
                    Console.WriteLine("OPÇÃO INVÁLIDA");
                    Console.WriteLine("Insira um número entre 0 e 6.");
                    opcao = 7;
                    Console.ReadKey();
                    Console.Clear();
                }
                
            } while (opcao != 0);

          

        }
    }
}
